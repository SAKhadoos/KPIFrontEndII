/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents operational incident config.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class OperationalIncidentConfig
    {
        /// <summary>
        /// Gets or sets the root cause configuration.
        /// </summary>
        /// <value>
        /// The root cause configuration.
        /// </value>
        public IList<OperationalIncidentRootCauseValue> RootCauseConfig { get; set; }

        /// <summary>
        /// Gets or sets the source configuration.
        /// </summary>
        /// <value>
        /// The source configuration.
        /// </value>
        public IList<OperationalIncidentSourceValue> SourceConfig { get; set; }

        /// <summary>
        /// Gets or sets the impact configuration.
        /// </summary>
        /// <value>
        /// The impact configuration.
        /// </value>
        public IList<OperationalIncidentImpactValue> ImpactConfig { get; set; }

        /// <summary>
        /// Gets or sets the status configuration.
        /// </summary>
        /// <value>
        /// The status configuration.
        /// </value>
        public IList<OperationalIncidentStatusValue> StatusConfig { get; set; }

        /// <summary>
        /// Gets or sets the reported to GORM configuration.
        /// </summary>
        /// <value>
        /// The reported to GORM configuration.
        /// </value>
        public IList<OperationalIncidentReportedToGORMValue> ReportedToGORMConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationalIncidentConfig"/> class.
        /// </summary>
        public OperationalIncidentConfig()
        {
        }
    }
}
