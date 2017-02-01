/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// An enum that represents KPI Scorecard item type.
    /// </summary>
    ///
    /// <threadsafety>
    /// Enum is immutable and thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public enum KPIScorecardItemType
    {
        /// <summary>
        /// Represents operational performance KPI Scorecard type.
        /// </summary>
        OperationPerformance,

        /// <summary>
        /// Represents financial indicator KPI Scorecard type.
        /// </summary>
        FinancialIndicator,

        /// <summary>
        /// Represents business continuity planning KPI Scorecard type.
        /// </summary>
        BusinessContinuityPlanning,

        /// <summary>
        /// Represents security KPI Scorecard type.
        /// </summary>
        Security,

        /// <summary>
        /// Represents concentration risk KPI Scorecard type.
        /// </summary>
        ConcentrationRiskScores
    }
}
