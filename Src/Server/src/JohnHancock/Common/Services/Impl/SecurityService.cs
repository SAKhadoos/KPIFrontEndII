/*
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 */

using Microsoft.Practices.Unity;
using System;
using System.Data.Entity;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using JohnHancock.ProjectCoeus.Services.Impl;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Entities;

namespace JohnHancock.Common.Services.Impl
{
    /// <summary>
    /// This service class provides operations for managing security operations.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Updated 'Authenticate(string, string)' and 'Authenticate(string)' to check the role and status of user.
    /// Changes in 1.2:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, TCSASSEMBLER, [es]/TCSASSEMBLER</author>
    /// <version>1.2</version>
    /// <copyright>Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.</copyright>
    public class SecurityService : BasePersistenceService<CustomDbContext>, ISecurityService
    {
        /// <summary>
        /// Gets or sets the Active Directory users domain path.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> or empty after initialization.
        /// </para>
        /// It is used for connecting to Active Directory.
        /// </remarks>
        ///
        /// <value>The Active Directory users domain path.</value>
        [Dependency]
        public string ADUsersDomain { get; set; }

        /// <summary>
        /// Gets or sets the Active Directory admin username.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> or empty after initialization.
        /// </para>
        /// It is used for connecting to Active Directory.
        /// </remarks>
        ///
        /// <value>The Active Directory admin username.</value>
        [Dependency]
        public string ADAdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the Active Directory admin user password.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> or empty after initialization.
        /// </para>
        /// It is used for connecting to Active Directory.
        /// </remarks>
        ///
        /// <value>The Active Directory admin user password.</value>
        [Dependency]
        public string ADAdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the token expiration time in minutes.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should be positive after initialization.
        /// </para>
        /// It is used for managing token expirations.
        /// </remarks>
        ///
        /// <value>The token expiration time in minutes.</value>
        [Dependency]
        public int TokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IUserService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for retrieving users.
        /// </remarks>
        ///
        /// <value>The <see cref="IUserService"/> dependency.</value>
        [Dependency]
        public IUserService UserService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityService"/> class.
        /// </summary>
        public SecurityService()
        {
        }

        /// <summary>
        /// Checks that all configuration properties were properly initialized.
        /// </summary>
        ///
        /// <exception cref="ConfigurationException">
        /// If any of required injection fields are not injected or have invalid values.
        /// </exception>
        public override void CheckConfiguration()
        {
            base.CheckConfiguration();
            CommonHelper.ValidateConfigPropertyNotNull(UserService, nameof(UserService));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADUsersDomain, nameof(ADUsersDomain));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADAdminUsername, nameof(ADAdminUsername));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADAdminPassword, nameof(ADAdminPassword));
            CommonHelper.ValidateConfigPropertyPositive(TokenExpiration, nameof(TokenExpiration));
        }

        /// <summary>
        /// Authenticates user and returns populated User instance in case of success.
        /// </summary>
        ///
        /// <param name="username">The username.</param>
        /// <param name="password">The user password.</param>
        /// <returns>The authenticated User entity, or null if cannot authenticate user.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="username"/> or <paramref name="password"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> or <paramref name="password"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="AuthenticationException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public User Authenticate(string username, string password)
        {
            return Logger.Process(() =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(username, nameof(username));
                CommonHelper.ValidateArgumentNotNullOrEmpty(password, nameof(password));

                try
                {
                    // authenticate user using Active Directory
                    var context = new PrincipalContext(ContextType.Domain, ADUsersDomain, ADAdminUsername, ADAdminPassword);
                    if (!context.ValidateCredentials(username, password))
                    {
                        return null;
                    }

                    return GetUserByUsername(username);
                }
                catch (PersistenceException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw new AuthenticationException(
                        "An error occurred while authenticating user with credentials.", ex);
                }
            },
            "authenticating user against Active Directory",
            parameters: new object[] { username, CommonHelper.PasswordMask });
        }

        /// <summary>
        /// Checks whether user with the given role is authorized to perform specified action.
        /// </summary>
        ///
        /// <param name="role">The user role.</param>
        /// <param name="action">The action to perform.</param>
        /// <returns>True if user with the given role is authorized to perform
        /// specified action; otherwise False.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="action"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="action"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public bool IsAuthorized(Role role, string action)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(action, nameof(action));

                return db.ActionPermissionSet.Any(ap => ap.Action == action && ap.Role == role);
            },
            "checking whether user with the given role is authorized to perform specified action",
            parameters: new object[] { role, action });
        }

        /// <summary>
        /// Generates token for the user with the given username.
        /// </summary>
        ///
        /// <param name="username">The username.</param>
        /// <returns>The generated token.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="username"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public Token GenerateToken(string username)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(username, nameof(username));

                var token = new Token
                {
                    Username = username,
                    TokenValue = Guid.NewGuid().ToString(),
                    ExpirationDate = DateTime.Now.AddMinutes(TokenExpiration)
                };
                db.TokenSet.Add(token);
                return token;
            },
            "generating token",
            saveChanges: true,
            parameters: username);
        }

        /// <summary>
        /// Authenticates user and returns populated User instance in case of success.
        /// </summary>
        ///
        /// <param name="token">The token.</param>
        /// <returns>The authenticated User entity, or null if cannot authenticate user.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="token"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="token"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public User Authenticate(string token)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(token, nameof(token));

                // get valid token
                Token tk = GetValidToken(token, db.TokenSet);

                return tk != null ? GetUserByUsername(tk.Username) : null;
            },
            "authenticating user with token",
            parameters: token);
        }

        /// <summary>
        /// Revokes the token.
        /// </summary>
        ///
        /// <param name="token">The token to revoke.</param>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="token"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="token"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public void RevokeToken(string token)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(token, nameof(token));

                Token tokenEntity = GetValidToken(token, db.TokenSet);
                if (tokenEntity != null)
                {
                    db.TokenSet.Remove(tokenEntity);
                    db.SaveChanges();
                }
            },
            "revoking token",
            parameters: token);
        }

        /// <summary>
        /// Gets the <see cref="Token"/> instance by token value.
        /// </summary>
        /// <param name="token">The token to search for.</param>
        /// <param name="dbSet">The database set of tokens.</param>
        /// <returns>Then matching token, or <c>null</c> if not found.</returns>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        private static Token GetValidToken(string token, DbSet<Token> dbSet)
        {
            return dbSet.Where(c => c.TokenValue == token && c.ExpirationDate > DateTime.Now).FirstOrDefault();
        }

        
        /// <summary>
        /// Gets the user by username and checks if it can be authenticated.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The user if found and valid for authenticate else null.</returns>
        private User GetUserByUsername(string username)
        {
            User user = UserService.GetByUsername(username);
            
            // when user.Role is null, it means that user doesn't have valid role for this application
            if (user != null && user.IsActive && (user.Role != null || user.KPIRole != null))
            {
                return user;
            }
            return null;
        }
    }
}