/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using System;
using System.Collections.Generic;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.Common.Services
{
    /// <summary>
    /// This service interface defines methods for managing users.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Added 'Update', 'Delete' and 'Search' methods
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public interface IUserService
    {
        /// <summary>
        /// Gets the user by username.
        /// </summary>
        ///
        /// <param name="username">The username.</param>
        /// <returns>The user with the given username, or null if not found.</returns>
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
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        User GetByUsername(string username);

        /// <summary>
        /// Gets all users whose real name (first name + ' ' + last name) contains <paramref name="realName"/>.
        /// </summary>
        ///
        /// <param name="realName">The user real name substring to match.</param>
        /// <returns>Matching users, or empty list if none were found.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="realName"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="realName"/> is empty.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<User> GetByRealName(string realName);

        /// <summary>
        /// <para>
        /// Updates the given user.
        /// </para>
        /// </summary>
        ///
        /// <param name="user">The given user.</param>
        ///
        /// <exception cref="ArgumentNullException">If <paramref name="user"/> is null
        /// or user.Username is null.</exception>
        /// <exception cref="ArgumentException"> If user.Username is empty or user.Role is null
        /// </exception>
        /// <exception cref="EntityNotFoundException">If the user to update doesn't exist.</exception>
        /// <exception cref="PersistenceException">If error occurred during access the persistence.
        /// </exception>
        /// <exception cref="ServiceException"> If any other error occurred. </exception>
        void Update(User user);

        /// <summary>
        /// <para>
        /// Delete the user mapping info.
        /// </para>
        /// </summary>
        ///
        /// <param name="username">The username.</param>
        ///
        /// <exception cref="ArgumentNullException">If <paramref name="username"/> is null.</exception>
        /// <exception cref="ArgumentException"> If <paramref name="username"/> is empty.</exception>
        /// <exception cref="PersistenceException">If error occurred during access the persistence.
        /// </exception>
        /// <exception cref="ServiceException"> If any other error occurred. </exception>
        void Delete(string username);

        /// <summary>
        /// <para>
        /// Search users in Active Directory and mapping info in database.
        /// </para>
        /// </summary>
        ///
        /// <param name="criteria">The user search criteria.</param>
        ///
        /// <returns>The search result.</returns>
        ///
        /// <exception cref="ArgumentNullException">If <paramref name="criteria"/> is null.</exception>
        /// <exception cref="ArgumentException">If the <paramref name="criteria"/> is incorrect,
        /// e.g. PageNumber is negative, or PageNumber is positive and PageSize is not positive.</exception>
        /// <exception cref="PersistenceException">If error occurred during access the persistence.
        /// </exception>
        /// <exception cref="ServiceException"> If any other error occurred. </exception>
        SearchResult<User> Search(UserSearchCriteria criteria);
    }
}