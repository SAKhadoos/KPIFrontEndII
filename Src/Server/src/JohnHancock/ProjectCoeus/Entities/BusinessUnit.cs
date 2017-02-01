/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the business unit.
    /// </summary>
    ///
    /// <remarks>
    /// Note that the properties are implemented without any validation.
    ///
    /// Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// Changes in 1.2 during John Hancock - Project Coeus Admin Frontend Assembly Part 1
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>LOY, NightWolf, albertwang, veshu</author>
    /// <version>1.2</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class BusinessUnit : LookupEntity
    {
        /// <summary>
        /// Gets or sets the category (if the business unit is specific to a category only).
        /// </summary>
        /// <value>The category.</value>
        public Category Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnit"/> class.
        /// </summary>
        public BusinessUnit()
        {
        }
    }
}