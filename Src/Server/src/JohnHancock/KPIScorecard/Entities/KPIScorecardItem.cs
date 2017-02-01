/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents KPI scorecard item.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class KPIScorecardItem : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the key performance indicator.
        /// </summary>
        /// <value>
        /// The key performance indicator.
        /// </value>
        public string KeyPerformanceIndicator { get; set; }

        /// <summary>
        /// Gets or sets the service level.
        /// </summary>
        /// <value>
        /// The service level.
        /// </value>
        public DecimalOrPercentageValue ServiceLevel { get; set; }

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        public DecimalOrPercentageValue Threshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether higher value is targeted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if higher value is targeted, <c>false</c>.
        /// </value>
        public bool TargetHigh { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this scorecard is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this scorecard is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the scorecard type.
        /// </summary>
        /// <value>
        /// The scorecard type.
        /// </value>
        public KPIScorecardItemType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIScorecardItem"/> class.
        /// </summary>
        public KPIScorecardItem()
        {
        }
    }
}
