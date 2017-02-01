/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// An enum that represents KPI Scorecard completion type.
    /// </summary>
    ///
    /// <threadsafety>
    /// Enum is immutable and thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public enum ScorecardCompletionType
    {
        /// <summary>
        /// Represents Draft scorecard.
        /// </summary>
        Draft,

        /// <summary>
        /// Represents Completed scorecard.
        /// </summary>
        Completed
    }
}
