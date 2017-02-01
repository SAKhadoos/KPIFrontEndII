/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.API.Entities
{
    /// <summary>
    /// Represents the request for reordering the lookup entity.
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
    public class LookupEntityReorderRequest
    {
        /// <summary>
        /// Gets or sets the entity ids.
        /// </summary>
        /// <value>
        /// The entity ids.
        /// </value>
        public long[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the display orders.
        /// </summary>
        /// <value>
        /// The display orders.
        /// </value>
        public int[] DisplayOrders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupEntityReorderRequest"/> class.
        /// </summary>
        public LookupEntityReorderRequest()
        {
        }
    }
}