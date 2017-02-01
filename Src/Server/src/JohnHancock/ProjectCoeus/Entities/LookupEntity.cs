/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.Common.Entities;

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the lookup entity.
    /// </summary>
    ///
    /// <remarks>
    /// Note that the properties are implemented without any validation.
    /// Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>LOY, NightWolf</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class LookupEntity : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order in which the value should be displayed on UI.
        /// </summary>
        /// <value>
        /// The order in which the value should be displayed on UI.
        /// </value>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the value is enabled or not on UI.
        /// </summary>
        /// <value>
        /// The flag whether the value is enabled or not on UI.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the add-on status.
        /// </summary>
        /// <value>
        /// The add-on status.
        /// </value>
        public AddOnStatus AddOnStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupEntity"/> class.
        /// </summary>
        protected LookupEntity()
        {
        }
    }
}