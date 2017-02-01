/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents lookup entity.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class LookupEntity : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupEntity"/> class.
        /// </summary>
        protected LookupEntity()
        {
        }
    }
}
