/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents privacy incident.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class PrivacyIncident : AuditableEntity
    {
        /// <summary>
        /// Gets or sets the incident number.
        /// </summary>
        /// <value>
        /// The incident number.
        /// </value>
        public string IncidentNumber { get; set; }

        /// <summary>
        /// Gets or sets the business unit.
        /// </summary>
        /// <value>
        /// The business unit.
        /// </value>
        public BusinessUnit BusinessUnit { get; set; }

        /// <summary>
        /// Gets or sets the incident title.
        /// </summary>
        /// <value>
        /// The incident title.
        /// </value>
        public string IncidentTitle { get; set; }

        /// <summary>
        /// Gets or sets the type of the incident.
        /// </summary>
        /// <value>
        /// The type of the incident.
        /// </value>
        public PrivacyIncidentTypeValue IncidentType { get; set; }

        /// <summary>
        /// Gets or sets the root cause.
        /// </summary>
        /// <value>
        /// The root cause.
        /// </value>
        public PrivacyIncidentRootCauseValue RootCause { get; set; }

        /// <summary>
        /// Gets or sets the root cause detail.
        /// </summary>
        /// <value>
        /// The root cause detail.
        /// </value>
        public string RootCauseDetail { get; set; }

        /// <summary>
        /// Gets or sets the number of customers impacted.
        /// </summary>
        /// <value>
        /// The number of customers impacted.
        /// </value>
        public int NumberOfCustomersImpacted { get; set; }

        /// <summary>
        /// Gets or sets the mitigation code.
        /// </summary>
        /// <value>
        /// The mitigation code.
        /// </value>
        public IList<PrivacyIncidentMitigationCodeValue> MitigationCode { get; set; }

        /// <summary>
        /// Gets or sets the mitigation detail.
        /// </summary>
        /// <value>
        /// The mitigation detail.
        /// </value>
        public string MitigationDetail { get; set; }

        /// <summary>
        /// Gets or sets the incident year.
        /// </summary>
        /// <value>
        /// The incident year.
        /// </value>
        public YearValue IncidentYear { get; set; }

        /// <summary>
        /// Gets or sets the incident month.
        /// </summary>
        /// <value>
        /// The incident month.
        /// </value>
        public MonthValue IncidentMonth { get; set; }

        /// <summary>
        /// Gets or sets the remediation year.
        /// </summary>
        /// <value>
        /// The remediation year.
        /// </value>
        public YearValue RemediationYear { get; set; }

        /// <summary>
        /// Gets or sets the remediation month.
        /// </summary>
        /// <value>
        /// The remediation month.
        /// </value>
        public MonthValue RemediationMonth { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public PrivacyIncidentStatusValue Status { get; set; }

        /// <summary>
        /// Gets or sets the reported to ORM year.
        /// </summary>
        /// <value>
        /// The reported to ORM year.
        /// </value>
        public YearValue ReportedToORMYear { get; set; }

        /// <summary>
        /// Gets or sets the reported to ORM month.
        /// </summary>
        /// <value>
        /// The reported to ORM month.
        /// </value>
        public MonthValue ReportedToORMMonth { get; set; }

        /// <summary>
        /// Gets or sets the type of the completion.
        /// </summary>
        /// <value>
        /// The type of the completion.
        /// </value>
        public ScorecardCompletionType CompletionType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyIncident"/> class.
        /// </summary>
        public PrivacyIncident()
        {
        }
    }
}
