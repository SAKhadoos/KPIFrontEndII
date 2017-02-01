/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents audit finding config.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class AuditFindingConfig
    {
        /// <summary>
        /// Gets or sets the root cause configuration.
        /// </summary>
        /// <value>
        /// The root cause configuration.
        /// </value>
        public IList<AuditFindingRootCauseValue> RootCauseConfig { get; set; }

        /// <summary>
        /// Gets or sets the source configuration.
        /// </summary>
        /// <value>
        /// The source configuration.
        /// </value>
        public IList<AuditFindingSourceValue> SourceConfig { get; set; }

        /// <summary>
        /// Gets or sets the impact configuration.
        /// </summary>
        /// <value>
        /// The impact configuration.
        /// </value>
        public IList<AuditFindingImpactValue> ImpactConfig { get; set; }

        /// <summary>
        /// Gets or sets the status configuration.
        /// </summary>
        /// <value>
        /// The status configuration.
        /// </value>
        public IList<AuditFindingStatusValue> StatusConfig { get; set; }

        /// <summary>
        /// Gets or sets the reported to GORM configuration.
        /// </summary>
        /// <value>
        /// The reported to GORM configuration.
        /// </value>
        public IList<AuditFindingReportedToGORMValue> ReportedToGORMConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditFindingConfig"/> class.
        /// </summary>
        public AuditFindingConfig()
        {
        }
    }
}
