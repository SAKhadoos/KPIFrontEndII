/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Services
{
    /// <summary>
    /// This interface defines operations for managing audit findings.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public interface IAuditFindingService : IGenericService<AuditFinding, AuditFindingSearchCriteria>
    {
        /// <summary>
        /// Gets the last tallied number for the given year and month.
        /// </summary>
        /// <param name="year">The year to match.</param>
        /// <param name="month">The month to match.</param>
        /// <returns>The last tallied number.</returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="year"/> or <paramref name="month"/> is not positive, or month is greater than 12.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        int GetLastTalliedNumber(int year, int month);
    }
}
