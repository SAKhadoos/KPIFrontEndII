/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace JohnHancock.KPIScorecard.Tests
{
    /// <summary>
    /// Represents base class for testing services that are inherited from <see cref="BaseService"/>.
    /// </summary>
    ///
    /// <typeparam name="TService">The actual type of the service being tested.</typeparam>
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
    public abstract class BaseServiceUnitTest<TService>
        where TService : BaseService, new()
    {
        /// <summary>
        /// Represents the service instance used for tests.
        /// </summary>
        protected TService instance = TestHelper.UnityContainer.Resolve<TService>();

        /// <summary>
        /// Sets up the environment before executing each test in this class.
        /// </summary>
        [TestInitialize]
        public virtual void SetUp()
        {
            TestHelper.FillDatabase();
        }

        /// <summary>
        /// Sets up the environment after executing each test in this class.
        /// </summary>
        [TestCleanup]
        public virtual void CleanUp()
        {
            TestHelper.ClearDatabase();
        }

        /// <summary>
        /// Accuracy test of <c>CheckConfiguration</c> method,
        /// should not throw exceptions.
        /// </summary>
        [TestMethod]
        public void TestCheckConfigurationAccuracy()
        {
            // act
            instance.CheckConfiguration();
        }

        /// <summary>
        /// Compares actual test result with the expected result in JSON format.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="testName">Name of the test.</param>
        protected void AssertResult<T>(T result, [CallerMemberName]string testName = null)
        {
            bool develop = false;
            if (develop)
            {
                if (!Directory.Exists(TestHelper.TestResultsPath))
                {
                    Directory.CreateDirectory(TestHelper.TestResultsPath);
                }

                string jsonResult = JsonConvert.SerializeObject(result, TestHelper.SerializerSettings);

                string filePath = Path.Combine(TestHelper.TestResultsPath, $"{GetType().Name}.{testName}.json");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, jsonResult);
                }
                else
                {
                    string existing = File.ReadAllText(filePath);
                    if (jsonResult != existing)
                    {
                        File.WriteAllText(filePath, jsonResult);
                        Assert.Fail("mismatch");
                    }
                }
            }
            else
            {
                string filePath = Path.Combine(TestHelper.TestResultsPath, $"{GetType().Name}.{testName}.json");
                string expected = File.ReadAllText(filePath);
                string actual = JsonConvert.SerializeObject(result, TestHelper.SerializerSettings);
                Assert.AreEqual(expected, actual, "Mismatch in actual and expected result when serialized to JSON.");
            }
        }

        #region test entities

        /// <summary>
        /// Creates entity of the given type with the properties populated based on the seed value.
        /// </summary>
        /// <typeparam name="T">The type of the entity to create.</typeparam>
        /// <param name="seed">The seed.</param>
        /// <param name="listCount">Number of items to add to lists.</param>
        /// <returns>Test entity.</returns>
        protected static T CreateTestEntity<T>(int seed = 1, int listCount = 2)
            where T : new()
        {
            return (T)CreateTestEntity(typeof(T), seed, 1, listCount);
        }

        /// <summary>
        /// Creates entity of the given type with the properties populated based on the seed value.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="depth">The current depth in entity generation.</param>
        /// <param name="listCount">Number of items to add to lists.</param>
        /// <returns>Created entity.</returns>
        private static object CreateTestEntity(Type entityType, int seed, int depth, int listCount)
        {
            if (depth > 4)
            {
                return null;
            }

            object result = Activator.CreateInstance(entityType);
            IEnumerable<PropertyInfo> properties = entityType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanWrite);

            int incremental = 0;
            foreach (PropertyInfo property in properties)
            {
                incremental++;
                object value = CreateTestInstance(property.PropertyType, seed, incremental, depth, listCount, property.Name);
                property.SetValue(result, value);
            }

            var identifiable = result as IdentifiableEntity;
            if (identifiable != null)
            {
                identifiable.Id = seed;
            }

            return result;
        }

        /// <summary>
        /// Creates instance of the given type with the properties populated based on the seed and incremental values.
        /// </summary>
        /// <param name="type">The type of the instance to create.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="incremental">The incremental.</param>
        /// <param name="depth">The current depth in entity generation.</param>
        /// <param name="listCount">Number of items to add to lists.</param>
        /// <param name="name">The optional value to set for string types.</param>
        /// <returns>Created instance.</returns>
        private static object CreateTestInstance(Type type,
            int seed, int incremental, int depth, int listCount, string name = null)
        {
            if (type.Namespace.StartsWith(typeof(BusinessUnit).Namespace))
            {
                return CreateTestEntity(type, seed, depth + 1, listCount);
            }

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                if (seed % 3 == 2)
                {
                    return null;
                }

                type = type.GenericTypeArguments[0];
            }

            if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                Type typeArgument = type.GenericTypeArguments[0];
                var listType = typeof(List<>).MakeGenericType(typeArgument);
                var list = Activator.CreateInstance(listType);
                MethodInfo addMethod = listType.GetMethod("Add");
                for (int i = 0; i < listCount; i++)
                {
                    object item = CreateTestInstance(
                        typeArgument, seed + i, incremental + i + 1, depth, listCount);
                    addMethod.Invoke(list, new[] { item });
                }
                return list;
            }

            if (type == typeof(string))
            {
                return $"{name}_{seed}";
            }

            if (type == typeof(long) || type == typeof(int))
            {
                return seed * 10 + incremental;
            }

            if (type == typeof(decimal))
            {
                return seed * 1.23m + incremental;
            }

            if (type == typeof(bool))
            {
                return seed % 2 == 1;
            }

            if (type == typeof(DateTime))
            {
                return CreateTestDate(incremental);
            }

            if (type.IsEnum)
            {
                var values = Enum.GetValues(type);
                return values.GetValue(seed % values.Length);
            }

            throw new NotSupportedException($"Type {type.Name} not supported.");
        }

        /// <summary>
        /// Creates random date based on <paramref name="seed"/>.
        /// </summary>
        /// <param name="seed">The seed.</param>
        /// <returns>The random test date.</returns>
        private static DateTime CreateTestDate(int seed)
        {
            int year = 2000 + seed;
            int month = seed % 12 + 1;
            int day = seed % 28 + 1;
            return new DateTime(year, month, day);
        }

        #endregion

        #region check whether entity exists in DB

        /// <summary>
        /// Asserts that the given entity exists in DB.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        protected static void AssertEntityExists(AuditFinding entity)
        {
            var parameters = new Dictionary<string, object>();
            parameters["AuditFindingNumber"] = entity.AuditFindingNumber;
            parameters["BusinessUnit_Id"] = entity.BusinessUnit?.Id;
            parameters["AuditTitle"] = entity.AuditTitle;
            parameters["RootCause_Id"] = entity.RootCause?.Id;
            parameters["RootCauseDetail"] = entity.RootCauseDetail;
            parameters["Source_Id"] = entity.Source?.Id;
            parameters["MitigationStrategy"] = entity.MitigationStrategy;
            parameters["AuditYear_Id"] = entity.AuditYear?.Id;
            parameters["AuditMonth_Id"] = entity.AuditMonth?.Id;
            parameters["RemediationYear_Id"] = entity.RemediationYear?.Id;
            parameters["RemediationMonth_Id"] = entity.RemediationMonth?.Id;
            parameters["Status_Id"] = entity.Status?.Id;
            parameters["ReportedToGORM_Id"] = entity.ReportedToGORM?.Id;
            parameters["ReportedToORMYear_Id"] = entity.ReportedToORMYear?.Id;
            parameters["ReportedToORMMonth_Id"] = entity.ReportedToORMMonth?.Id;
            parameters["CompletionType"] = entity.CompletionType;
            parameters["CreatedBy"] = entity.CreatedBy;
            parameters["CreatedTime"] = entity.CreatedTime;
            parameters["LastUpdatedBy"] = entity.LastUpdatedBy;
            parameters["LastUpdatedTime"] = entity.LastUpdatedTime;
            parameters["Id"] = entity.Id;

            TestHelper.AssertDatabaseRecordExists(typeof(AuditFinding).Name, parameters);

            AssertManyToManyMappings(entity.Id, entity.Impact,
                "AuditFinding_AuditFindingImpactValue",
                "AuditFindingId", "AuditFindingImpactValueId");
        }

        /// <summary>
        /// Asserts that the given entity exists in DB.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        protected static void AssertEntityExists(BusinessUnitKPIScorecard entity)
        {
            var parameters = new Dictionary<string, object>();
            parameters["BusinessUnit_Id"] = entity.BusinessUnit?.Id;
            parameters["Status_Id"] = entity.Status?.Id;
            parameters["Year_Id"] = entity.Year?.Id;
            parameters["Month_Id"] = entity.Month?.Id;
            parameters["DueDate"] = entity.DueDate;
            parameters["CompletionType"] = entity.CompletionType;
            parameters["CreatedBy"] = entity.CreatedBy;
            parameters["CreatedTime"] = entity.CreatedTime;
            parameters["LastUpdatedBy"] = entity.LastUpdatedBy;
            parameters["LastUpdatedTime"] = entity.LastUpdatedTime;
            parameters["Id"] = entity.Id;

            TestHelper.AssertDatabaseRecordExists(typeof(BusinessUnitKPIScorecard).Name, parameters);

            AssertManyToManyMappings(entity.Id, entity.OperationPerformanceScores,
                "BusinessUnitKPIScorecard_OperationPerformanceScore",
                "BusinessUnitKPIScorecardId", "KPIVolumeScoreId");

            AssertManyToManyMappings(entity.Id, entity.FinancialIndicatorScores,
                "BusinessUnitKPIScorecard_FinancialIndicatorScore",
                "BusinessUnitKPIScorecardId", "KPIScoreId");

            AssertManyToManyMappings(entity.Id, entity.BusinessContinuityPlanningScores,
                "BusinessUnitKPIScorecard_BusinessContinuityPlanningScore",
                "BusinessUnitKPIScorecardId", "KPIScoreId");

            AssertManyToManyMappings(entity.Id, entity.SecurityScores,
                "BusinessUnitKPIScorecard_SecurityScore",
                "BusinessUnitKPIScorecardId", "KPIScoreId");

            AssertManyToManyMappings(entity.Id, entity.ConcentrationRiskScores,
                "BusinessUnitKPIScorecard_ConcentrationRiskScore",
                "BusinessUnitKPIScorecardId", "KPIScoreId");
        }

        /// <summary>
        /// Asserts that the given entity exists in DB.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        protected static void AssertEntityExists(OperationalIncident entity)
        {
            var parameters = new Dictionary<string, object>();
            parameters["IncidentNumber"] = entity.IncidentNumber;
            parameters["BusinessUnit_Id"] = entity.BusinessUnit?.Id;
            parameters["OperationalFinding"] = entity.OperationalFinding;
            parameters["RootCause_Id"] = entity.RootCause?.Id;
            parameters["RootCauseDetail"] = entity.RootCauseDetail;
            parameters["FinancialExposure_Id"] = entity.FinancialExposure?.Id;
            parameters["Source_Id"] = entity.Source?.Id;
            parameters["MitigationStrategy"] = entity.MitigationStrategy;
            parameters["IncidentYear_Id"] = entity.IncidentYear?.Id;
            parameters["IncidentMonth_Id"] = entity.IncidentMonth?.Id;
            parameters["RemediationYear_Id"] = entity.RemediationYear?.Id;
            parameters["RemediationMonth_Id"] = entity.RemediationMonth?.Id;
            parameters["Status_Id"] = entity.Status?.Id;
            parameters["ReportedToGORM_Id"] = entity.ReportedToGORM?.Id;
            parameters["ReportedToORMYear_Id"] = entity.ReportedToORMYear?.Id;
            parameters["ReportedToORMMonth_Id"] = entity.ReportedToORMMonth?.Id;
            parameters["CompletionType"] = entity.CompletionType;
            parameters["CreatedBy"] = entity.CreatedBy;
            parameters["CreatedTime"] = entity.CreatedTime;
            parameters["LastUpdatedBy"] = entity.LastUpdatedBy;
            parameters["LastUpdatedTime"] = entity.LastUpdatedTime;
            parameters["Id"] = entity.Id;

            TestHelper.AssertDatabaseRecordExists(typeof(OperationalIncident).Name, parameters);

            AssertManyToManyMappings(entity.Id, entity.Impact,
                "OperationalIncident_OperationalIncidentImpactValue",
                "OperationalIncidentId", "OperationalIncidentImpactValueId");
        }

        /// <summary>
        /// Asserts that the given entity exists in DB.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        protected static void AssertEntityExists(PrivacyIncident entity)
        {
            var parameters = new Dictionary<string, object>();
            parameters["IncidentNumber"] = entity.IncidentNumber;
            parameters["BusinessUnit_Id"] = entity.BusinessUnit?.Id;
            parameters["IncidentTitle"] = entity.IncidentTitle;
            parameters["IncidentType_Id"] = entity.IncidentType?.Id;
            parameters["RootCause_Id"] = entity.RootCause?.Id;
            parameters["RootCauseDetail"] = entity.RootCauseDetail;
            parameters["NumberOfCustomersImpacted"] = entity.NumberOfCustomersImpacted;
            parameters["MitigationDetail"] = entity.MitigationDetail;
            parameters["IncidentYear_Id"] = entity.IncidentYear?.Id;
            parameters["IncidentMonth_Id"] = entity.IncidentMonth?.Id;
            parameters["RemediationYear_Id"] = entity.RemediationYear?.Id;
            parameters["RemediationMonth_Id"] = entity.RemediationMonth?.Id;
            parameters["Status_Id"] = entity.Status?.Id;
            parameters["ReportedToORMYear_Id"] = entity.ReportedToORMYear?.Id;
            parameters["ReportedToORMMonth_Id"] = entity.ReportedToORMMonth?.Id;
            parameters["CompletionType"] = entity.CompletionType;
            parameters["CreatedBy"] = entity.CreatedBy;
            parameters["CreatedTime"] = entity.CreatedTime;
            parameters["LastUpdatedBy"] = entity.LastUpdatedBy;
            parameters["LastUpdatedTime"] = entity.LastUpdatedTime;
            parameters["Id"] = entity.Id;

            TestHelper.AssertDatabaseRecordExists(typeof(PrivacyIncident).Name, parameters);

            AssertManyToManyMappings(entity.Id, entity.MitigationCode,
                "PrivacyIncident_PrivacyIncidentMitigationCodeValue",
                "PrivacyIncidentId", "PrivacyIncidentMitigationCodeValueId");
        }

        /// <summary>
        /// Asserts the many to many mappings.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="children">The children.</param>
        /// <param name="tableName">Name of the mapping table.</param>
        /// <param name="parentColumnName">Name of the parent FK column.</param>
        /// <param name="childColumnName">Name of the child FK column.</param>
        private static void AssertManyToManyMappings(long parentId, IEnumerable<IdentifiableEntity> children,
            string tableName, string parentColumnName, string childColumnName)
        {
            if (children != null)
            {
                foreach (var item in children)
                {
                    TestHelper.AssertDatabaseRecordExists(tableName,
                        new Dictionary<string, object>
                        {
                            [parentColumnName] = parentId,
                            [childColumnName] = item.Id,
                        });
                }
            }
        }

        #endregion
    }
}
