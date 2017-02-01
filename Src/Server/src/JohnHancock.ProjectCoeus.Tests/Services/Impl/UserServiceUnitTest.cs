/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Entities;
using JohnHancock.ProjectCoeus.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using JohnHancock.Common.Services.Impl;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Entities.DTOs;

namespace JohnHancock.ProjectCoeus.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="UserService"/> class.
    /// </summary>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT:
    /// - Added test cases for 'update', 'delete' and 'search'
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// </remarks>
    ///
    /// <author>
    /// NightWolf, veshu
    /// </author>
    ///
    /// <version>
    /// 1.2
    /// </version>
    ///
    /// <copyright>
    /// Copyright (c) 2016, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class UserServiceUnitTest : BaseServiceUnitTest<UserService>
    {
        #region GetByUsername(string) method tests

        /// <summary>
        /// Accuracy test of <c>GetByUsername</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByUsernameAccuracy1()
        {
            // arrange
            string username = "CoeusOwnerUser1";

            // act
            User result = instance.GetByUsername(username);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetByUsername</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByUsernameAccuracy2()
        {
            // arrange
            string username = "CoeusBUFuncApp1";

            // act
            User result = instance.GetByUsername(username);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetByUsername</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByUsernameAccuracy3()
        {
            // arrange
            string username = "CoeusRiskManager";

            // act
            User result = instance.GetByUsername(username);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetByUsername</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByUsernameAccuracy4()
        {
            // arrange
            string username = "CoeusDivManager";

            // act
            User result = instance.GetByUsername(username);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetByUsername</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByUsernameAccuracy5()
        {
            // arrange
            string username = "CoeusAdminUser";

            // act
            User result = instance.GetByUsername(username);

            // assert
            AssertResult(result);
        }

        #endregion GetByUsername(string) method tests

        #region GetByRealName(string) method tests

        /// <summary>
        /// Accuracy test of <c>GetByRealName</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByRealNameAccuracy1()
        {
            // arrange
            string realName = "Owner";

            // act
            IList<User> result = instance.GetByRealName(realName);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetByRealName</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetByRealNameAccuracy2()
        {
            // arrange
            string realName = "Coeus";

            // act
            IList<User> result = instance.GetByRealName(realName);
            result = result.OrderBy(x => x.Username).ToList();

            // assert
            AssertResult(result);
        }

        #endregion GetByRealName(string) method tests

        #region Update(User) method tests

        /// <summary>
        /// Accuracy test of <c>Update</c> method.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy1()
        {
            // arrange
            string username = "CoeusRiskManager";
            User user = instance.GetByUsername(username);

            // modify value
            user.BusinessUnits = new List<BusinessUnit>
            {
                new BusinessUnit
                {
                    Id=1
                },
                new BusinessUnit
                {
                    Id=2
                }
            };
            user.IsActive = !user.IsActive;
            user.Role = Role.Owner;

            //act
            instance.Update(user);

            AssertEntityExists(user, 3);
            var buParameters = new Dictionary<string, object>();
            buParameters["UserId"] = 5;
            TestHelper.AssertDatabaseRecordCount("User_BusinessUnit", buParameters, 2);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method.
        /// </summary>
        [TestMethod]
        public void TestUpdateAccuracy2()
        {
            // arrange
            string username = "CoeusRiskManager";
            User user = instance.GetByUsername(username);

            // modify value
            user.BusinessUnits = new List<BusinessUnit>
            {
                new BusinessUnit
                {
                    Id=1
                },
                new BusinessUnit
                {
                    Id=2
                }
            };
            user.IsActive = !user.IsActive;
            user.Role = Role.Owner;

            // delete user mapping first
            instance.Delete(username);

            // confirm user mapping is not present in db
            var parameters = new Dictionary<string, object>
            {
                ["Username"] = username
            };

            TestHelper.AssertDatabaseRecordCount("UserMappingInfo", parameters, 0);

            //act
            // this should create new mappings
            instance.Update(user);

            // verify new mapping is created
            TestHelper.AssertDatabaseRecordCount("UserMappingInfo", parameters, 1);
        }

        /// <summary>
        /// <para>
        /// Tests the failure case of the Update method.
        /// </para>
        /// </summary>
        [TestMethod, ExpectedException(typeof(EntityNotFoundException))]
        public void TestUpdate2()
        {
            var userToUpdate = new User
            {
                Username = "Dummy",
                IsActive = true,
                Role = Role.Admin,
                BusinessUnits = null
            };
            instance.Update(userToUpdate);
        }

        /// <summary>
        /// <para>
        /// Tests the failure case of the Update method.
        /// Should throw exception, because user is referenced in assessments
        /// </para>
        /// </summary>
        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void TestUpdate3()
        {
            var userToUpdate = new User
            {
                Username = "CoeusOwnerUser1",
                IsActive = true,
                Role = Role.Admin,
                BusinessUnits = null
            };
            instance.Update(userToUpdate);
        }

        /// <summary>
        /// <para>
        /// Tests the failure case of the Update method.
        /// Should throw exception, because user is referenced in assessments
        /// </para>
        /// </summary>
        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void TestUpdate4()
        {
            var userToUpdate = new User
            {
                Username = "CoeusBUFuncApp1",
                IsActive = true,
                Role = Role.Admin,
                BusinessUnits = null
            };
            instance.Update(userToUpdate);
        }

        /// <summary>
        /// <para>
        /// Tests the failure case of the Update method.
        /// Should throw exception, because user is referenced in assessments
        /// </para>
        /// </summary>
        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void TestUpdate5()
        {
            var userToUpdate = new User
            {
                Username = "CoeusOwnerUser1",
                IsActive = false,
                Role = Role.Owner,
                BusinessUnits = null
            };
            instance.Update(userToUpdate);
        }

        #endregion Update(User) method tests

        #region Delete(string) method tests

        /// <summary>
        /// Tests the accuracy of the Delete method.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            // arrange
            string username = "CoeusRiskManager";

            // confirm user mapping exists before delete
            var parameters = new Dictionary<string, object>
            {
                ["Username"] = username
            };
            TestHelper.AssertDatabaseRecordCount("UserMappingInfo", parameters, 1);
            var buParameters = new Dictionary<string, object>();
            buParameters["UserId"] = 5;
            TestHelper.AssertDatabaseRecordCount("User_BusinessUnit", buParameters, 5);

            // act
            instance.Delete(username);

            // verify user mapping is deleted from db
            TestHelper.AssertDatabaseRecordCount("UserMappingInfo", parameters, 0);
            TestHelper.AssertDatabaseRecordCount("User_BusinessUnit", buParameters, 0);

            // also verify user is not deleted on AD
            User user = instance.GetByUsername(username);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Tests the failure case of the Delete method.
        /// Should throw exception, because user is referenced in assessments
        /// </summary>
        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void TestDelete2()
        {
            // arrange
            string username = "CoeusOwnerUser1";

            // act
            instance.Delete(username);
        }

        /// <summary>
        /// Tests the failure case of the Delete method.
        /// Should throw exception, because user is referenced in assessments
        /// </summary>
        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void TestDelete3()
        {
            // arrange
            string username = "CoeusBUFuncApp1";

            // act
            instance.Delete(username);
        }

        #endregion Delete(string) method tests

        #region Search(UserSearchCriteria) method tests

        /// <summary>
        /// Tests the accuracy of the Search method.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy1()
        {
            var criteria = new UserSearchCriteria();

            SearchResult<User> result = instance.Search(criteria);

            AssertResult(result);
        }

        /// <summary>
        /// Tests the accuracy of the Search method.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy2()
        {
            var criteria = new UserSearchCriteria
            {
                Username = "Admin"
            };

            SearchResult<User> result = instance.Search(criteria);

            AssertResult(result);
        }

        /// <summary>
        /// Tests the accuracy of the Search method.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy3()
        {
            var criteria = new UserSearchCriteria
            {
                Roles = new List<Role> { Role.BUFunctionalApprover, Role.BURiskManagementApprover }
            };

            SearchResult<User> result = instance.Search(criteria);

            AssertResult(result);
        }

        /// <summary>
        /// Tests the accuracy of the Search method.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy4()
        {
            var criteria = new UserSearchCriteria
            {
                Roles = new List<Role> { Role.BUFunctionalApprover, Role.BURiskManagementApprover },
                SortType = SortType.Descending,
                SortBy = "Role"
            };

            SearchResult<User> result = instance.Search(criteria);

            AssertResult(result);
        }

        /// <summary>
        /// Tests the accuracy of the Search method.
        /// </summary>
        [TestMethod]
        public void TestSearchAccuracy5()
        {
            var criteria = new UserSearchCriteria
            {
                BusinessUnitIds = new List<long> { 1, 2 },
                SortType = SortType.Ascending,
                SortBy = "FirstName"
            };

            SearchResult<User> result = instance.Search(criteria);

            AssertResult(result);
        }

        #endregion Search(UserSearchCriteria) method tests
    }
}