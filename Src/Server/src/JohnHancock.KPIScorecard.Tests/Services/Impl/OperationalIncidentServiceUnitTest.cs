/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnHancock.KPIScorecard.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Tests.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="OperationalIncidentService"/> class.
    /// </summary>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    /// 
    /// <author>
    /// NightWolf, TCSASSEMBLER
    /// </author>
    ///
    /// <version>
    /// 1.1
    /// </version>
    ///
    /// <copyright>
    /// Copyright (c) 2017, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class OperationalIncidentServiceUnitTest : BaseServiceUnitTest<OperationalIncidentService>
    {
        #region GetLastTalliedNumber(int, int) method tests

        /// <summary>
        /// Accuracy test of <c>GetLastTalliedNumber</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetLastTalliedNumberAccuracy1()
        {
            // arrange
            int year = 2016;
            int month = 1;

            // act
            int result = instance.GetLastTalliedNumber(year, month);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetLastTalliedNumber</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetLastTalliedNumberAccuracy2()
        {
            // arrange
            int year = 2099;
            int month = 1;

            // act
            int result = instance.GetLastTalliedNumber(year, month);

            // assert
            AssertResult(result);
        }

        #endregion

        #region Create(OperationalIncident) method tests

        /// <summary>
        /// Accuracy test of <c>Create</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAccuracy()
        {
            // arrange
            OperationalIncident entity = CreateTestEntity<OperationalIncident>(1);

            // act
            OperationalIncident result = instance.Create(entity);

            // assert
            AssertEntityExists(entity);

            result.Id = 0;
            AssertResult(result);
        }

        #endregion

        #region Update(OperationalIncident) method tests

        /// <summary>
        /// Accuracy test of <c>Update</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy()
        {
            // arrange
            OperationalIncident entity = CreateTestEntity<OperationalIncident>(5);
            entity.Id = 1;

            // act
            OperationalIncident result = instance.Update(entity);

            // assert
            AssertEntityExists(entity);
            AssertResult(result);
        }

        #endregion

        #region Get(long) method tests

        /// <summary>
        /// Accuracy test of <c>Get</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAccuracy()
        {
            // arrange
            long id = 1;

            // act
            OperationalIncident result = instance.Get(id);

            // assert
            AssertResult(result);
        }

        #endregion

        #region Delete(long) method tests

        /// <summary>
        /// Accuracy test of <c>Delete</c> method,
        /// no exception is expected to be thrown.
        /// </summary>
        [TestMethod]
        public void TestDeleteAccuracy()
        {
            // arrange
            long id = 2;

            // act
            instance.Delete(id);

            // assert
            TestHelper.AssertDatabaseEntityDeleted<OperationalIncident>(id);
        }

        #endregion

        #region Search(OperationalIncidentSearchCriteria) method tests

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy1()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                BusinessUnitId = 1,
                FinancialExposureId = 1,
                IncidentMonthId = 1
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy2()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                IncidentYearId = 2,
                RemediationMonthId = 2,
                RemediationYearId = 2
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy3()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                ReportedToORMMonthId = 4,
                ReportedToORMYearId = 4,
                RootCauseId = 4
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy4()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                SourceId = 7,
                StatusId = 7
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy5()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                CompletionTypes = new List<ScorecardCompletionType> { ScorecardCompletionType.Completed },
                IncidentNumber = "O1601",
                PageNumber = 1,
                PageSize = 2,
                SortBy = nameof(OperationalIncident.BusinessUnit) + ".Value",
                SortType = SortType.Descending
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy6()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                ImpactIds = new List<long> { 1, 6, 7, 8, 9 },
                OperationalFinding = "ding1",
                PageNumber = 1,
                PageSize = 3,
                SortBy = nameof(OperationalIncident.IncidentNumber),
                SortType = SortType.Ascending
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy7()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
                PageNumber = 2,
                PageSize = 4,
                SortBy = nameof(OperationalIncident.OperationalFinding),
                SortType = SortType.Descending
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy8()
        {
            // arrange
            var criteria = new OperationalIncidentSearchCriteria
            {
            };

            // act
            SearchResult<OperationalIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        #endregion
    }
}
