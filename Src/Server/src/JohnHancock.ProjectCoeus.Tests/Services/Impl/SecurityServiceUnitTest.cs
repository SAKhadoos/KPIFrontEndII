/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JohnHancock.Common.Services.Impl;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Entities;

namespace JohnHancock.ProjectCoeus.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="SecurityService"/> class.
    /// </summary>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Updated the username of users
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
    /// Copyright (c) 2016, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class SecurityServiceUnitTest : BaseServiceUnitTest<SecurityService>
    {
        #region Authenticate(string, string) method tests

        /// <summary>
        /// Accuracy test of <c>Authenticate</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestAuthenticateAccuracy1()
        {
            // arrange
            string username = "fake";
            string password = "fake";

            // act
            User result = instance.Authenticate(username, password);

            // assert
            Assert.IsNull(result, "result should be null for unknown users.");
        }

        /// <summary>
        /// Accuracy test of <c>Authenticate</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestAuthenticateCredentialsAccuracy2()
        {
            // arrange
            string username = "CoeusOwnerUser1";
            string password = "password";

            // act
            User result = instance.Authenticate(username, password);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>Authenticate</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestAuthenticateCredentialsAccuracy3()
        {
            // arrange
            string username = "CoeusAdminUser";
            string password = "password";

            // act
            User result = instance.Authenticate(username, password);

            // assert
            AssertResult(result);
        }

        #endregion Authenticate(string, string) method tests

        #region IsAuthorized(Role, string) method tests

        /// <summary>
        /// Accuracy test of <c>IsAuthorized</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestIsAuthorizedAccuracy1()
        {
            // arrange
            Role role = Role.Owner;
            string action = "Assessment.Submit";

            // act
            bool result = instance.IsAuthorized(role, action);

            // assert
            Assert.IsTrue(result, "Result should be true.");
        }

        /// <summary>
        /// Accuracy test of <c>IsAuthorized</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestIsAuthorizedAccuracy2()
        {
            // arrange
            Role role = Role.BURiskManagementApprover;
            string action = "Assessment.Submit";

            // act
            bool result = instance.IsAuthorized(role, action);

            // assert
            Assert.IsFalse(result, "Result should be false.");
        }

        #endregion IsAuthorized(Role, string) method tests

        #region GenerateToken(string) method tests

        /// <summary>
        /// Accuracy test of <c>GenerateToken</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGenerateTokenAccuracy()
        {
            // arrange
            string username = "someUser";

            // act
            Token result = instance.GenerateToken(username);

            // assert
            Assert.IsNotNull(result, "result is expected to be not null.");
            Assert.AreEqual(username, result.Username, "result.Username is incorrect.");

            // check that it was added to DB
            result.Username = username;
            AssertEntityExists(result);
        }

        #endregion GenerateToken(string) method tests

        #region Authenticate(string) method tests

        /// <summary>
        /// Accuracy test of <c>Authenticate</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestAuthenticateWithTokenAccuracy()
        {
            // arrange
            string token = "e8d5ba3f-2459-4ea5-a30a-b0addf99e0f5";

            // act
            User result = instance.Authenticate(token);

            // assert
            AssertResult(result);
        }

        #endregion Authenticate(string) method tests

        #region RevokeToken(string) method tests

        /// <summary>
        /// Accuracy test of <c>RevokeToken</c> method,
        /// no exception is expected to be thrown.
        /// </summary>
        [TestMethod]
        public void TestRevokeTokenAccuracy()
        {
            // arrange
            string token = "e8d5ba3f-2459-4ea5-a30a-b0addf99e0f5";

            // act
            instance.RevokeToken(token);

            // assert
            var parameters = new Dictionary<string, object>
            {
                ["TokenValue"] = token
            };
            TestHelper.AssertDatabaseRecordCount("Token", parameters, 0);
        }

        #endregion RevokeToken(string) method tests
    }
}