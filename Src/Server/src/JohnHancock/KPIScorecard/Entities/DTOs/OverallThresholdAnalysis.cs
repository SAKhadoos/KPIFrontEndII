/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents overall threshold analysis.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class OverallThresholdAnalysis
    {
        /// <summary>
        /// Gets or sets the operational performance values.
        /// </summary>
        /// <value>
        /// The operational performance values.
        /// </value>
        public IList<OverallThresholdAnalysisMonthValue> OperationalPerformanceValues { get; set; }

        /// <summary>
        /// Gets or sets the business continuity planning values.
        /// </summary>
        /// <value>
        /// The business continuity planning values.
        /// </value>
        public IList<OverallThresholdAnalysisMonthValue> BusinessContinuityPlanningValues { get; set; }

        /// <summary>
        /// Gets or sets the security values.
        /// </summary>
        /// <value>
        /// The security values.
        /// </value>
        public IList<OverallThresholdAnalysisMonthValue> SecurityValues { get; set; }

        /// <summary>
        /// Gets or sets the concentration risk values.
        /// </summary>
        /// <value>
        /// The concentration risk values.
        /// </value>
        public IList<OverallThresholdAnalysisMonthValue> ConcentrationRiskValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OverallThresholdAnalysis"/> class.
        /// </summary>
        public OverallThresholdAnalysis()
        {
        }
    }
}
