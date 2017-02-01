/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using JohnHancock.Common;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using Microsoft.Practices.Unity;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This service class provides operation for retrieving summary.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class SummaryService : BaseService, ISummaryService
    {
        /// <summary>
        /// Represents minimum value for exceeding target analysis rating.
        /// </summary>
        private const decimal ExceedingTarget = 2.34m;

        /// <summary>
        /// Represents minimum value for meeting target analysis rating.
        /// </summary>
        private const decimal MeetingTarget = 1.67m;

        /// <summary>
        /// Gets or sets the <see cref="IBusinessUnitKPIScorecardService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for searching corresponding entities.
        /// </remarks>
        ///
        /// <value>The <see cref="IBusinessUnitKPIScorecardService"/> dependency.</value>
        [Dependency]
        public IBusinessUnitKPIScorecardService BusinessUnitKPIScorecardService { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IAuditFindingService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for searching corresponding entities.
        /// </remarks>
        ///
        /// <value>The <see cref="IAuditFindingService"/> dependency.</value>
        [Dependency]
        public IAuditFindingService AuditFindingService { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IOperationalIncidentService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for searching corresponding entities.
        /// </remarks>
        ///
        /// <value>The <see cref="IOperationalIncidentService"/> dependency.</value>
        [Dependency]
        public IOperationalIncidentService OperationalIncidentService { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IPrivacyIncidentService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for searching corresponding entities.
        /// </remarks>
        ///
        /// <value>The <see cref="IPrivacyIncidentService"/> dependency.</value>
        [Dependency]
        public IPrivacyIncidentService PrivacyIncidentService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryService"/> class.
        /// </summary>
        public SummaryService()
        {
        }

        /// <summary>
        /// Checks that all configuration properties were properly initialized.
        /// </summary>
        ///
        /// <exception cref="ConfigurationException">
        /// If any of required injection fields are not injected or have invalid values.
        /// </exception>
        public override void CheckConfiguration()
        {
            base.CheckConfiguration();

            CommonHelper.ValidateConfigPropertyNotNull(BusinessUnitKPIScorecardService,
                nameof(BusinessUnitKPIScorecardService));
            CommonHelper.ValidateConfigPropertyNotNull(AuditFindingService, nameof(AuditFindingService));
            CommonHelper.ValidateConfigPropertyNotNull(OperationalIncidentService, nameof(OperationalIncidentService));
            CommonHelper.ValidateConfigPropertyNotNull(PrivacyIncidentService, nameof(PrivacyIncidentService));
        }

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
        public Summary GetSummary(long businessUnitId, long yearId, long monthId)
        {
            return Logger.Process(() =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                CommonHelper.ValidateArgumentPositive(yearId, nameof(yearId));
                CommonHelper.ValidateArgumentPositive(monthId, nameof(monthId));

                var summary = new Summary();

                // get scorecard for the given parameters
                BusinessUnitKPIScorecard kpiScorecard = BusinessUnitKPIScorecardService.Search(
                    new BusinessUnitKPIScorecardSearchCriteria
                    {
                        BusinessUnitId = businessUnitId,
                        YearId = yearId,
                        MonthId = monthId
                    }).Items.FirstOrDefault();

                if (kpiScorecard == null)
                {
                    // indicate that there is no scorecard for given criteria
                    return null;
                }

                summary.BusinessUnit = kpiScorecard.BusinessUnit;
                summary.Year = kpiScorecard.Year;
                summary.Month = kpiScorecard.Month;
                summary.Status = kpiScorecard.Status;
                summary.DueDate = kpiScorecard.DueDate;

                // Get the number of auditFindings, operationIncidents, and privacyIncidents for the given parameters
                summary.AuditFindingsNumber = AuditFindingService.Search(
                    new AuditFindingSearchCriteria
                    {
                        // (!) Important: use PageNumber=1 and PageSize=0 to get count only,
                        // otherwise there will be huge performance impact due to loading all entities
                        PageNumber = 1,
                        BusinessUnitId = businessUnitId,
                        AuditYearId = yearId,
                        AuditMonthId = monthId,
                    }).TotalRecords;

                summary.OperationalIncidentsNumber = OperationalIncidentService.Search(
                    new OperationalIncidentSearchCriteria
                    {
                        PageNumber = 1,
                        BusinessUnitId = businessUnitId,
                        IncidentYearId = yearId,
                        IncidentMonthId = monthId
                    }).TotalRecords;

                summary.PrivacyIncidentsNumber = PrivacyIncidentService.Search(
                    new PrivacyIncidentSearchCriteria
                    {
                        PageNumber = 1,
                        BusinessUnitId = businessUnitId,
                        IncidentYearId = yearId,
                        IncidentMonthId = monthId
                    }).TotalRecords;

                // calculate overall scores
                summary.OperationalPerformanceOverallScore = GetOverallScore(kpiScorecard.OperationPerformanceScores);
                summary.SecurityOverallScore = GetOverallScore(kpiScorecard.SecurityScores);
                summary.ConcentrationRiskOverallScore = GetOverallScore(kpiScorecard.ConcentrationRiskScores);
                summary.BusinessContinuityPlanningOverallScore =
                    GetOverallScore(kpiScorecard.BusinessContinuityPlanningScores);

                // get scorecards for the whole year
                IList<BusinessUnitKPIScorecard> kpiScorecards = BusinessUnitKPIScorecardService.Search(
                    new BusinessUnitKPIScorecardSearchCriteria
                    {
                        BusinessUnitId = businessUnitId,
                        YearId = yearId
                    }).Items;

                summary.OverallThresholdAnalysis = new OverallThresholdAnalysis
                {
                    OperationalPerformanceValues = new List<OverallThresholdAnalysisMonthValue>(),
                    BusinessContinuityPlanningValues = new List<OverallThresholdAnalysisMonthValue>(),
                    ConcentrationRiskValues = new List<OverallThresholdAnalysisMonthValue>(),
                    SecurityValues = new List<OverallThresholdAnalysisMonthValue>()
                };

                // calculate overall score for every scorecard
                foreach (var scorecard in kpiScorecards)
                {
                    summary.OverallThresholdAnalysis.BusinessContinuityPlanningValues.Add(
                        GetAnalysisMonthValue(scorecard.Month, scorecard.BusinessContinuityPlanningScores));

                    summary.OverallThresholdAnalysis.ConcentrationRiskValues.Add(
                        GetAnalysisMonthValue(scorecard.Month, scorecard.ConcentrationRiskScores));

                    summary.OverallThresholdAnalysis.OperationalPerformanceValues.Add(
                        GetAnalysisMonthValue(scorecard.Month, scorecard.OperationPerformanceScores));

                    summary.OverallThresholdAnalysis.SecurityValues.Add(
                        GetAnalysisMonthValue(scorecard.Month, scorecard.SecurityScores));
                }

                return summary;
            },
            "retrieving summary",
            parameters: new object[] { businessUnitId, yearId, monthId });
        }

        /// <summary>
        /// Gets the analysis month value.
        /// </summary>
        /// <typeparam name="T">The actual type of scores.</typeparam>
        /// <param name="month">The month corresponding to scores.</param>
        /// <param name="scores">The scores.</param>
        /// <returns>The analysis month value.</returns>
        private static OverallThresholdAnalysisMonthValue GetAnalysisMonthValue<T>(MonthValue month, IList<T> scores)
            where T : KPIScore
        {
            var result = new OverallThresholdAnalysisMonthValue();
            result.OverallScore = GetOverallScore(scores);
            result.Month = month;
            if (result.OverallScore >= ExceedingTarget)
            {
                result.Rating = OverallThresholdAnalysisRating.ExceedingTargets;
            }
            else if (result.OverallScore >= MeetingTarget)
            {
                result.Rating = OverallThresholdAnalysisRating.MeetingTargets;
            }
            else
            {
                result.Rating = OverallThresholdAnalysisRating.BelowTargets;
            }
            return result;
        }

        /// <summary>
        /// Gets the overall score.
        /// </summary>
        /// <typeparam name="T">The actual type of scores.</typeparam>
        /// <param name="scores">The scores.</param>
        /// <returns>The overall score.</returns>
        private static decimal GetOverallScore<T>(IList<T> scores)
            where T : KPIScore
        {
            if (scores.Count == 0)
            {
                // indicate that there are no scores
                return 0;
            }

            decimal totalScore = 0;
            foreach (KPIScore score in scores)
            {
                bool targetHigh = score.ScorecardItem.TargetHigh;
                if ((targetHigh && score.Score >= score.ScorecardItem.ServiceLevel.Value)
                    || (!targetHigh && score.Score < score.ScorecardItem.ServiceLevel.Value))
                {
                    totalScore += 3;
                }
                else if ((targetHigh && score.Score >= score.ScorecardItem.Threshold.Value)
                    || (!targetHigh && score.Score < score.ScorecardItem.Threshold.Value))
                {
                    totalScore += 2;
                }
                else
                {
                    totalScore++;
                }
            }

            return totalScore / scores.Count;
        }
    }
}
