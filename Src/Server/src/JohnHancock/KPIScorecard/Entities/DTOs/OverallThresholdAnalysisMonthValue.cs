/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents overall threshold analysis month value.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class OverallThresholdAnalysisMonthValue
    {
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public MonthValue Month { get; set; }

        /// <summary>
        /// Gets or sets the overall score.
        /// </summary>
        /// <value>
        /// The overall score.
        /// </value>
        public decimal OverallScore { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public OverallThresholdAnalysisRating Rating { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OverallThresholdAnalysisMonthValue"/> class.
        /// </summary>
        public OverallThresholdAnalysisMonthValue()
        {
        }
    }
}
