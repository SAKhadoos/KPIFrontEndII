/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents KPI Scorecard configuration.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class KPIScorecardConfiguration
    {
        /// <summary>
        /// Gets or sets the business unit.
        /// </summary>
        /// <value>
        /// The business unit.
        /// </value>
        public BusinessUnitConfig BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the operational incident.
        /// </summary>
        /// <value>
        /// The operational incident.
        /// </value>
        public OperationalIncidentConfig OperationalIncident { get; set; }

        /// <summary>
        /// Gets or sets the audit finding.
        /// </summary>
        /// <value>
        /// The audit finding.
        /// </value>
        public AuditFindingConfig AuditFinding { get; set; }

        /// <summary>
        /// Gets or sets the privacy incident.
        /// </summary>
        /// <value>
        /// The privacy incident.
        /// </value>
        public PrivacyIncidentConfig PrivacyIncident { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIScorecardConfiguration"/> class.
        /// </summary>
        public KPIScorecardConfiguration()
        {
        }
    }
}
