/*
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.DirectoryServices;
using System.Linq;
using JohnHancock.ProjectCoeus.Services;
using JohnHancock.Common.Exceptions;
using JohnHancock.ProjectCoeus.Services.Impl;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Entities;

namespace JohnHancock.Common.Services.Impl
{
    /// <summary>
    /// This service class provides operations for managing users.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Added new methods 'Update', 'Get', 'Delete' and 'Search'
    /// - Updated logic to get and save the user info in database instead of getting from AD.
    /// - added new dependency property 'ADUsersGroupName' and 'ADGroupDomainTemplate'
    /// Changes in 1.2:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, TCSASSEMBLER, [es]/TCSASSEMBLER</author>
    /// <version>1.2</version>
    /// <copyright>Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.</copyright>
    public class UserService : BasePersistenceService<CustomDbContext>, IUserService
    {
        /// <summary>
        /// The first name key in AD property mappings.
        /// </summary>
        private const string FirstNameKey = "FirstName";

        /// <summary>
        /// The last name key in AD property mappings.
        /// </summary>
        private const string LastNameKey = "LastName";

        /// <summary>
        /// Represents the distinguishedName attribute name of AD.
        /// </summary>
        private const string DistinguishedName = "distinguishedName";

        /// <summary>
        /// <para>
        /// Represents the Active directory Users group name.
        /// </para>
        /// </summary>
        /// <value>The Active directory Users group name. It's initialized by Unity through injection.
        /// It should not be null/empty after initialization.</value>
        [Dependency]
        public string ADUsersGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Active Directory users domain path.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> or empty after initialization.
        /// </para>
        /// It is used for accessing users in Active Directory.
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
        /// Gets or sets the Active Directory user property mappings.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> or empty after initialization. Should not contain empty keys or null/empty values.
        /// </para>
        /// It is used for mapping user properties to Active Directory properties.
        /// </remarks>
        ///
        /// <value>The Active Directory user property mappings.</value>
        [Dependency]
        public IDictionary<string, string> ADPropertyNameMapping { get; set; }

        /// <summary>
        /// <para>
        /// Represents the Active directory Group domain template.
        /// </para>
        /// </summary>
        /// <value>The Active directory Group domain template. It's initialized by Unity through injection.
        /// It should not be null/empty after initialization.</value>
        [Dependency]
        public string ADGroupDomainTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="ILookupService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for retrieving lookup entities.
        /// </remarks>
        ///
        /// <value>The <see cref="ILookupService"/> dependency.</value>
        [Dependency]
        public ILookupService LookupService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
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

            CommonHelper.ValidateConfigPropertyNotNull(LookupService, nameof(LookupService));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADUsersGroupName, nameof(ADUsersGroupName));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADUsersDomain, nameof(ADUsersDomain));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADAdminUsername, nameof(ADAdminUsername));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADAdminPassword, nameof(ADAdminPassword));
            CommonHelper.ValidateConfigPropertyNotNullOrEmpty(ADGroupDomainTemplate, nameof(ADGroupDomainTemplate));

            CommonHelper.ValidateConfigProperty(ADPropertyNameMapping, nameof(ADPropertyNameMapping));

            CheckMapping(FirstNameKey);
            CheckMapping(LastNameKey);
        }

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
        public User GetByUsername(string username)
        {
            return Logger.Process(() =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(username, nameof(username));

                var criteria = new UserSearchCriteria { Username = username };
                IList<User> users = SearchUser(criteria).Items;
                return users.FirstOrDefault();
            },
            "retrieving user by username",
            parameters: username);
        }

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
        public IList<User> GetByRealName(string realName)
        {
            return Logger.Process(() =>
            {
                CommonHelper.ValidateArgumentNotNull(realName, nameof(realName));

                var criteria = new UserSearchCriteria { RealName = realName };
                return SearchUser(criteria).Items;
            },
            "retrieving users by real user name",
            parameters: realName);
        }

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
        public void Update(User user)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(user, "user");
                CommonHelper.ValidateArgumentNotNullOrEmpty(user.Username, "user.Username");
                if (user.Role == null && user.KPIRole == null)
                {
                    throw new ArgumentException(
                        $"The parameters user.Role and user.KPIRole cannot both be null.", "user");
                }

                if (GetDirectoryEntryOfUser(user.Username) == null)
                {
                    throw new EntityNotFoundException(
                        "User does not exists with username :" + user.Username);
                }
                var entity = new UserMappingInfo
                {
                    BusinessUnits = user.BusinessUnits,
                    Role = user.Role,
                    KPIRole = user.KPIRole,
                    IsActive = user.IsActive,
                    Username = user.Username
                };
                var userMappingSet = db.UserMappingInfoSet;
                var existing = userMappingSet.Include(p => p.BusinessUnits)
                                                    .FirstOrDefault(p => p.Username == user.Username);

                ResolveEntities(db, entity.BusinessUnits);

                if (existing != null) // if user mapping already exists in database then update else add
                {
                    CheckReferenceForUpdate(user.Username, existing, entity, db);

                    // if role is changed or status changed to inactive 
                    if (existing.Role != entity.Role || existing.KPIRole != entity.KPIRole
                        || (existing.IsActive && !entity.IsActive))
                    {
                        // delete current active tokens if any
                        RemoveUserTokens(user.Username, db);
                    }

                    entity.Id = existing.Id;
                    db.Entry(existing).CurrentValues.SetValues(entity);
                    existing.BusinessUnits = entity.BusinessUnits;
                }
                else
                {
                    userMappingSet.Add(entity);
                }

                db.SaveChanges();
            },
            "updating user",
            parameters: user);
        }

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
        public void Delete(string username)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(username, "username");

                var userSet = db.UserMappingInfoSet;

                var userMappingInfo = userSet.Include(q => q.BusinessUnits)
                        .FirstOrDefault(p => p.Username == username);

                if (userMappingInfo != null) // if user detail is not saved yet just ignore it
                {
                    CheckReferenceForDelete(username, userMappingInfo.Role, db);

                    // delete current active tokens if any
                    RemoveUserTokens(username, db);

                    // remove user
                    userSet.Remove(userMappingInfo);
                    db.SaveChanges();
                }
            }, "deleting user information", parameters: username);
        }

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
        public SearchResult<User> Search(UserSearchCriteria criteria)
        {
            return Logger.Process(() =>
            {
                CommonHelper.CheckSearchCriteria(criteria);
                return SearchUser(criteria, true);
            },
            "searching users",
            parameters: criteria);
        }

        #region private methods

        /// <summary>
        /// Removes the tokens of user if any.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="db">The db context.</param>
        private static void RemoveUserTokens(string username, CustomDbContext db)
        {
            // delete current active tokens if any
            var tokenSet = db.TokenSet;
            tokenSet.RemoveRange(tokenSet.Where(p => p.Username == username));
        }

        /// <summary>
        /// Searches the users on AD
        /// </summary>
        /// <param name="criteria">The user search criteria.</param>
        /// <param name="searchWithLike">The flag whether to search username with like operator or not.</param>
        /// <returns>The search result.</returns>
        /// <exception cref="PersistenceException">
        /// If Active Directory or database related error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If user doesn't have business units, or if user business unit are not valid.
        /// </exception>
        /// <remarks>Other exceptions will be propagated.</remarks>
        private SearchResult<User> SearchUser(UserSearchCriteria criteria, bool searchWithLike = false)
        {
            try
            {
                using (var de = new DirectoryEntry(ADUsersDomain, ADAdminUsername, ADAdminPassword,
                AuthenticationTypes.Secure))
                {
                    var ds = new DirectorySearcher
                    {
                        SearchRoot = de,
                        Filter = "(&(objectClass=user)"
                    };


                    // all users will have same group name
                    ds.Filter += "(memberOf=" + GetGroupDistinguishedName(ADUsersGroupName) + ")";

                    if (criteria.Username != null)
                    {
                        ds.Filter += searchWithLike ? "(CN=*" + criteria.Username + "*)"
                            : "(CN=" + criteria.Username + ")";
                    }

                    ds.Filter += ")";

                    ds.SearchScope = SearchScope.Subtree;
                    SearchResultCollection searchResultCollection = ds.FindAll();
                    IList<User> items = new List<User>();
                    foreach (SearchResult searchResult in searchResultCollection)
                    {
                        string firstName = GetPropertyValue(searchResult.Properties, FirstNameKey);
                        string lastName = GetPropertyValue(searchResult.Properties, LastNameKey);

                        if (criteria.RealName != null)
                        {
                            if (!(firstName + " " + lastName).ToUpper().Contains(criteria.RealName.ToUpper()))
                            {
                                continue;
                            }
                        }

                        string username = searchResult.Properties["CN"][0].ToString();
                        items.Add(new User
                        {
                            Username = username,
                            FirstName = firstName,
                            LastName = lastName
                        });
                    }
                    var userMappingInfos = GetUserMappingInfo(items.Select(p => p.Username).ToList());
                    foreach (var user in items)
                    {
                        var userMappingInfo = userMappingInfos.FirstOrDefault(p => p.Username == user.Username);
                        user.Role = userMappingInfo?.Role;
                        user.KPIRole = userMappingInfo?.KPIRole;
                        user.IsActive = userMappingInfo?.IsActive ?? false;
                        user.BusinessUnits = userMappingInfo?.BusinessUnits ?? new List<BusinessUnit>();
                    }
                    if (string.IsNullOrEmpty(criteria.SortBy))
                    {
                        criteria.SortBy = "Username";
                    }
                    // apply filter for other properties
                    var query = items.AsQueryable();
                    if (criteria.Roles != null && criteria.Roles.Count > 0)
                    {
                        query = query.Where(p => (p.Role != null && criteria.Roles.Contains(p.Role.Value))
                            || (p.KPIRole != null && criteria.Roles.Contains(p.KPIRole.Value)));
                    }
                    if (criteria.Status != null)
                    {
                        query = query.Where(p => p.IsActive == criteria.Status);
                    }
                    if (criteria.BusinessUnitIds != null && criteria.BusinessUnitIds.Count > 0)
                    {
                        query = query.Where(p => p.BusinessUnits.Select(q => q.Id).ToList()
                                                        .Intersect(criteria.BusinessUnitIds).Any());
                    }
                    if (criteria.SortBy == "Role")
                    {
                        query = criteria.SortType == SortType.Ascending
                            ? query.OrderBy(p => p.Role.ToString())
                            : query.OrderByDescending(p => p.Role.ToString());
                    }
                    else if (criteria.SortBy == "KPIRole")
                    {
                        query = criteria.SortType == SortType.Ascending
                            ? query.OrderBy(p => p.KPIRole.ToString())
                            : query.OrderByDescending(p => p.KPIRole.ToString());
                    }
                    else
                    {
                        query = criteria.SortType == SortType.Ascending ? query.OrderBy(criteria.SortBy)
                         : query.OrderByDescending(criteria.SortBy);
                    }

                    var allRecordQuery = query;
                    if (criteria.PageNumber > 0)
                    {
                        // Set paging information
                        query = query.SetPaging(criteria);
                    }

                    // Create search result
                    var result = new SearchResult<User>
                    {
                        TotalRecords = allRecordQuery.Count(),
                        Items = query.ToList()
                    };
                    SetSearchResultPageInfo(result, criteria);

                    return result;
                }
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersistenceException("An error occurred while searching users.", ex);
            }
        }

        /// <summary>
        /// Gets the user mapping info from database.
        /// </summary>
        /// <param name="usernames">The usernames.</param>
        /// <returns>The user mapping infos.</returns>
        private IList<UserMappingInfo> GetUserMappingInfo(IList<string> usernames)
        {
            using (var db = CreateDbContext())
            {
                return db.UserMappingInfoSet.Include(p => p.BusinessUnits)
                    .Where(p => usernames.Contains(p.Username)).ToList();
            }
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <remarks>The internal exception may be thrown directly.</remarks>
        /// <param name="properties">The user properties collection.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The property value.</returns>
        private string GetPropertyValue(ResultPropertyCollection properties, string propertyName)
        {
            string adPropertyName = ADPropertyNameMapping[propertyName];
            if (properties.Contains(adPropertyName))
            {
                ResultPropertyValueCollection values = properties[adPropertyName];
                if (values.Count > 0)
                {
                    return values[0].ToString();
                }
            }

            return null;
        }

        /// <summary>
        /// Get DirectoryEntry of user in Active Directory.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The DirectoryEntry of the user, or null if not found.</returns>
        /// <remarks>Any exceptions will be propagated to caller.</remarks>
        private DirectoryEntry GetDirectoryEntryOfUser(string username)
        {
            using (var usersDe = new DirectoryEntry(ADUsersDomain, ADAdminUsername, ADAdminPassword,
                AuthenticationTypes.Secure))
            {
                try
                {
                    return usersDe.Children.Find("CN=" + username, "user");
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the distinguished name of group directory entry
        /// </summary>
        /// <remarks>The AD exceptions may be thrown directly.</remarks>
        /// <param name="groupName">The AD group name to get entry for.</param>
        /// <returns>The distinguished name of group directory entry for the given group name.</returns>
        /// <exception cref="ServiceException">If given group wasn't found in AD.</exception>
        private string GetGroupDistinguishedName(string groupName)
        {
            using (var de = new DirectoryEntry(string.Format(ADGroupDomainTemplate, groupName),
                ADAdminUsername, ADAdminPassword, AuthenticationTypes.Secure))
            {
                try
                {
                    return de.Properties[DistinguishedName].Value.ToString();
                }
                catch
                {
                    throw new ServiceException($"Group {groupName} doesn't exist in Active Directory");
                }
            }
        }

        /// <summary>
        /// Checks that AD property mapping exists.
        /// </summary>
        /// <param name="propertyKey">The key of the property.</param>
        /// <exception cref="ConfigurationException">
        /// If <c>ADPropertyNameMapping</c> doesn't contain <paramref name="propertyKey"/> key.
        /// </exception>
        private void CheckMapping(string propertyKey)
        {
            if (!ADPropertyNameMapping.ContainsKey(propertyKey))
            {
                throw new ConfigurationException(
                    $"{propertyKey} key is missing in configurable property {nameof(ADPropertyNameMapping)}.");
            }
        }

        /// <summary>
        /// Checks if user can be deleted from mapping table based on its references to assessments and role.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="role">The user role.</param>
        /// <param name="db">The db context.</param>
        /// <exception cref="ServiceException">If user cannot be deleted.</exception>
        /// <remarks>Any other exceptions will be propagated to the caller.</remarks>
        private void CheckReferenceForDelete(string username, Role? role, CustomDbContext db)
        {
            if (role == Role.Owner || role == Role.BUFunctionalApprover)
            {
                // don't check approved assessments, since user cannot be deleted, removing role
                // won't affect the assessments as approved assessments are only read only
                var query = db.AssessmentSet.Where(p => p.ApprovalStatus != ApprovalStatus.Approved);
                var message = "user is approver in";

                //if user role is BUFunctionalApprover check if he is assigned as approver
                // in any assessments in approval work-flow
                if (role == Role.BUFunctionalApprover)
                {
                    query = query.Where(p => (p.DepartmentHead.Name == username
                    || p.FunctionalAreaOwner.Name == username)
                        && p.ApprovalStatus != ApprovalStatus.Draft
                        && p.ApprovalStatus != ApprovalStatus.Rejected);
                }
                else if (role == Role.Owner)
                {
                    // for owner check if he has any assessments submitted
                    query = query.Where(p => p.SubmitterUsername == username);
                    message = "user is submitter of";
                }

                var referencedAssessmentIds = query.Select(p => p.Id).ToList();
                if (referencedAssessmentIds.Count > 0)
                {
                    throw new ServiceException($"The user cannot be deleted because {message} " +
                        $"some active assessments with ids ({string.Join(",", referencedAssessmentIds)})");
                }
            }
        }

        /// <summary>
        /// Checks if the user can be updated without breaking the referenced assessments
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="existing">The existing user detail.</param>
        /// <param name="updating">The user detail to be updated.</param>
        /// <param name="db">The db context</param>
        /// <exception cref="ServiceException">If user cannot be updated.</exception>
        /// <remarks>Any other exceptions will be propagated to the caller.</remarks>
        private void CheckReferenceForUpdate(string username, UserMappingInfo existing,
            UserMappingInfo updating, CustomDbContext db)
        {
            if ((existing.Role == Role.Owner || existing.Role == Role.BUFunctionalApprover)
                && (existing.Role != updating.Role || (existing.IsActive && !updating.IsActive)))
            {
                // don't check approved assessments, since user cannot be deleted, removing role
                // won't affect the assessments as approved assessments are only read only
                var query = db.AssessmentSet.Where(p => p.ApprovalStatus != ApprovalStatus.Approved);
                var message = "user is approver in";
                var roleChangedFrom = "";

                //if user role is BUFunctionalApprover check if he is assigned as approver
                // in any assessments in approval work-flow
                if (existing.Role == Role.BUFunctionalApprover && (updating.Role != Role.BUFunctionalApprover
                || (existing.IsActive && !updating.IsActive)))
                {
                    query = query.Where(p => (p.DepartmentHead.Name == username
                    || p.FunctionalAreaOwner.Name == username)
                        && p.ApprovalStatus != ApprovalStatus.Draft
                        && p.ApprovalStatus != ApprovalStatus.Rejected);
                    roleChangedFrom = "BU Functional Approver";
                }
                else if (existing.Role == Role.Owner && (updating.Role != Role.Owner
                    || (existing.IsActive && !updating.IsActive)))
                {
                    // for owner check if he has any assessments submitted
                    query = query.Where(p => p.SubmitterUsername == username);
                    message = "user is submitter of";
                    roleChangedFrom = "Owner";
                }

                var referencedAssessmentIds = query.Select(p => p.Id).ToList();
                if (referencedAssessmentIds.Count > 0)
                {
                    var ids = string.Join(",", referencedAssessmentIds);
                    if (existing.Role != updating.Role)
                    {
                        throw new ServiceException($"The role of user cannot be changed from {roleChangedFrom}" +
                            $" because {message} in some active assessments with ids ({ids})");
                    }
                    else
                    {
                        throw new ServiceException($"The status of user cannot be changed to inactive" +
                            $" because {message} some active assessments with ids ({ids})");
                    }
                }
            }
        }

        #endregion private methods
    }
}