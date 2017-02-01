/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This service class provides operations for managing business unit KPI scorecards.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>[es], NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class BusinessUnitKPIScorecardService :
        BaseGenericService<BusinessUnitKPIScorecard, BusinessUnitKPIScorecardSearchCriteria>,
        IBusinessUnitKPIScorecardService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitKPIScorecardService"/> class.
        /// </summary>
        public BusinessUnitKPIScorecardService()
        {
        }

        /// <summary>
        /// Applies filters to the given query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The updated query with applied filters.</returns>
        protected override IQueryable<BusinessUnitKPIScorecard> ConstructQueryConditions(
            IQueryable<BusinessUnitKPIScorecard> query, BusinessUnitKPIScorecardSearchCriteria criteria)
        {
            if (criteria.BusinessUnitId != null)
            {
                query = query.Where(x => x.BusinessUnit.Id == criteria.BusinessUnitId);
            }

            if (criteria.CompletionType != null)
            {
                query = query.Where(x => x.CompletionType == criteria.CompletionType);
            }

            if (criteria.DueDate != null)
            {
                query = query.Where(x => x.DueDate == criteria.DueDate);
            }

            if (criteria.MonthId != null)
            {
                query = query.Where(x => x.Month.Id == criteria.MonthId);
            }

            if (criteria.StatusId != null)
            {
                query = query.Where(x => x.Status.Id == criteria.StatusId);
            }

            if (criteria.YearId != null)
            {
                query = query.Where(x => x.Year.Id == criteria.YearId);
            }

            return query;
        }

        /// <summary>
        /// Includes the navigation properties loading for the entity.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The updated query.</returns>
        protected override IQueryable<BusinessUnitKPIScorecard> IncludeNavigationProperties(
            IQueryable<BusinessUnitKPIScorecard> query)
        {
            return query.Include(x => x.BusinessUnit)
                .Include(x => x.Status)
                .Include(x => x.Year)
                .Include(x => x.Month)
                .Include(x => x.OperationPerformanceScores.Select(x1 => x1.VolumeType))
                .Include(x => x.OperationPerformanceScores.Select(x1 => x1.LowPerformanceReasons))
                .Include(x => x.OperationPerformanceScores.Select(x1 => x1.ScorecardItem.ServiceLevel))
                .Include(x => x.OperationPerformanceScores.Select(x1 => x1.ScorecardItem.Threshold))
                .Include(x => x.FinancialIndicatorScores.Select(x1 => x1.LowPerformanceReasons))
                .Include(x => x.FinancialIndicatorScores.Select(x1 => x1.ScorecardItem.ServiceLevel))
                .Include(x => x.FinancialIndicatorScores.Select(x1 => x1.ScorecardItem.Threshold))
                .Include(x => x.BusinessContinuityPlanningScores.Select(x1 => x1.LowPerformanceReasons))
                .Include(x => x.BusinessContinuityPlanningScores.Select(x1 => x1.ScorecardItem.ServiceLevel))
                .Include(x => x.BusinessContinuityPlanningScores.Select(x1 => x1.ScorecardItem.Threshold))
                .Include(x => x.SecurityScores.Select(x1 => x1.LowPerformanceReasons))
                .Include(x => x.SecurityScores.Select(x1 => x1.ScorecardItem.ServiceLevel))
                .Include(x => x.SecurityScores.Select(x1 => x1.ScorecardItem.Threshold))
                .Include(x => x.ConcentrationRiskScores.Select(x1 => x1.LowPerformanceReasons))
                .Include(x => x.ConcentrationRiskScores.Select(x1 => x1.ScorecardItem.ServiceLevel))
                .Include(x => x.ConcentrationRiskScores.Select(x1 => x1.ScorecardItem.Threshold));
        }

        /// <summary>
        /// Updates the child entities by loading them from the database context.
        /// </summary>
        ///
        /// <remarks>
        /// All thrown exceptions will be propagated to caller method.
        /// </remarks>
        ///
        /// <param name="context">The database context.</param>
        /// <param name="entity">The entity to resolve.</param>
        protected override void ResolveChildEntities(DbContext context, BusinessUnitKPIScorecard entity)
        {
            entity.BusinessUnit = ResolveChildEntity(context, entity.BusinessUnit);
            entity.Status = ResolveChildEntity(context, entity.Status);
            entity.Year = ResolveChildEntity(context, entity.Year);
            entity.Month = ResolveChildEntity(context, entity.Month);
            ResolveScores(context, entity.OperationPerformanceScores);
            ResolveScores(context, entity.FinancialIndicatorScores);
            ResolveScores(context, entity.BusinessContinuityPlanningScores);
            ResolveScores(context, entity.SecurityScores);
            ResolveScores(context, entity.ConcentrationRiskScores);
        }

        /// <summary>
        /// Resolves the KPI scores.
        /// </summary>
        /// 
        /// <typeparam name="TScore">The type of the KPI score.</typeparam>
        ///
        /// <remarks>
        /// All thrown exceptions will be propagated to caller method.
        /// </remarks>
        ///
        /// <param name="context">The database context.</param>
        /// <param name="scores">The KPI scores.</param>
        private void ResolveScores<TScore>(DbContext context, IList<TScore> scores)
            where TScore : KPIScore
        {
            if (scores != null)
            {
                foreach (TScore score in scores)
                {
                    // resolve scorecard item and low performance reasons
                    score.ScorecardItem = ResolveChildEntity(context, score.ScorecardItem);
                    ResolveEntities(context, score.LowPerformanceReasons);

                    // resolve volume type in case it is volume score
                    var volumeScore = score as KPIVolumeScore;
                    if (volumeScore != null)
                    {
                        volumeScore.VolumeType = ResolveChildEntity(context, volumeScore.VolumeType);
                    }
                }
            }
        }

        /// <summary>
        /// Updates the <paramref name="existing"/> entity according to <paramref name="newEntity"/> entity.
        /// </summary>
        /// <remarks>Override in child services to update navigation properties.</remarks>
        /// <param name="existing">The existing entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <param name="context">The database context.</param>
        protected override void UpdateEntityFields(BusinessUnitKPIScorecard existing,
            BusinessUnitKPIScorecard newEntity, DbContext context)
        {
            base.UpdateEntityFields(existing, newEntity, context);
            existing.BusinessUnit = newEntity.BusinessUnit;
            existing.Status = newEntity.Status;
            existing.Year = newEntity.Year;
            existing.Month = newEntity.Month;

            // remove existing scores (otherwise they will stay in DB)
            context.Set<KPIVolumeScore>().RemoveRange(existing.OperationPerformanceScores);
            context.Set<KPIScore>().RemoveRange(existing.FinancialIndicatorScores);
            context.Set<KPIScore>().RemoveRange(existing.BusinessContinuityPlanningScores);
            context.Set<KPIScore>().RemoveRange(existing.SecurityScores);
            context.Set<KPIScore>().RemoveRange(existing.ConcentrationRiskScores);

            // set updated scores
            existing.OperationPerformanceScores = newEntity.OperationPerformanceScores;
            existing.FinancialIndicatorScores = newEntity.FinancialIndicatorScores;
            existing.BusinessContinuityPlanningScores = newEntity.BusinessContinuityPlanningScores;
            existing.SecurityScores = newEntity.SecurityScores;
            existing.ConcentrationRiskScores = newEntity.ConcentrationRiskScores;
        }
    }
}
