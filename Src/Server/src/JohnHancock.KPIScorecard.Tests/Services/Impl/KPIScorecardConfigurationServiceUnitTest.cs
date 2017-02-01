/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnHancock.KPIScorecard.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Tests.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="KPIScorecardConfigurationService"/> class.
    /// </summary>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>
    /// Copyright (c) 2017, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class KPIScorecardConfigurationServiceUnitTest : BaseServiceUnitTest<KPIScorecardConfigurationService>
    {
        #region GetKPIScorecardConfiguration() method tests

        /// <summary>
        /// Accuracy test of <c>GetKPIScorecardConfiguration</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetKPIScorecardConfigurationAccuracy()
        {
            // act
            KPIScorecardConfiguration result = instance.GetKPIScorecardConfiguration();

            // assert
            AssertResult(result);
        }

        #endregion

        #region GetOperationalIncidentConfiguration() method tests

        /// <summary>
        /// Accuracy test of <c>GetOperationalIncidentConfiguration</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetOperationalIncidentConfigurationAccuracy()
        {
            // act
            OperationalIncidentConfig result = instance.GetOperationalIncidentConfiguration();

            // assert
            AssertResult(result);
        }

        #endregion

        #region GetAuditFindingConfiguration() method tests

        /// <summary>
        /// Accuracy test of <c>GetAuditFindingConfiguration</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAuditFindingConfigurationAccuracy()
        {
            // act
            AuditFindingConfig result = instance.GetAuditFindingConfiguration();

            // assert
            AssertResult(result);
        }

        #endregion

        #region GetPrivacyIncidentConfiguration() method tests

        /// <summary>
        /// Accuracy test of <c>GetPrivacyIncidentConfiguration</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetPrivacyIncidentConfigurationAccuracy()
        {
            // act
            PrivacyIncidentConfig result = instance.GetPrivacyIncidentConfiguration();

            // assert
            AssertResult(result);
        }

        #endregion

        #region GetBusinessUnitConfiguration() method tests

        /// <summary>
        /// Accuracy test of <c>GetBusinessUnitConfiguration</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetBusinessUnitConfigurationAccuracy()
        {
            // act
            BusinessUnitConfig result = instance.GetBusinessUnitConfiguration();

            // assert
            AssertResult(result);
        }

        #endregion

        #region SaveKPIScorecardConfiguration(KPIScorecardConfiguration) method tests

        /// <summary>
        /// Accuracy test of <c>SaveKPIScorecardConfiguration</c> method,
        /// no exception is expected to be thrown.
        /// </summary>
        [TestMethod]
        public void TestSaveKPIScorecardConfigurationAccuracy()
        {
            // arrange
            KPIScorecardConfiguration configuration = CreateTestEntity<KPIScorecardConfiguration>(9, 3);
            KPIScorecardConfiguration existing = instance.GetKPIScorecardConfiguration();

            // update AuditFinding config
            existing.AuditFinding.ImpactConfig[0].Id = 0;
            ReplaceLastTwoItems(existing.AuditFinding.ImpactConfig, configuration.AuditFinding.ImpactConfig);
            ReplaceLastTwoItems(existing.AuditFinding.ReportedToGORMConfig,
                configuration.AuditFinding.ReportedToGORMConfig);
            ReplaceLastTwoItems(existing.AuditFinding.RootCauseConfig, configuration.AuditFinding.RootCauseConfig);
            ReplaceLastTwoItems(existing.AuditFinding.SourceConfig, configuration.AuditFinding.SourceConfig);
            ReplaceLastTwoItems(existing.AuditFinding.StatusConfig, configuration.AuditFinding.StatusConfig);

            // update BusinessUnit config
            ReplaceLastTwoItems(existing.BusinessUnit.BusinessContinuityPlanningConfig,
                configuration.BusinessUnit.BusinessContinuityPlanningConfig);
            existing.BusinessUnit.BusinessUnits[0].Id = 0;
            ReplaceLastTwoItems(existing.BusinessUnit.BusinessUnits,
                configuration.BusinessUnit.BusinessUnits);
            ReplaceLastTwoItems(existing.BusinessUnit.ConcentrationRiskConfig,
                configuration.BusinessUnit.ConcentrationRiskConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.FinancialIndicatorsConfig,
                configuration.BusinessUnit.FinancialIndicatorsConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.MonthConfig, configuration.BusinessUnit.MonthConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.OperationPerformanceConfig,
                configuration.BusinessUnit.OperationPerformanceConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.SecurityConfig, configuration.BusinessUnit.SecurityConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.StatusConfig, configuration.BusinessUnit.StatusConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.VolumeTypeConfig, configuration.BusinessUnit.VolumeTypeConfig);
            ReplaceLastTwoItems(existing.BusinessUnit.YearConfig, configuration.BusinessUnit.YearConfig);

            // update OperationalIncident config
            existing.OperationalIncident.ImpactConfig[0].Id = 0;
            ReplaceLastTwoItems(existing.OperationalIncident.ImpactConfig,
                configuration.OperationalIncident.ImpactConfig);
            ReplaceLastTwoItems(existing.OperationalIncident.ReportedToGORMConfig,
                configuration.OperationalIncident.ReportedToGORMConfig);
            ReplaceLastTwoItems(existing.OperationalIncident.RootCauseConfig,
                configuration.OperationalIncident.RootCauseConfig);
            ReplaceLastTwoItems(existing.OperationalIncident.SourceConfig,
                configuration.OperationalIncident.SourceConfig);
            ReplaceLastTwoItems(existing.OperationalIncident.StatusConfig,
                configuration.OperationalIncident.StatusConfig);

            // update PrivacyIncident config
            existing.PrivacyIncident.MigrationCodeConfig[0].Id = 0;
            ReplaceLastTwoItems(existing.PrivacyIncident.MigrationCodeConfig,
                configuration.PrivacyIncident.MigrationCodeConfig);
            ReplaceLastTwoItems(existing.PrivacyIncident.RootCauseConfig,
                configuration.PrivacyIncident.RootCauseConfig);
            ReplaceLastTwoItems(existing.PrivacyIncident.StatusConfig, configuration.PrivacyIncident.StatusConfig);
            ReplaceLastTwoItems(existing.PrivacyIncident.TypeConfig, configuration.PrivacyIncident.TypeConfig);

            // act
            instance.SaveKPIScorecardConfiguration(existing);

            // assert
            AssertValueEntitiesExist(existing.AuditFinding.ImpactConfig);
            AssertValueEntitiesExist(existing.AuditFinding.ReportedToGORMConfig);
            AssertValueEntitiesExist(existing.AuditFinding.RootCauseConfig);
            AssertValueEntitiesExist(existing.AuditFinding.SourceConfig);
            AssertValueEntitiesExist(existing.AuditFinding.StatusConfig);

            AssertValueEntitiesExist(existing.BusinessUnit.MonthConfig);
            AssertValueEntitiesExist(existing.BusinessUnit.StatusConfig);
            AssertValueEntitiesExist(existing.BusinessUnit.VolumeTypeConfig);
            AssertValueEntitiesExist(existing.BusinessUnit.YearConfig);
            AssertValueEntitiesExist(existing.BusinessUnit.BusinessUnits);
            AssertKPIScorecardItemEntitiesExist(existing.BusinessUnit.BusinessContinuityPlanningConfig);
            AssertKPIScorecardItemEntitiesExist(existing.BusinessUnit.ConcentrationRiskConfig);
            AssertKPIScorecardItemEntitiesExist(existing.BusinessUnit.FinancialIndicatorsConfig);
            AssertKPIScorecardItemEntitiesExist(existing.BusinessUnit.OperationPerformanceConfig);
            AssertKPIScorecardItemEntitiesExist(existing.BusinessUnit.SecurityConfig);

            AssertValueEntitiesExist(existing.OperationalIncident.ImpactConfig);
            AssertValueEntitiesExist(existing.OperationalIncident.ReportedToGORMConfig);
            AssertValueEntitiesExist(existing.OperationalIncident.RootCauseConfig);
            AssertValueEntitiesExist(existing.OperationalIncident.SourceConfig);
            AssertValueEntitiesExist(existing.OperationalIncident.StatusConfig);

            AssertValueEntitiesExist(existing.PrivacyIncident.MigrationCodeConfig);
            AssertValueEntitiesExist(existing.PrivacyIncident.RootCauseConfig);
            AssertValueEntitiesExist(existing.PrivacyIncident.StatusConfig);
            AssertValueEntitiesExist(existing.PrivacyIncident.TypeConfig);
        }

        /// <summary>
        /// Replaces the last two items in the given list with new items.
        /// </summary>
        /// <typeparam name="T">The type of entities.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="newItems">The new items.</param>
        private static void ReplaceLastTwoItems<T>(IList<T> items, IList<T> newItems)
            where T : IdentifiableEntity
        {
            if (items.Count > 11)
            {
                items.Remove(items.Last());
                items.Remove(items.Last());
                items.Remove(items.Last());
            }

            if (items.Count > 8)
            {
                items.Remove(items.Last());
            }

            var last = items.Last();
            items.Remove(last);

            newItems[0].Id = last.Id;
            foreach (var item in newItems)
            {
                items.Add(item);
            }
        }

        /// <summary>
        /// Asserts that given value entities exist in DB.
        /// </summary>
        /// <typeparam name="T">The type of value entities.</typeparam>
        /// <param name="items">The items to check for existence.</param>
        private static void AssertValueEntitiesExist<T>(IList<T> items)
            where T : ValueEntity
        {
            var parameters = new Dictionary<string, object> { };
            TestHelper.AssertDatabaseRecordCount("KST_" + typeof(T).Name, parameters, items.Count);
            foreach (var item in items)
            {
                parameters["Id"] = item.Id;
                parameters["Value"] = item.Value;
                parameters["Enabled"] = item.Enabled;
                TestHelper.AssertDatabaseRecordExists(typeof(T).Name, parameters);
            }
        }

        /// <summary>
        /// Asserts that given lookup entities exist in DB.
        /// </summary>
        /// <typeparam name="T">The type of lookup entities.</typeparam>
        /// <param name="items">The items to check for existence.</param>
        private static void AssertLookupEntitiesExist<T>(IList<T> items)
            where T : LookupEntity
        {
            var parameters = new Dictionary<string, object> { };
            TestHelper.AssertDatabaseRecordCount("KST_" + typeof(T).Name, parameters, items.Count);
            foreach (var item in items)
            {
                parameters["Id"] = item.Id;
                parameters["Name"] = item.Name;
                TestHelper.AssertDatabaseRecordExists(typeof(T).Name, parameters);
            }
        }

        /// <summary>
        /// Asserts that given KPI scorecard item entities exist in DB.
        /// </summary>
        /// <param name="items">The items to check for existence.</param>
        private static void AssertKPIScorecardItemEntitiesExist(IList<KPIScorecardItem> items)
        {
            var parameters = new Dictionary<string, object> { };
            parameters["Type"] = items[0].Type;

            TestHelper.AssertDatabaseRecordCount("KST_" + nameof(KPIScorecardItem), parameters, items.Count);
            foreach (var item in items)
            {
                parameters["Enabled"] = item.Enabled;
                parameters["KeyPerformanceIndicator"] = item.KeyPerformanceIndicator;
                parameters["TargetHigh"] = item.TargetHigh;
                parameters["Type"] = item.Type;
                TestHelper.AssertDatabaseRecordExists(nameof(KPIScorecardItem), parameters);
            }
        }

        #endregion
    }
}
