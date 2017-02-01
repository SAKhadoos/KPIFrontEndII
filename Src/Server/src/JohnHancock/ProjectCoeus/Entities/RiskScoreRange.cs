/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the risk score range lookup entities.
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
    /// <author>albertwang, veshu</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class RiskScoreRange : LookupEntity
    {
        /// <summary>
        /// Gets or sets the upper bound of the range.
        /// </summary>
        /// <value>The upper bound of the range.</value>
        public decimal? UpperBound { get; set; }

        /// <summary>
        /// Gets or sets the lower bound of the range.
        /// </summary>
        /// <value>The lower bound of the range.</value>
        public decimal? LowerBound { get; set; }

        /// <summary>
        /// Gets or sets the color used to represent the range.
        /// </summary>
        /// <value>The color used to represent the range.</value>
        public string Color { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiskScoreRange"/> class.
        /// </summary>
        public RiskScoreRange()
        {
        }
    }
}