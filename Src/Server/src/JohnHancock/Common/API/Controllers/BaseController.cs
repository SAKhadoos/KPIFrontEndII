/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Transactions;
using System.Web.Http;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.Common.API.Controllers
{
    /// <summary>
    /// The base class for all controllers.
    /// </summary>
    /// 
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// - Changes required by 'John Hancock - KPI Scorecard Backend Assembly v1.0' challenge:
    /// https://www.topcoder.com/challenge-details/30056012
    /// </remarks>
    /// 
    /// <author>LOY, NightWolf, veshu, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// Gets the current user from request properties.
        /// </summary>
        ///
        /// <value>
        /// The current user.
        /// </value>
        protected User CurrentUser
        {
            get
            {
                return (User)Request.Properties[CommonHelper.CurrentUserPropertyName];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        protected BaseController()
        {
        }

        /// <summary>
        /// Checks that all configuration properties were properly initialized.
        /// </summary>
        ///
        /// <exception cref="ConfigurationException">
        /// If any of required injection fields are not injected or have invalid values.
        /// </exception>
        public virtual void CheckConfiguration()
        {
        }

        /// <summary>
        /// Updates entity audit fields.
        /// </summary>
        /// <remarks>All exceptions will be propagated to caller method.</remarks>
        /// <param name="entity">The entity to update.</param>
        /// <param name="existing">The existing entity.</param>
        /// <param name="creating">Defines whether entity is being created.</param>
        protected void PopulateAuditFields(AuditableEntity entity,
            AuditableEntity existing = null, bool creating = false)
        {
            DateTime now = DateTime.Now;
            if (creating)
            {
                entity.CreatedBy = CurrentUser.Username;
                entity.CreatedTime = now;
            }
            else if (existing != null)
            {
                entity.CreatedBy = existing.CreatedBy;
                entity.CreatedTime = existing.CreatedTime;
            }

            entity.LastUpdatedBy = CurrentUser.Username;
            entity.LastUpdatedTime = now;
        }

        /// <summary>
        /// Wraps given action with transaction scope.
        /// </summary>
        /// <remarks>All exceptions will be propagated to caller method.</remarks>
        /// <param name="action">The action to execute.</param>
        protected static void WithTransaction(Action action)
        {
            using (var transactionScope = new TransactionScope())
            {
                action();
                transactionScope.Complete();
            }
        }

        /// <summary>
        /// Wraps given function with transaction scope.
        /// </summary>
        /// <remarks>All exceptions will be propagated to caller method.</remarks>
        /// <param name="function">The function to execute.</param>
        /// <returns>Function result.</returns>
        protected static T WithTransaction<T>(Func<T> function)
        {
            using (var transactionScope = new TransactionScope())
            {
                T result = function();
                transactionScope.Complete();
                return result;
            }
        }

        /// <summary>
        /// Gets the value indicating whether current user is admin.
        /// </summary>
        /// <returns>
        /// <c>true</c> current user is admin; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsAdmin()
        {
            return CurrentUser.Role == Role.Admin;
        }
    }
}