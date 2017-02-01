/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the functional area.
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
    public class FunctionalArea : BusinessUnitLookupEntity
    {
        /// <summary>
        /// Gets or sets the category (if the business unit is specific to a category only).
        /// </summary>
        /// <value>The category.</value>
        public Category Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalArea"/> class.
        /// </summary>
        public FunctionalArea()
        {
        }
    }
}