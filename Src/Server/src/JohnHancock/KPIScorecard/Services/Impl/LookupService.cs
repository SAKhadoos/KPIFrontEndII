/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using JohnHancock.Common.Services.Impl;
using JohnHancock.KPIScorecard.Impl;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This service class provides operations for retrieving lookup and value entities.
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
    public class LookupService : BasePersistenceService<CustomDbContext>, ILookupService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LookupService"/> class.
        /// </summary>
        public LookupService()
        {
        }

        /// <summary>
        /// Retrieves all lookup entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="type"/> is empty string.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public IList<LookupEntity> GetLookupEntities(string type)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(type, nameof(type));

                switch (type)
                {
                    case nameof(LowPerformanceReason):
                        return AsLookupEntityList<LowPerformanceReason>(db);
                    default:
                        throw new ArgumentException($"'{type}' is not a valid LookupEntity type.");
                }
            },
            "retrieving lookup entities",
            parameters: type);
        }

        /// <summary>
        /// Retrieves all value entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="type"/> is empty string.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public IList<ValueEntity> GetValueEntities(string type)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNullOrEmpty(type, nameof(type));

                switch (type)
                {
                    case nameof(AuditFindingImpactValue):
                        return AsValueEntityList<AuditFindingImpactValue>(db);
                    case nameof(AuditFindingReportedToGORMValue):
                        return AsValueEntityList<AuditFindingReportedToGORMValue>(db);
                    case nameof(AuditFindingRootCauseValue):
                        return AsValueEntityList<AuditFindingRootCauseValue>(db);
                    case nameof(AuditFindingSourceValue):
                        return AsValueEntityList<AuditFindingSourceValue>(db);
                    case nameof(AuditFindingStatusValue):
                        return AsValueEntityList<AuditFindingStatusValue>(db);
                    case nameof(BusinessUnit):
                        return AsValueEntityList<BusinessUnit>(db);
                    case nameof(MonthValue):
                        return AsValueEntityList<MonthValue>(db);
                    case nameof(OperationalIncidentImpactValue):
                        return AsValueEntityList<OperationalIncidentImpactValue>(db);
                    case nameof(OperationalIncidentReportedToGORMValue):
                        return AsValueEntityList<OperationalIncidentReportedToGORMValue>(db);
                    case nameof(OperationalIncidentRootCauseValue):
                        return AsValueEntityList<OperationalIncidentRootCauseValue>(db);
                    case nameof(OperationalIncidentSourceValue):
                        return AsValueEntityList<OperationalIncidentSourceValue>(db);
                    case nameof(OperationalIncidentStatusValue):
                        return AsValueEntityList<OperationalIncidentStatusValue>(db);
                    case nameof(PrivacyIncidentMitigationCodeValue):
                        return AsValueEntityList<PrivacyIncidentMitigationCodeValue>(db);
                    case nameof(PrivacyIncidentRootCauseValue):
                        return AsValueEntityList<PrivacyIncidentRootCauseValue>(db);
                    case nameof(PrivacyIncidentStatusValue):
                        return AsValueEntityList<PrivacyIncidentStatusValue>(db);
                    case nameof(PrivacyIncidentTypeValue):
                        return AsValueEntityList<PrivacyIncidentTypeValue>(db);
                    case nameof(StatusValue):
                        return AsValueEntityList<StatusValue>(db);
                    case nameof(VolumeTypeValue):
                        return AsValueEntityList<VolumeTypeValue>(db);
                    case nameof(YearValue):
                        return AsValueEntityList<YearValue>(db);
                    default:
                        throw new ArgumentException($"'{type}' is not a valid ValueEntity type.");
                }
            },
            "retrieving value entities",
            parameters: type);
        }

        /// <summary>
        /// Gets list of all <typeparamref name="T"/> entities casted to <see cref="LookupEntity"/>.
        /// </summary>
        /// <typeparam name="T">The type of lookup entities to return.</typeparam>
        /// <param name="context">The DB context.</param>
        /// <returns>All <typeparamref name="T"/> entities casted to <see cref="LookupEntity"/>.</returns>
        /// <remarks>All exceptions will be propagated.</remarks>
        private IList<LookupEntity> AsLookupEntityList<T>(CustomDbContext context)
            where T : LookupEntity
        {
            return context.Set<T>().ToList().Cast<LookupEntity>().ToList();
        }

        /// <summary>
        /// Gets list of all <typeparamref name="T"/> entities casted to <see cref="ValueEntity"/>.
        /// </summary>
        /// <typeparam name="T">The type of value entities to return.</typeparam>
        /// <param name="context">The DB context.</param>
        /// <returns>All <typeparamref name="T"/> entities casted to <see cref="ValueEntity"/>.</returns>
        /// <remarks>All exceptions will be propagated.</remarks>
        private IList<ValueEntity> AsValueEntityList<T>(CustomDbContext context)
            where T : ValueEntity
        {
            return context.Set<T>().ToList().Cast<ValueEntity>().ToList();
        }
    }
}
