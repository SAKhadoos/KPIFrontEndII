/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents business unit scorecard search criteria.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class BusinessUnitKPIScorecardSearchCriteria : BaseSearchCriteria
    {
        /// <summary>
        /// Gets or sets the business unit Id.
        /// </summary>
        /// <value>
        /// The business unit Id.
        /// </value>
        public long? BusinessUnitId { get; set; }

        /// <summary>
        /// Gets or sets the status Id.
        /// </summary>
        /// <value>
        /// The status Id.
        /// </value>
        public long? StatusId { get; set; }

        /// <summary>
        /// Gets or sets the year Id.
        /// </summary>
        /// <value>
        /// The year Id.
        /// </value>
        public long? YearId { get; set; }

        /// <summary>
        /// Gets or sets the month Id.
        /// </summary>
        /// <value>
        /// The month Id.
        /// </value>
        public long? MonthId { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the completion.
        /// </summary>
        /// <value>
        /// The type of the completion.
        /// </value>
        public ScorecardCompletionType? CompletionType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitKPIScorecardSearchCriteria"/> class.
        /// </summary>
        public BusinessUnitKPIScorecardSearchCriteria()
        {
        }
    }
}
