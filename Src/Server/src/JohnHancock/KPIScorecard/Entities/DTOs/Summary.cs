/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents statistics summary.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class Summary
    {
        /// <summary>
        /// Gets or sets the business unit.
        /// </summary>
        /// <value>
        /// The business unit.
        /// </value>
        public BusinessUnit BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public YearValue Year { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public MonthValue Month { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public StatusValue Status { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the operational incidents number.
        /// </summary>
        /// <value>
        /// The operational incidents number.
        /// </value>
        public int OperationalIncidentsNumber { get; set; }

        /// <summary>
        /// Gets or sets the privacy incidents number.
        /// </summary>
        /// <value>
        /// The privacy incidents number.
        /// </value>
        public int PrivacyIncidentsNumber { get; set; }

        /// <summary>
        /// Gets or sets the audit findings number.
        /// </summary>
        /// <value>
        /// The audit findings number.
        /// </value>
        public int AuditFindingsNumber { get; set; }

        /// <summary>
        /// Gets or sets the operational performance overall score.
        /// </summary>
        /// <value>
        /// The operational performance overall score.
        /// </value>
        public decimal OperationalPerformanceOverallScore { get; set; }

        /// <summary>
        /// Gets or sets the business continuity planning overall score.
        /// </summary>
        /// <value>
        /// The business continuity planning overall score.
        /// </value>
        public decimal BusinessContinuityPlanningOverallScore { get; set; }

        /// <summary>
        /// Gets or sets the security overall score.
        /// </summary>
        /// <value>
        /// The security overall score.
        /// </value>
        public decimal SecurityOverallScore { get; set; }

        /// <summary>
        /// Gets or sets the concentration risk overall score.
        /// </summary>
        /// <value>
        /// The concentration risk overall score.
        /// </value>
        public decimal ConcentrationRiskOverallScore { get; set; }

        /// <summary>
        /// Gets or sets the overall threshold analysis.
        /// </summary>
        /// <value>
        /// The overall threshold analysis.
        /// </value>
        public OverallThresholdAnalysis OverallThresholdAnalysis { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Summary"/> class.
        /// </summary>
        public Summary()
        {
        }
    }
}
