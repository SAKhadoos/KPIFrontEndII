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
    /// Unit tests for <see cref="PrivacyIncidentService"/> class.
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
    public class PrivacyIncidentServiceUnitTest : BaseServiceUnitTest<PrivacyIncidentService>
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

        #region Create(PrivacyIncident) method tests

        /// <summary>
        /// Accuracy test of <c>Create</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAccuracy()
        {
            // arrange
            PrivacyIncident entity = CreateTestEntity<PrivacyIncident>(2);

            // act
            PrivacyIncident result = instance.Create(entity);

            // assert
            AssertEntityExists(entity);

            result.Id = 0;
            AssertResult(result);
        }

        #endregion

        #region Update(PrivacyIncident) method tests

        /// <summary>
        /// Accuracy test of <c>Update</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy()
        {
            // arrange
            PrivacyIncident entity = CreateTestEntity<PrivacyIncident>(1);
            entity.Id = 2;

            // act
            PrivacyIncident result = instance.Update(entity);

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
            long id = 2;

            // act
            PrivacyIncident result = instance.Get(id);

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
            long id = 4;

            // act
            instance.Delete(id);

            // assert
            TestHelper.AssertDatabaseEntityDeleted<PrivacyIncident>(id);
        }

        #endregion

        #region Search(PrivacyIncidentSearchCriteria) method tests

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy1()
        {
            // arrange
            var criteria = new PrivacyIncidentSearchCriteria
            {
                BusinessUnitId = 1,
                IncidentMonthId = 1,
                IncidentTypeId = 1,
                IncidentYearId = 1
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                RemediationMonthId = 4,
                RemediationYearId = 4,
                ReportedToORMMonthId = 4
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                ReportedToORMYearId = 2,
                RootCauseId = 2,
                StatusId = 2
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                CompletionTypes = new List<ScorecardCompletionType> { ScorecardCompletionType.Completed },
                IncidentNumber = "1612",
                PageNumber = 1,
                PageSize = 2,
                SortBy = nameof(PrivacyIncident.IncidentNumber),
                SortType = SortType.Descending
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                IncidentTitle = "itle1",
                MitigationCodeIds = new List<long> { 3, 6, 8, 9 },
                PageNumber = 1,
                PageSize = 3,
                SortBy = nameof(PrivacyIncident.NumberOfCustomersImpacted),
                SortType = SortType.Ascending
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                MitigationDetail = "Detail2",
                NumberOfCustomersImpacted = 4,
                PageNumber = 1,
                PageSize = 2,
                SortBy = nameof(PrivacyIncident.LastUpdatedTime),
                SortType = SortType.Descending
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
                PageNumber = 2,
                PageSize = 3,
                SortBy = nameof(PrivacyIncident.MitigationDetail),
                SortType = SortType.Ascending
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

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
            var criteria = new PrivacyIncidentSearchCriteria
            {
            };

            // act
            SearchResult<PrivacyIncident> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        #endregion
    }
}
