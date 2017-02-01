/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents audit finding search criteria.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class AuditFindingSearchCriteria : BaseSearchCriteria
    {
        /// <summary>
        /// Gets or sets the audit finding number.
        /// </summary>
        /// <value>
        /// The audit finding number.
        /// </value>
        public string AuditFindingNumber { get; set; }

        /// <summary>
        /// Gets or sets the business unit Id.
        /// </summary>
        /// <value>
        /// The business unit Id.
        /// </value>
        public long? BusinessUnitId { get; set; }

        /// <summary>
        /// Gets or sets the audit title.
        /// </summary>
        /// <value>
        /// The audit title.
        /// </value>
        public string AuditTitle { get; set; }

        /// <summary>
        /// Gets or sets the root cause Id.
        /// </summary>
        /// <value>
        /// The root cause Id.
        /// </value>
        public long? RootCauseId { get; set; }

        /// <summary>
        /// Gets or sets the source Id.
        /// </summary>
        /// <value>
        /// The source Id.
        /// </value>
        public long? SourceId { get; set; }

        /// <summary>
        /// Gets or sets the impact Ids.
        /// </summary>
        /// <value>
        /// The impact Ids.
        /// </value>
        public IList<long> ImpactIds { get; set; }

        /// <summary>
        /// Gets or sets the audit year Id.
        /// </summary>
        /// <value>
        /// The audit year Id.
        /// </value>
        public long? AuditYearId { get; set; }

        /// <summary>
        /// Gets or sets the audit month Id.
        /// </summary>
        /// <value>
        /// The audit month Id.
        /// </value>
        public long? AuditMonthId { get; set; }

        /// <summary>
        /// Gets or sets the remediation year Id.
        /// </summary>
        /// <value>
        /// The remediation year Id.
        /// </value>
        public long? RemediationYearId { get; set; }

        /// <summary>
        /// Gets or sets the remediation month Id.
        /// </summary>
        /// <value>
        /// The remediation month Id.
        /// </value>
        public long? RemediationMonthId { get; set; }

        /// <summary>
        /// Gets or sets the status Id.
        /// </summary>
        /// <value>
        /// The status Id.
        /// </value>
        public long? StatusId { get; set; }

        /// <summary>
        /// Gets or sets the reported to ORM year Id.
        /// </summary>
        /// <value>
        /// The reported to ORM year Id.
        /// </value>
        public long? ReportedToORMYearId { get; set; }

        /// <summary>
        /// Gets or sets the reported to ORM month Id.
        /// </summary>
        /// <value>
        /// The reported to ORM month Id.
        /// </value>
        public long? ReportedToORMMonthId { get; set; }

        /// <summary>
        /// Gets or sets the completion types.
        /// </summary>
        /// <value>
        /// The completion types.
        /// </value>
        public IList<ScorecardCompletionType> CompletionTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditFindingSearchCriteria"/> class.
        /// </summary>
        public AuditFindingSearchCriteria()
        {
        }
    }
}
