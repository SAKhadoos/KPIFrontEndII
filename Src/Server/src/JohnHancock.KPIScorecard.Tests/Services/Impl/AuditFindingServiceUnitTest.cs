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
    /// Unit tests for <see cref="AuditFindingService"/> class.
    /// </summary>
    ///
    /// <author>
    /// NightWolf
    /// </author>
    ///
    /// <version>
    /// 1.0
    /// </version>
    ///
    /// <copyright>
    /// Copyright (c) 2017, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class AuditFindingServiceUnitTest : BaseServiceUnitTest<AuditFindingService>
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
            int year = 2016;
            int month = 12;

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
        public void TestGetLastTalliedNumberAccuracy3()
        {
            // arrange
            int year = 2099;
            int month = 12;

            // act
            int result = instance.GetLastTalliedNumber(year, month);

            // assert
            AssertResult(result);
        }

        #endregion

        #region Create(AuditFinding) method tests

        /// <summary>
        /// Accuracy test of <c>Create</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAccuracy()
        {
            // arrange
            AuditFinding entity = CreateTestEntity<AuditFinding>(7);

            // act
            AuditFinding result = instance.Create(entity);

            // assert
            AssertEntityExists(entity);

            result.Id = 0;
            AssertResult(result);
        }

        #endregion

        #region Update(AuditFinding) method tests

        /// <summary>
        /// Accuracy test of <c>Update</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy()
        {
            // arrange
            AuditFinding entity = CreateTestEntity<AuditFinding>(5);
            entity.Id = 2;

            // act
            AuditFinding result = instance.Update(entity);

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
        public void TestGetAccuracy1()
        {
            // arrange
            long id = 1;

            // act
            AuditFinding result = instance.Get(id);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Get</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAccuracy2()
        {
            // arrange
            long id = 3;

            // act
            AuditFinding result = instance.Get(id);

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
            long id = 1;

            // act
            instance.Delete(id);

            // assert
            TestHelper.AssertDatabaseEntityDeleted<AuditFinding>(id);
        }

        #endregion

        #region Search(AuditFindingSearchCriteria) method tests

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy1()
        {
            // arrange
            var criteria = new AuditFindingSearchCriteria();

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                AuditFindingNumber = "A1612"
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                AuditMonthId = 4,
                AuditYearId = 4,
                BusinessUnitId = 4,
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                AuditTitle = "Titil",
                PageNumber = 1,
                PageSize = 2,
                SortBy = nameof(AuditFinding.AuditMonth) + ".Id",
                SortType = SortType.Descending
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                CompletionTypes = new List<ScorecardCompletionType> { ScorecardCompletionType.Draft },
                ImpactIds = new List<long> { 5, 8, 3 },
                PageNumber = 1,
                PageSize = 2,
                SortBy = nameof(AuditFinding.CompletionType),
                SortType = SortType.Ascending
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                RemediationMonthId = 7,
                RemediationYearId = 7,
                ReportedToORMMonthId = 7,
                ReportedToORMYearId = 7
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                RootCauseId = 4,
                SourceId = 4,
                StatusId = 4
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

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
            var criteria = new AuditFindingSearchCriteria
            {
                PageNumber = 2,
                PageSize = 3,
                SortBy = nameof(AuditFinding.AuditFindingNumber),
                SortType = SortType.Descending
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy9()
        {
            // arrange
            var criteria = new AuditFindingSearchCriteria
            {
                SortBy = nameof(AuditFinding.AuditTitle),
                SortType = SortType.Ascending
            };

            // act
            SearchResult<AuditFinding> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        #endregion
    }
}
