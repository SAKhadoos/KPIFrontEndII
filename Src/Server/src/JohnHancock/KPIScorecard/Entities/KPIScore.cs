/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents KPI score.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class KPIScore : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the scorecard item.
        /// </summary>
        /// <value>
        /// The scorecard item.
        /// </value>
        public KPIScorecardItem ScorecardItem { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public decimal Score { get; set; }

        /// <summary>
        /// Gets or sets the low performance reasons.
        /// </summary>
        /// <value>
        /// The low performance reasons.
        /// </value>
        public IList<LowPerformanceReason> LowPerformanceReasons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIScore"/> class.
        /// </summary>
        public KPIScore()
        {
        }
    }
}
