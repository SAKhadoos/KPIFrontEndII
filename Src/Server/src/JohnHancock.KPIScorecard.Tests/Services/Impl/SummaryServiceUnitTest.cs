/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnHancock.KPIScorecard.Services.Impl;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Tests.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="SummaryService"/> class.
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
    public class SummaryServiceUnitTest : BaseServiceUnitTest<SummaryService>
    {
        #region GetSummary(long, long, long) method tests

        /// <summary>
        /// Accuracy test of <c>GetSummary</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetSummaryAccuracy()
        {
            // arrange
            long businessUnitId = 2;
            long yearId = 2;
            long monthId = 2;

            // act
            Summary result = instance.GetSummary(businessUnitId, yearId, monthId);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetSummary</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetSummaryAccuracy2()
        {
            // arrange
            long businessUnitId = 1;
            long yearId = 2;
            long monthId = 3;

            // act
            Summary result = instance.GetSummary(businessUnitId, yearId, monthId);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetSummary</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetSummaryAccuracy3()
        {
            // arrange
            long businessUnitId = 7;
            long yearId = 7;
            long monthId = 7;

            // act
            Summary result = instance.GetSummary(businessUnitId, yearId, monthId);

            // assert
            AssertResult(result);
        }

        #endregion
    }
}
