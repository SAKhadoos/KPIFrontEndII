/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnHancock.KPIScorecard.Services.Impl;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Tests.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="BusinessUnitKPIScorecardService"/> class.
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
    public class BusinessUnitKPIScorecardServiceUnitTest : BaseServiceUnitTest<BusinessUnitKPIScorecardService>
    {
        #region Create(BusinessUnitKPIScorecard) method tests

        /// <summary>
        /// Accuracy test of <c>Create</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAccuracy()
        {
            // arrange
            BusinessUnitKPIScorecard entity = CreateTestEntity<BusinessUnitKPIScorecard>(1);
            entity.OperationPerformanceScores[0].Id = 12;
            entity.OperationPerformanceScores[1].Id = 13;

            // act
            BusinessUnitKPIScorecard result = instance.Create(entity);

            // assert
            AssertEntityExists(entity);
            foreach (var item in result.BusinessContinuityPlanningScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.ConcentrationRiskScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.FinancialIndicatorScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.OperationPerformanceScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.SecurityScores)
            {
                item.Id = 0;
            }

            result.Id = 0;
            AssertResult(result);
        }

        #endregion

        #region Update(BusinessUnitKPIScorecard) method tests

        /// <summary>
        /// Accuracy test of <c>Update</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy()
        {
            // arrange
            BusinessUnitKPIScorecard entity = CreateTestEntity<BusinessUnitKPIScorecard>(5);
            entity.Id = 2;
            entity.OperationPerformanceScores[0].Id = 14;
            entity.OperationPerformanceScores[1].Id = 11;

            // act
            BusinessUnitKPIScorecard result = instance.Update(entity);
            foreach (var item in result.BusinessContinuityPlanningScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.ConcentrationRiskScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.FinancialIndicatorScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.OperationPerformanceScores)
            {
                item.Id = 0;
            }
            foreach (var item in result.SecurityScores)
            {
                item.Id = 0;
            }

            // assert
            AssertEntityExists(entity);
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy2()
        {
            // arrange
            BusinessUnitKPIScorecard entity = CreateTestEntity<BusinessUnitKPIScorecard>(3);
            entity.Id = 2;
            entity.OperationPerformanceScores = null;
            entity.BusinessContinuityPlanningScores = null;
            entity.ConcentrationRiskScores = null;
            entity.FinancialIndicatorScores = null;
            entity.SecurityScores = null;

            // act
            BusinessUnitKPIScorecard result = instance.Update(entity);

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
            BusinessUnitKPIScorecard result = instance.Get(id);

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
            TestHelper.AssertDatabaseEntityDeleted<BusinessUnitKPIScorecard>(id);
        }

        #endregion

        #region Search(BusinessUnitKPIScorecardSearchCriteria) method tests

        /// <summary>
        /// Accuracy test of <c>Search</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy1()
        {
            // arrange
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                BusinessUnitId = 1
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                MonthId = 2
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                StatusId = 4
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                YearId = 5
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                CompletionType = ScorecardCompletionType.Completed,
                DueDate = new DateTime(2016, 12, 31),
                PageNumber = 1,
                PageSize = 3,
                SortBy = nameof(BusinessUnitKPIScorecard.Status) + ".Value",
                SortType = SortType.Descending
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
                PageNumber = 3,
                PageSize = 3,
                SortBy = nameof(BusinessUnitKPIScorecard.DueDate),
                SortType = SortType.Descending
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

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
            var criteria = new BusinessUnitKPIScorecardSearchCriteria
            {
            };

            // act
            SearchResult<BusinessUnitKPIScorecard> result = instance.Search(criteria);

            // assert
            AssertResult(result);
        }

        #endregion
    }
}
