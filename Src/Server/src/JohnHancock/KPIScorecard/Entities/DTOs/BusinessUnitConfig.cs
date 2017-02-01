/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents business unit config.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class BusinessUnitConfig
    {
        /// <summary>
        /// Gets or sets the business units.
        /// </summary>
        /// <value>
        /// The business units.
        /// </value>
        public IList<BusinessUnit> BusinessUnits { get; set; }

        /// <summary>
        /// Gets or sets the year configuration.
        /// </summary>
        /// <value>
        /// The year configuration.
        /// </value>
        public IList<YearValue> YearConfig { get; set; }

        /// <summary>
        /// Gets or sets the month configuration.
        /// </summary>
        /// <value>
        /// The month configuration.
        /// </value>
        public IList<MonthValue> MonthConfig { get; set; }

        /// <summary>
        /// Gets or sets the volume type configuration.
        /// </summary>
        /// <value>
        /// The volume type configuration.
        /// </value>
        public IList<VolumeTypeValue> VolumeTypeConfig { get; set; }

        /// <summary>
        /// Gets or sets the status configuration.
        /// </summary>
        /// <value>
        /// The status configuration.
        /// </value>
        public IList<StatusValue> StatusConfig { get; set; }

        /// <summary>
        /// Gets or sets the operation performance configuration.
        /// </summary>
        /// <value>
        /// The operation performance configuration.
        /// </value>
        public IList<KPIScorecardItem> OperationPerformanceConfig { get; set; }

        /// <summary>
        /// Gets or sets the financial indicators configuration.
        /// </summary>
        /// <value>
        /// The financial indicators configuration.
        /// </value>
        public IList<KPIScorecardItem> FinancialIndicatorsConfig { get; set; }

        /// <summary>
        /// Gets or sets the business continuity planning configuration.
        /// </summary>
        /// <value>
        /// The business continuity planning configuration.
        /// </value>
        public IList<KPIScorecardItem> BusinessContinuityPlanningConfig { get; set; }

        /// <summary>
        /// Gets or sets the security configuration.
        /// </summary>
        /// <value>
        /// The security configuration.
        /// </value>
        public IList<KPIScorecardItem> SecurityConfig { get; set; }

        /// <summary>
        /// Gets or sets the concentration risk configuration.
        /// </summary>
        /// <value>
        /// The concentration risk configuration.
        /// </value>
        public IList<KPIScorecardItem> ConcentrationRiskConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitConfig"/> class.
        /// </summary>
        public BusinessUnitConfig()
        {
        }
    }
}
