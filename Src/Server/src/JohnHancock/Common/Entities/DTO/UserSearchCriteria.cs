/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using System.Collections.Generic;

namespace JohnHancock.Common.Entities.DTOs
{
    /// <summary>
    /// An entity class that represents the user search criteria.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Note that the properties are implemented without any validation.
    /// </para>
    ///
    /// <para>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - inherited from 'BaseSearchCriteria'
    /// - added properties 'Roles', 'Status' and 'BusinessUnitIds'
    /// </para>
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>LOY, NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class UserSearchCriteria : BaseSearchCriteria
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the name of the real.
        /// </summary>
        /// <value>
        /// The name of the real.
        /// </value>
        public string RealName { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public IList<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The flag whether the user is active or not.
        /// <c>null</c> means don't filter with status</value>
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or sets the business unit Ids.
        /// </summary>
        /// <value>
        /// The business units Ids.
        /// </value>
        public IList<long> BusinessUnitIds { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSearchCriteria"/> class.
        /// </summary>
        public UserSearchCriteria()
        {
        }
    }
}