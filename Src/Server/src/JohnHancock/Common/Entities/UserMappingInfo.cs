/*
*  Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
*/

using System.Collections.Generic;
using JohnHancock.ProjectCoeus.Entities;

namespace JohnHancock.Common.Entities
{
    /// <summary>
    /// <para>
    /// An entity class that represents user mapping informations.
    /// </para>
    ///
    /// <para>
    /// Note that the properties are implemented without any validation.
    /// </para>
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>TCSASSEMBLER, [es]/TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.</copyright>
    public class UserMappingInfo : IdentifiableEntity
    {
        /// <summary>
        /// <para>
        /// Gets or sets the user name.
        /// </para>
        /// </summary>
        /// <value>The user name. It can hold any value.</value>
        public string Username { get; set; }

        /// <summary>
        /// <para>
        /// Gets or sets the user role.
        /// </para>
        /// </summary>
        /// <value>The user role. It can hold any value.</value>
        public Role? Role { get; set; }

        /// <summary>
        /// Gets or sets the KPI role.
        /// </summary>
        /// <value>
        /// The KPI role.
        /// </value>
        public Role? KPIRole { get; set; }

        /// <summary>
        /// <para>
        /// Gets or sets the flag whether the user is active or not.
        /// </para>
        /// </summary>
        /// <value>The flag whether the user is active or not.
        /// It can hold any value.</value>
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the business units.
        /// </summary>
        /// <value>
        /// The business units.
        /// </value>
        public IList<BusinessUnit> BusinessUnits { get; set; }

        /// <summary>
        /// <para>
        /// Initializes a new instance of the <see cref="UserMappingInfo"/> class.
        /// </para>
        /// </summary>
        public UserMappingInfo() { }
    }
}