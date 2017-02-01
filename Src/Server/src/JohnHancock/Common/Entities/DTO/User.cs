/*
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 */

using System.Collections.Generic;
using JohnHancock.ProjectCoeus.Entities;

namespace JohnHancock.Common.Entities.DTOs
{
    /// <summary>
    /// An entity class that represents the user.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Note that the properties are implemented without any validation.
    /// </para>
    ///
    /// <para>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Add new property 'Status'
    /// Changes in 1.2:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </para>
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>LOY, NightWolf, TCSASSEMBLER, [es]/TCSASSEMBLER</author>
    /// <version>1.2</version>
    /// <copyright>Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.</copyright>
    public class User
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Coeus role.
        /// </summary>
        /// <value>
        /// The Coeus role.
        /// </value>
        public Role? Role { get; set; }

        /// <summary>
        /// Gets or sets the KPI role.
        /// </summary>
        /// <value>
        /// The KPI role.
        /// </value>
        public Role? KPIRole { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the user is active or not.
        /// </summary>
        /// <value>The flag whether the user is active or not.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the business units.
        /// </summary>
        /// <value>
        /// The business units.
        /// </value>
        public IList<BusinessUnit> BusinessUnits { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }
    }
}