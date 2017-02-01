/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Services
{
    /// <summary>
    /// This interface defines operations for retrieving summary.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public interface ISummaryService
    {
        /// <summary>
        /// Gets the statistics summary.
        /// </summary>
        /// 
        /// <param name="businessUnitId">The business unit Id to get summary for.</param>
        /// <param name="yearId">The year Id to get summary for.</param>
        /// <param name="monthId">The month Id to get summary for.</param>
        /// <returns>The statistics summary.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// If any of the arguments is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        Summary GetSummary(long businessUnitId, long yearId, long monthId);
    }
}
