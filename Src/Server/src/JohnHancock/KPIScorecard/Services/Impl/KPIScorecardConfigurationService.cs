/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using JohnHancock.KPIScorecard.Entities.DTOs;
using JohnHancock.KPIScorecard.Impl;
using JohnHancock.Common.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using System.Data.Entity;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This service class provides operations for managing configuration.
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
    public class KPIScorecardConfigurationService : BasePersistenceService<CustomDbContext>,
        IKPIScorecardConfigurationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KPIScorecardConfigurationService"/> class.
        /// </summary>
        public KPIScorecardConfigurationService()
        {
        }

        /// <summary>
        /// Gets the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <returns>The KPI Scorecard configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public KPIScorecardConfiguration GetKPIScorecardConfiguration()
        {
            return Logger.Process(() =>
            {
                return new KPIScorecardConfiguration
                {
                    BusinessUnit = GetBusinessUnitConfiguration(),
                    OperationalIncident = GetOperationalIncidentConfiguration(),
                    AuditFinding = GetAuditFindingConfiguration(),
                    PrivacyIncident = GetPrivacyIncidentConfiguration()
                };
            },
            "retrieving KPI Scorecard configuration");
        }

        /// <summary>
        /// Saves the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <param name="configuration">The KPI Scorecard configuration.</param>
        /// 
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="configuration"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public void SaveKPIScorecardConfiguration(KPIScorecardConfiguration configuration)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(configuration, nameof(configuration));

                // AuditFinding configuration
                var auditFinding = configuration.AuditFinding;
                if (auditFinding != null)
                {
                    UpdateValueEntities(db, auditFinding.ImpactConfig);
                    UpdateValueEntities(db, auditFinding.ReportedToGORMConfig);
                    UpdateValueEntities(db, auditFinding.RootCauseConfig);
                    UpdateValueEntities(db, auditFinding.SourceConfig);
                    UpdateValueEntities(db, auditFinding.StatusConfig);
                }

                // BusinessUnit configuration
                var bu = configuration.BusinessUnit;
                if (bu != null)
                {
                    // value entities
                    UpdateValueEntities(db, bu.BusinessUnits);
                    UpdateValueEntities(db, bu.MonthConfig);
                    UpdateValueEntities(db, bu.StatusConfig);
                    UpdateValueEntities(db, bu.VolumeTypeConfig);
                    UpdateValueEntities(db, bu.YearConfig);

                    // KPIScorecardItem entities
                    UpdateScorecardItemEntities(db, bu.BusinessContinuityPlanningConfig,
                        KPIScorecardItemType.BusinessContinuityPlanning);
                    UpdateScorecardItemEntities(db, bu.ConcentrationRiskConfig,
                        KPIScorecardItemType.ConcentrationRiskScores);
                    UpdateScorecardItemEntities(db, bu.FinancialIndicatorsConfig,
                        KPIScorecardItemType.FinancialIndicator);
                    UpdateScorecardItemEntities(db, bu.OperationPerformanceConfig,
                        KPIScorecardItemType.OperationPerformance);
                    UpdateScorecardItemEntities(db, bu.SecurityConfig,
                        KPIScorecardItemType.Security);
                }

                // OperationalIncident configuration
                var operationalIncident = configuration.OperationalIncident;
                if (operationalIncident != null)
                {
                    UpdateValueEntities(db, operationalIncident.ImpactConfig);
                    UpdateValueEntities(db, operationalIncident.ReportedToGORMConfig);
                    UpdateValueEntities(db, operationalIncident.RootCauseConfig);
                    UpdateValueEntities(db, operationalIncident.SourceConfig);
                    UpdateValueEntities(db, operationalIncident.StatusConfig);
                }

                // PrivacyIncident configuration
                var privacyIncident = configuration.PrivacyIncident;
                if (privacyIncident != null)
                {
                    UpdateValueEntities(db, privacyIncident.MigrationCodeConfig);
                    UpdateValueEntities(db, privacyIncident.RootCauseConfig);
                    UpdateValueEntities(db, privacyIncident.StatusConfig);
                    UpdateValueEntities(db, privacyIncident.TypeConfig);
                }
            },
            "saving KPI Scorecard configuration",
            parameters: configuration,
            saveChanges: true);
        }

        /// <summary>
        /// Gets the operational incident configuration.
        /// </summary>
        /// 
        /// <returns>The operational incident configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public OperationalIncidentConfig GetOperationalIncidentConfiguration()
        {
            return ProcessWithDb(db =>
            {
                return new OperationalIncidentConfig
                {
                    ImpactConfig = db.Set<OperationalIncidentImpactValue>().ToList(),
                    ReportedToGORMConfig = db.Set<OperationalIncidentReportedToGORMValue>().ToList(),
                    RootCauseConfig = db.Set<OperationalIncidentRootCauseValue>().ToList(),
                    SourceConfig = db.Set<OperationalIncidentSourceValue>().ToList(),
                    StatusConfig = db.Set<OperationalIncidentStatusValue>().ToList()
                };
            },
            "retrieving operational incident configuration");
        }

        /// <summary>
        /// Gets the audit finding configuration.
        /// </summary>
        /// 
        /// <returns>The audit finding configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public AuditFindingConfig GetAuditFindingConfiguration()
        {
            return ProcessWithDb(db =>
            {
                return new AuditFindingConfig
                {
                    ImpactConfig = db.Set<AuditFindingImpactValue>().ToList(),
                    ReportedToGORMConfig = db.Set<AuditFindingReportedToGORMValue>().ToList(),
                    RootCauseConfig = db.Set<AuditFindingRootCauseValue>().ToList(),
                    SourceConfig = db.Set<AuditFindingSourceValue>().ToList(),
                    StatusConfig = db.Set<AuditFindingStatusValue>().ToList()
                };
            },
            "retrieving audit finding configuration");
        }

        /// <summary>
        /// Gets the privacy incident configuration.
        /// </summary>
        /// 
        /// <returns>The privacy incident configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public PrivacyIncidentConfig GetPrivacyIncidentConfiguration()
        {
            return ProcessWithDb(db =>
            {
                return new PrivacyIncidentConfig
                {
                    MigrationCodeConfig = db.Set<PrivacyIncidentMitigationCodeValue>().ToList(),
                    RootCauseConfig = db.Set<PrivacyIncidentRootCauseValue>().ToList(),
                    StatusConfig = db.Set<PrivacyIncidentStatusValue>().ToList(),
                    TypeConfig = db.Set<PrivacyIncidentTypeValue>().ToList()
                };
            },
            "retrieving privacy incident configuration");
        }

        /// <summary>
        /// Gets the business unit configuration.
        /// </summary>
        /// 
        /// <returns>The business unit configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public BusinessUnitConfig GetBusinessUnitConfiguration()
        {
            return ProcessWithDb(db =>
            {
                return new BusinessUnitConfig
                {
                    BusinessContinuityPlanningConfig =
                        GetKPIScorecardItems(db, KPIScorecardItemType.BusinessContinuityPlanning),
                    BusinessUnits = db.Set<BusinessUnit>().ToList(),
                    ConcentrationRiskConfig = GetKPIScorecardItems(db, KPIScorecardItemType.ConcentrationRiskScores),
                    FinancialIndicatorsConfig = GetKPIScorecardItems(db, KPIScorecardItemType.FinancialIndicator),
                    MonthConfig = db.Set<MonthValue>().ToList(),
                    OperationPerformanceConfig = GetKPIScorecardItems(db, KPIScorecardItemType.OperationPerformance),
                    SecurityConfig = GetKPIScorecardItems(db, KPIScorecardItemType.Security),
                    StatusConfig = db.Set<StatusValue>().ToList(),
                    VolumeTypeConfig = db.Set<VolumeTypeValue>().ToList(),
                    YearConfig = db.Set<YearValue>().ToList()
                };
            },
            "retrieving business unit configuration");
        }

        /// <summary>
        /// Updates given configuration value entities.
        /// </summary>
        /// <typeparam name="T">The type of the entities.</typeparam>
        /// <param name="db">The DB context.</param>
        /// <param name="updatedItems">The updated items.</param>
        /// <remarks>All exceptions will be propagated.</remarks>
        private static void UpdateValueEntities<T>(CustomDbContext db, IList<T> updatedItems)
            where T : ValueEntity
        {
            UpdateEntities(db, updatedItems, (entities, item) =>
                entities.FirstOrDefault(x => x.Id == item.Id || x.Value == item.Value));
        }

        /// <summary>
        /// Updates configuration entities.
        /// </summary>
        /// <typeparam name="T">The type of the entities.</typeparam>
        /// <param name="db">The DB context.</param>
        /// <param name="updatedItems">The updated items.</param>
        /// <param name="matchDelegate">The function delegate to match entity in provided list of entities.</param>
        /// <remarks>All exceptions will be propagated.</remarks>
        private static void UpdateEntities<T>(CustomDbContext db,
            IList<T> updatedItems, Func<IList<T>, T, T> matchDelegate)
            where T : IdentifiableEntity
        {
            if (updatedItems == null)
            {
                return;
            }

            DbSet<T> set = db.Set<T>();
            IList<T> existingItems = set.ToList();

            foreach (T item in updatedItems)
            {
                T existing = matchDelegate(existingItems, item);
                if (existing == null)
                {
                    // create new
                    set.Add(item);
                }
                else
                {
                    // update existing
                    item.Id = existing.Id;
                    db.Entry(existing).CurrentValues.SetValues(item);
                }
            }

            DeleteMissingEntities(set, existingItems, updatedItems);
        }

        /// <summary>
        /// Updates the scorecard item entities.
        /// </summary>
        /// <param name="db">The DB context.</param>
        /// <param name="updatedItems">The updated items.</param>
        /// <param name="itemType">Type of the scorecard item.</param>
        /// <remarks>All exceptions will be propagated.</remarks>
        private static void UpdateScorecardItemEntities(CustomDbContext db,
            IList<KPIScorecardItem> updatedItems, KPIScorecardItemType itemType)
        {
            if (updatedItems == null)
            {
                return;
            }

            DbSet<KPIScorecardItem> set = db.Set<KPIScorecardItem>();
            IList<KPIScorecardItem> existingItems = set.Include(x => x.ServiceLevel).Include(x => x.Threshold)
                .Where(x => x.Type == itemType).ToList();

            foreach (KPIScorecardItem item in updatedItems)
            {
                item.Type = itemType;

                KPIScorecardItem existing = existingItems.FirstOrDefault(x => x.Id == item.Id);
                if (existing == null)
                {
                    // add new entity
                    set.Add(item);
                }
                else
                {
                    // update existing
                    db.Entry(existing).CurrentValues.SetValues(item);
                    existing.ServiceLevel.CopyValuesFrom(item.ServiceLevel);
                    existing.Threshold.CopyValuesFrom(item.Threshold);
                }
            }

            DeleteMissingEntities(set, existingItems, updatedItems);
        }

        /// <summary>
        /// Deletes entities from existing list which are missing in updated items list.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="set">The DB set of items.</param>
        /// <param name="existingItems">The existing items.</param>
        /// <param name="updatedItems">The updated items.</param>
        /// <remarks>All exceptions will be propagated.</remarks>
        private static void DeleteMissingEntities<T>(DbSet<T> set, IList<T> existingItems, IList<T> updatedItems)
            where T : IdentifiableEntity
        {
            // delete items that are missing in updated list
            foreach (T item in existingItems)
            {
                if (!updatedItems.Any(x => x.Id == item.Id))
                {
                    set.Remove(item);
                }
            }
        }

        /// <summary>
        /// Gets the KPI scorecard items of the given type.
        /// </summary>
        /// <param name="db">The DB context.</param>
        /// <param name="itemType">Type of the KPI scorecard.</param>
        /// <returns>The KPI scorecard items of the given type.</returns>
        /// <remarks>All exceptions will be propagated.</remarks>
        private static IList<KPIScorecardItem> GetKPIScorecardItems(DbContext db, KPIScorecardItemType itemType)
        {
            return db.Set<KPIScorecardItem>()
                .Include(x => x.ServiceLevel)
                .Include(x => x.Threshold)
                .Where(x => x.Type == itemType).ToList();
        }
    }
}
