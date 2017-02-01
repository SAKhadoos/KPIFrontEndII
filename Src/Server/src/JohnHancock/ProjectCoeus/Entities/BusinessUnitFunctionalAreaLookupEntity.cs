/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the lookup entity which can depend upon the business unit or
    /// functional area or both.
    /// </summary>
    ///
    /// <remarks>
    /// Note that the properties are implemented without any validation.
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>veshu</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class BusinessUnitFunctionalAreaLookupEntity : LookupEntity
    {
        /// <summary>
        /// Gets or sets the business unit identifier.
        /// </summary>
        /// <value>
        /// The business unit identifier.
        /// </value>
        public long? BusinessUnitId { get; set; }

        /// <summary>
        /// Gets or sets the functional area identifier.
        /// </summary>
        /// <value>
        /// The functional area identifier.
        /// </value>
        public long? FunctionalAreaId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitFunctionalAreaLookupEntity"/> class.
        /// </summary>
        protected BusinessUnitFunctionalAreaLookupEntity()
        {
        }
    }
}