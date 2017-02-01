/*
*  Copyright (c) 2016, TopCoder, Inc. All rights reserved.
*/

using JohnHancock.Common.Services;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Entities.DTOs;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;

namespace JohnHancock.Common.API.Controllers
{
    /// <summary>
    /// <para>
    /// The controller to expose the operations related to users.
    /// </para>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// This class is immutable (assuming dependencies are not injected more than once) and thread-safe.
    /// </para>
    /// </remarks>
    ///
    /// <author>TCSASSEMBLER</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    [RoutePrefix("api/v1")]
    public class UserController : BaseController
    {
        /// <summary>
        /// <para>
        /// Represents the <see cref="IUserService"/> used in this class.
        /// </para>
        /// </summary>
        /// <value>The <see cref="IUserService"/> instance. It should not be null.</value>
        [Dependency]
        public IUserService UserService
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        public UserController()
        {
        }

        /// <summary>
        /// <para>
        /// Checks whether this instance was properly configured.
        /// </para>
        /// </summary>
        ///
        /// <exception cref="ConfigurationException ">
        /// If there's any error in configuration.
        /// </exception>
        public override void CheckConfiguration()
        {
            base.CheckConfiguration();
            CommonHelper.ValidateConfigPropertyNotNull(UserService, "UserService");
        }

        /// <summary>
        /// Updates an user.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <param name="user">The user to update.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="user"/> argument is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("users/{username}")]
        public void Update(string username, User user)
        {
            CommonHelper.ValidateArgumentNotNull(user, "user");
            // should not make the current login user inactive.
            if (CurrentUser.Username.Equals(username) && !user.IsActive)
            {
                throw new ArgumentException("You can't make inactive yourself.");
            }
            user.Username = username;
            UserService.Update(user);
        }

        /// <summary>
        /// Deletes an user.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("users")]
        public void Delete(string username)
        {
            // should not delete the current login user.
            if (CurrentUser.Username.Equals(username))
            {
                throw new ArgumentException("You can't delete yourself.");
            }
            UserService.Delete(username);
        }

        /// <summary>
        /// Search user.
        /// </summary>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The search result.</returns>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("users")]
        public SearchResult<User> Search([FromUri] UserSearchCriteria criteria)
        {
            criteria = criteria ?? new UserSearchCriteria();
            return UserService.Search(criteria);
        }
    }
}