/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the control type.
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
    /// <author>LOY, NightWolf, albertwang, veshu</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class ControlType : LookupEntity
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public Category Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlType"/> class.
        /// </summary>
        public ControlType()
        {
        }
    }
}