/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using System.Collections.Generic;

namespace JohnHancock.ProjectCoeus.Entities.DTOs
{
    /// <summary>
    /// An entity class that represents the risk report.
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
    public class RiskScore
    {
        /// <summary>
        /// Gets or sets the overall inherent risk score.
        /// </summary>
        /// <value>
        /// The overall inherent risk score.
        /// </value>
        public decimal OverallInherentRiskScore { get; set; }

        /// <summary>
        /// Gets or sets the overall residual risk score.
        /// </summary>
        /// <value>
        /// The overall residual risk score.
        /// </value>
        public decimal OverallResidualRiskScore { get; set; }

        /// <summary>
        /// Gets or sets the inherent risk scores by category.
        /// </summary>
        /// <value>
        /// The inherent risk scores by category.
        /// </value>
        public IList<CategoryRiskScore> CategoryInherentRiskScores { get; set; }

        /// <summary>
        /// Gets or sets the residual risk scores by category.
        /// </summary>
        /// <value>
        /// The residual risk scores by category.
        /// </value>
        public IList<CategoryRiskScore> CategoryResidualRiskScores { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiskScore"/> class.
        /// </summary>
        public RiskScore()
        {
        }
    }
}