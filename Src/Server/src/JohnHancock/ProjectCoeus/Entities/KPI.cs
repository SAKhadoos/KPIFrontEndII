/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the KPI.
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
    /// <author>LOY, NightWolf, albertwang, veshu</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class KPI : LookupEntity
    {
        /// <summary>
        /// Gets or sets the KPICategory.
        /// </summary>
        /// <value>The KPICategory.</value>
        public KPICategory KPICategory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPI"/> class.
        /// </summary>
        public KPI()
        {
        }
    }
}