/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents business unit KPI Scorecard.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class BusinessUnitKPIScorecard : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the business unit.
        /// </summary>
        /// <value>
        /// The business unit.
        /// </value>
        public BusinessUnit BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public StatusValue Status { get; set; }

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
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the operation performance scores.
        /// </summary>
        /// <value>
        /// The operation performance scores.
        /// </value>
        public IList<KPIVolumeScore> OperationPerformanceScores { get; set; }

        /// <summary>
        /// Gets or sets the financial indicator scores.
        /// </summary>
        /// <value>
        /// The financial indicator scores.
        /// </value>
        public IList<KPIScore> FinancialIndicatorScores { get; set; }

        /// <summary>
        /// Gets or sets the business continuity planning scores.
        /// </summary>
        /// <value>
        /// The business continuity planning scores.
        /// </value>
        public IList<KPIScore> BusinessContinuityPlanningScores { get; set; }

        /// <summary>
        /// Gets or sets the security scores.
        /// </summary>
        /// <value>
        /// The security scores.
        /// </value>
        public IList<KPIScore> SecurityScores { get; set; }

        /// <summary>
        /// Gets or sets the concentration risk scores.
        /// </summary>
        /// <value>
        /// The concentration risk scores.
        /// </value>
        public IList<KPIScore> ConcentrationRiskScores { get; set; }

        /// <summary>
        /// Gets or sets the type of the completion.
        /// </summary>
        /// <value>
        /// The type of the completion.
        /// </value>
        public ScorecardCompletionType CompletionType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitKPIScorecard"/> class.
        /// </summary>
        public BusinessUnitKPIScorecard()
        {
        }
    }
}
