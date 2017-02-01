/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.Common.Entities.DTOs;
using System;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.Common;
using System.Globalization;
using JohnHancock.KPIScorecard.Exceptions;

namespace JohnHancock.KPIScorecard
{
    /// <summary>
    /// This class is the helper class for KPI Scorecard.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is immutable and thread safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    internal static class Helper
    {
        /// <summary>
        /// Represents the draft status value.
        /// </summary>
        private const string DraftStatusValue = "Draft";

        /// <summary>
        /// Validates that the given status is Draft.
        /// </summary>
        /// <param name="status">The status value.</param>
        /// <exception cref="BusinessProcessingException">
        /// If given status is not Draft.
        /// </exception>
        internal static void ValidateStatusIsDraft(ValueEntity status)
        {
            if (status?.Value == DraftStatusValue)
            {
                throw new BusinessProcessingException($"Entity can only be edited in '{DraftStatusValue}' status.");
            }
        }

        /// <summary>
        /// Validates that today is allowed date to perform action based on year, month and allowed input days.
        /// </summary>
        /// <param name="yearValue">The year value.</param>
        /// <param name="monthValue">The month value.</param>
        /// <param name="inputAllowedInDays">The allowed input in days.</param>
        /// <exception cref="BusinessProcessingException">
        /// If current action is forbidden due to restriction of input allowed days.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="yearValue"/> or <paramref name="monthValue"/> is null or cannot be parsed.
        /// </exception>
        internal static void ValidateTodayIsAllowedUpdateDate(
            YearValue yearValue, MonthValue monthValue, int inputAllowedInDays)
        {
            try
            {
                int month = DateTime.ParseExact(monthValue?.Value, "MMMM", CultureInfo.InvariantCulture).Month;
                int year = Convert.ToInt32(yearValue?.Value);
                DateTime maxDate = new DateTime(year, month, 1).AddDays(inputAllowedInDays);
                if (DateTime.Today > maxDate)
                {
                    throw new BusinessProcessingException(
                        "Current action is forbidden due to restriction of input allowed days.");
                }
            }
            catch (BusinessProcessingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    $"Either Year='{yearValue?.Value}' or Month='{monthValue?.Value}' is invalid.", ex);
            }
        }

        /// <summary>
        /// Checks whether the given search criteria is <c>null</c> or incorrect.
        /// </summary>
        ///
        /// <param name="criteria">The search criteria to check.</param>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="criteria"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If criteria.PageNumber or criteria.PageSize is negative.
        /// </exception>
        internal static void CheckSearchCriteria(BaseSearchCriteria criteria)
        {
            CommonHelper.ValidateArgumentNotNull(criteria, nameof(criteria));

            if (criteria.PageNumber < 0)
            {
                throw new ArgumentException("Page number can't be negative.", nameof(criteria));
            }

            if (criteria.PageSize < 0)
            {
                throw new ArgumentException("Page size can't be negative.", nameof(criteria));
            }
        }
    }
}