/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Linq;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using System.Data.Entity;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This service class provides operations for managing privacy incidents.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class PrivacyIncidentService :
        BaseGenericService<PrivacyIncident, PrivacyIncidentSearchCriteria>,
        IPrivacyIncidentService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyIncidentService"/> class.
        /// </summary>
        public PrivacyIncidentService()
        {
        }

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
        public int GetLastTalliedNumber(int year, int month)
        {
            return ProcessWithDb(db =>
            {
                return GetLastTalliedNumber(year, month, "I", db.PrivacyIncidentSet, x => x.IncidentNumber);
            },
            "retrieving last tallied number",
            parameters: new object[] { year, month });
        }

        /// <summary>
        /// Applies filters to the given query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The updated query with applied filters.</returns>
        protected override IQueryable<PrivacyIncident> ConstructQueryConditions(
            IQueryable<PrivacyIncident> query, PrivacyIncidentSearchCriteria criteria)
        {
            if (criteria.BusinessUnitId != null)
            {
                query = query.Where(x => x.BusinessUnit.Id == criteria.BusinessUnitId);
            }

            if (criteria.CompletionTypes?.Count > 0)
            {
                query = query.Where(x => criteria.CompletionTypes.Contains(x.CompletionType));
            }

            if (criteria.IncidentMonthId != null)
            {
                query = query.Where(x => x.IncidentMonth.Id == criteria.IncidentMonthId);
            }

            if (!string.IsNullOrEmpty(criteria.IncidentNumber))
            {
                query = query.Where(x => x.IncidentNumber.Contains(criteria.IncidentNumber));
            }

            if (!string.IsNullOrEmpty(criteria.IncidentTitle))
            {
                query = query.Where(x => x.IncidentTitle.Contains(criteria.IncidentTitle));
            }

            if (criteria.IncidentTypeId != null)
            {
                query = query.Where(x => x.IncidentType.Id == criteria.IncidentTypeId);
            }

            if (criteria.IncidentYearId != null)
            {
                query = query.Where(x => x.IncidentYear.Id == criteria.IncidentYearId);
            }

            if (criteria.MitigationCodeIds?.Count > 0)
            {
                query = query.Where(x => x.MitigationCode.Any(m => criteria.MitigationCodeIds.Contains(m.Id)));
            }

            if (!string.IsNullOrEmpty(criteria.MitigationDetail))
            {
                query = query.Where(x => x.MitigationDetail.Contains(criteria.MitigationDetail));
            }

            if (criteria.NumberOfCustomersImpacted != null)
            {
                query = query.Where(x => x.NumberOfCustomersImpacted == criteria.NumberOfCustomersImpacted);
            }

            if (criteria.RemediationMonthId != null)
            {
                query = query.Where(x => x.RemediationMonth.Id == criteria.RemediationMonthId);
            }

            if (criteria.RemediationYearId != null)
            {
                query = query.Where(x => x.RemediationYear.Id == criteria.RemediationYearId);
            }

            if (criteria.ReportedToORMMonthId != null)
            {
                query = query.Where(x => x.ReportedToORMMonth.Id == criteria.ReportedToORMMonthId);
            }

            if (criteria.ReportedToORMYearId != null)
            {
                query = query.Where(x => x.ReportedToORMYear.Id == criteria.ReportedToORMYearId);
            }

            if (criteria.RootCauseId != null)
            {
                query = query.Where(x => x.RootCause.Id == criteria.RootCauseId);
            }

            if (criteria.StatusId != null)
            {
                query = query.Where(x => x.Status.Id == criteria.StatusId);
            }

            return query;
        }

        /// <summary>
        /// Includes the navigation properties loading for the entity.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The updated query.</returns>
        protected override IQueryable<PrivacyIncident> IncludeNavigationProperties(IQueryable<PrivacyIncident> query)
        {
            return query.Include(x => x.IncidentYear)
                .Include(x => x.IncidentMonth)
                .Include(x => x.IncidentType)
                .Include(x => x.BusinessUnit)
                .Include(x => x.RemediationMonth)
                .Include(x => x.RemediationYear)
                .Include(x => x.ReportedToORMYear)
                .Include(x => x.ReportedToORMMonth)
                .Include(x => x.RootCause)
                .Include(x => x.Status)
                .Include(x => x.MitigationCode);
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
        protected override void ResolveChildEntities(DbContext context, PrivacyIncident entity)
        {
            entity.IncidentYear = ResolveChildEntity(context, entity.IncidentYear);
            entity.IncidentMonth = ResolveChildEntity(context, entity.IncidentMonth);
            entity.IncidentType = ResolveChildEntity(context, entity.IncidentType);
            entity.BusinessUnit = ResolveChildEntity(context, entity.BusinessUnit);
            entity.RemediationYear = ResolveChildEntity(context, entity.RemediationYear);
            entity.RemediationMonth = ResolveChildEntity(context, entity.RemediationMonth);
            entity.ReportedToORMMonth = ResolveChildEntity(context, entity.ReportedToORMMonth);
            entity.ReportedToORMYear = ResolveChildEntity(context, entity.ReportedToORMYear);
            entity.RootCause = ResolveChildEntity(context, entity.RootCause);
            entity.Status = ResolveChildEntity(context, entity.Status);
            ResolveEntities(context, entity.MitigationCode);
        }

        /// <summary>
        /// Updates the <paramref name="existing"/> entity according to <paramref name="newEntity"/> entity.
        /// </summary>
        /// <remarks>Override in child services to update navigation properties.</remarks>
        /// <param name="existing">The existing entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <param name="context">The database context.</param>
        protected override void UpdateEntityFields(
            PrivacyIncident existing, PrivacyIncident newEntity, DbContext context)
        {
            base.UpdateEntityFields(existing, newEntity, context);
            existing.IncidentYear = newEntity.IncidentYear;
            existing.IncidentMonth = newEntity.IncidentMonth;
            existing.IncidentType = newEntity.IncidentType;
            existing.BusinessUnit = newEntity.BusinessUnit;
            existing.RemediationYear = newEntity.RemediationYear;
            existing.RemediationMonth = newEntity.RemediationMonth;
            existing.ReportedToORMMonth = newEntity.ReportedToORMMonth;
            existing.ReportedToORMYear = newEntity.ReportedToORMYear;
            existing.RootCause = newEntity.RootCause;
            existing.Status = newEntity.Status;
            existing.MitigationCode = newEntity.MitigationCode;
        }
    }
}
