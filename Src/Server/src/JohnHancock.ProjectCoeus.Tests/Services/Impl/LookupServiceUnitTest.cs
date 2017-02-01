/*
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Entities;
using JohnHancock.ProjectCoeus.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using JohnHancock.Common.Entities;

namespace JohnHancock.ProjectCoeus.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="LookupService"/> class.
    /// </summary>
    ///
    /// <remarks>
    /// Changes in 1.1:
    ///     - Added new test cases for new methods
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// Changes in 1.3:
    ///  - John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0:
    ///  https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    /// <author>
    /// NightWolf, veshu, TCSASSEMBLER
    /// </author>
    ///
    /// <version>
    /// 1.3
    /// </version>
    ///
    /// <copyright>
    /// Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class LookupServiceUnitTest : BaseServiceUnitTest<LookupService>
    {
        #region GetAll method tests

        #region GetAllAssessmentStatuses() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllAssessmentStatuses</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllAssessmentStatusesAccuracy()
        {
            // act
            IList<AssessmentStatus> result = instance.GetAllAssessmentStatuses();

            // assert
            AssertResult(result);
        }

        #endregion GetAllAssessmentStatuses() method tests

        #region GetAllChangeTypes() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllChangeTypes</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllChangeTypesAccuracy()
        {
            // act
            IList<ChangeType> result = instance.GetAllChangeTypes();

            // assert
            AssertResult(result);
        }

        #endregion GetAllChangeTypes() method tests

        #region GetAllSites() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllSites</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllSitesAccuracy()
        {
            // act
            IList<Site> result = instance.GetAllSites();

            // assert
            AssertResult(result);
        }

        #endregion GetAllSites() method tests

        #region GetAllBusinessUnits() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllBusinessUnits</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllBusinessUnitsAccuracy()
        {
            // act
            IList<BusinessUnit> result = instance.GetAllBusinessUnits();

            // assert
            AssertResult(result);
        }

        #endregion GetAllBusinessUnits() method tests

        #region GetAllDepartmentHeads(long) method tests

        /// <summary>
        /// Accuracy test of <c>GetAllDepartmentHeads</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllDepartmentHeadsAccuracy()
        {
            // arrange
            long businessUnitId = 1;

            // act
            IList<DepartmentHead> result = instance.GetAllDepartmentHeads(businessUnitId);

            // assert
            AssertResult(result);
        }

        #endregion GetAllDepartmentHeads(long) method tests

        #region GetAllProducts() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllProducts</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllProductsAccuracy()
        {
            // arrange
            long businessUnitId = 1;

            // act
            IList<Product> result = instance.GetAllProducts(businessUnitId);

            // assert
            AssertResult(result);
        }

        #endregion GetAllProducts() method tests

        #region GetAllDepartments() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllDepartments</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllDepartmentsAccuracy()
        {
            // arrange
            long businessUnitId = 1;

            // act
            IList<Department> result = instance.GetAllDepartments(businessUnitId);

            // assert
            AssertResult(result);
        }

        #endregion GetAllDepartments() method tests

        #region GetAllAssessmentTypes() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllAssessmentTypes</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllAssessmentTypesAccuracy()
        {
            // act
            IList<AssessmentType> result = instance.GetAllAssessmentTypes();

            // assert
            AssertResult(result);
        }

        #endregion GetAllAssessmentTypes() method tests

        #region GetAllRiskExposures() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllRiskExposures</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllRiskExposuresAccuracy()
        {
            // act
            IList<RiskExposure> result = instance.GetAllRiskExposures();

            // assert
            AssertResult(result);
        }

        #endregion GetAllRiskExposures() method tests

        #region GetAllCategories() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllCategories</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllCategoriesAccuracy()
        {
            // act
            IList<Category> result = instance.GetAllCategories();

            // assert
            AssertResult(result);
        }

        #endregion GetAllCategories() method tests

        #region GetAllLikelihoodOfOccurrences() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllLikelihoodOfOccurrences</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllLikelihoodOfOccurrencesAccuracy()
        {
            // act
            IList<LikelihoodOfOccurrence> result = instance.GetAllLikelihoodOfOccurrences();

            // assert
            AssertResult(result);
        }

        #endregion GetAllLikelihoodOfOccurrences() method tests

        #region GetAllRiskImpacts() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllRiskImpacts</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllRiskImpactsAccuracy()
        {
            // act
            IList<RiskImpact> result = instance.GetAllRiskImpacts();

            // assert
            AssertResult(result);
        }

        #endregion GetAllRiskImpacts() method tests

        #region GetKPICategories() method tests

        /// <summary>
        /// Accuracy test of <c>GetKPICategories</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetKPICategoriesAccuracy()
        {
            // act
            IList<KPICategory> result = instance.GetKPICategories();

            // assert
            AssertResult(result);
        }

        #endregion GetKPICategories() method tests

        #region GetAllProcessRisks() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllProcessRisks</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllProcessRisksAccuracy()
        {
            // act
            IList<ProcessRisk> result = instance.GetAllProcessRisks();

            // assert
            AssertResult(result);
        }

        #endregion GetAllProcessRisks() method tests

        #region GetAllControlFrequencies() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllControlFrequencies</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllControlFrequenciesAccuracy()
        {
            // act
            IList<ControlFrequency> result = instance.GetAllControlFrequencies();

            // assert
            AssertResult(result);
        }

        #endregion GetAllControlFrequencies() method tests

        #region GetAllControlTriggers() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllControlTriggers</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllControlTriggersAccuracy()
        {
            // act
            IList<ControlTrigger> result = instance.GetAllControlTriggers();

            // assert
            AssertResult(result);
        }

        #endregion GetAllControlTriggers() method tests

        #region GetAllKeyControlsMaturities() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllKeyControlsMaturities</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllKeyControlsMaturitiesAccuracy()
        {
            // act
            IList<KeyControlsMaturity> result = instance.GetAllKeyControlsMaturities();

            // assert
            AssertResult(result);
        }

        #endregion GetAllKeyControlsMaturities() method tests

        #region GetAllControlDesigns() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllControlDesigns</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllControlDesignsAccuracy()
        {
            // act
            IList<ControlDesign> result = instance.GetAllControlDesigns();

            // assert
            AssertResult(result);
        }

        #endregion GetAllControlDesigns() method tests

        #region GetAllTestingFrequencies() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllTestingFrequencies</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllTestingFrequenciesAccuracy()
        {
            // act
            IList<TestingFrequency> result = instance.GetAllTestingFrequencies();

            // assert
            AssertResult(result);
        }

        #endregion GetAllTestingFrequencies() method tests

        #region GetAllPercentages() method tests

        /// <summary>
        /// Accuracy test of <c>GetAllPercentages</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllPercentagesAccuracy()
        {
            // act
            IList<Percentage> result = instance.GetAllPercentages();

            // assert
            AssertResult(result);
        }

        #endregion GetAllPercentages() method tests

        #region GetFunctionalAreaOwners(long) method tests

        /// <summary>
        /// Accuracy test of <c>GetFunctionalAreaOwners</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetFunctionalAreaOwnersAccuracy()
        {
            // arrange
            long businessUnitId = 1;

            // act
            IList<FunctionalAreaOwner> result = instance.GetFunctionalAreaOwners(businessUnitId);

            // assert
            AssertResult(result);
        }

        #endregion GetFunctionalAreaOwners(long) method tests

        #region GetControlTypes(long) method tests

        /// <summary>
        /// Accuracy test of <c>GetCoreProcesses</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetCoreProcessesAccuracy()
        {
            // arrange
            long functionalAreaId = 1;

            // act
            IList<CoreProcess> result = instance.GetCoreProcesses(1, functionalAreaId);
            foreach (var item in result)
            {
                item.SubProcessRisks = item.SubProcessRisks.OrderBy(x => x.Id).ToList();
            }

            // assert
            AssertResult(result);
        }

        #endregion GetControlTypes(long) method tests

        #region GetFunctionalAreas(long) method tests

        /// <summary>
        /// Accuracy test of <c>GetFunctionalAreas</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetFunctionalAreasAccuracy()
        {
            // arrange
            long businessUnitId = 1;

            // act
            IList<FunctionalArea> result = instance.GetFunctionalAreas(businessUnitId);

            // assert
            AssertResult(result);
        }

        #endregion GetFunctionalAreas(long) method tests

        #endregion GetAll method tests

        #region Admin related method tests

        #region new get all method tests

        /// <summary>
        /// Accuracy test of <c>GetAllAssessmentStatuses</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetFunctionalAreasWithCategoryAccuracy()
        {
            // act
            var result = instance.GetFunctionalAreas(1111, 1);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetBusinessUnits</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetBusinessUnitsWithCategoryAccuracy()
        {
            // act
            var result = instance.GetBusinessUnits(1);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetAllSLAs</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllSLAsAccuracy()
        {
            // act
            var result = instance.GetAllSLAs();

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetAllControlTypes</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllControlTypesWithCategoryAccuracy()
        {
            // act
            var result = instance.GetAllControlTypes(3);

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>GetAllRiskScoreRanges</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetAllRiskScoreRangesAccuracy()
        {
            // act
            var result = instance.GetAllRiskScoreRanges();

            // assert
            AssertResult(result);
        }

        #endregion new get all method tests

        #region add-ons test

        /// <summary>
        /// Accuracy test of <c>GetPendingAddOns</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetPendingAddOnsAccuracy()
        {
            // act
            var result = instance.GetPendingAddOns();

            // assert
            AssertResult(result);
        }

        /// <summary>
        /// Accuracy test of <c>CountPendingAddOns</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCountPendingAddOnsAccuracy()
        {
            // act
            var result = instance.CountPendingAddOns();

            // assert
            AssertResult(result);
        }

        #endregion add-ons test

        #region import test

        /// <summary>
        /// Accuracy test of <c>Import</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestImportAccuracy()
        {
            string username = "CoeusAdminUser";
            using (FileStream stream = new FileStream(TestHelper.ImportFileFullPath, FileMode.Open))
            {
                // act
                instance.Import(stream, username);
            }

            var pending = instance.CountPendingAddOns();
            Assert.AreEqual(31, pending);

            var pendings = instance.GetPendingAddOns();
            foreach (var item in pendings)
            {
                ResetDynamicFields(item, true);
                item.CreatedTime = new DateTime(2999, 9, 1);
                item.LastUpdatedTime = new DateTime(2099, 9, 1);
            }

            AssertResult(pendings);
        }

        #endregion import test

        #region AssessmentStatus

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="AssessmentStatus"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAssessmentStatusAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentStatus>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="AssessmentStatus"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAssessmentStatusAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentStatus>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="AssessmentStatus"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteAssessmentStatusAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentStatus>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="AssessmentStatus"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderAssessmentStatusAccuracy()
        {
            VerifyLookupReorder<AssessmentStatus>();
        }

        #endregion AssessmentStatus

        #region AssessmentType

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="AssessmentType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateAssessmentTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentType>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="AssessmentType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateAssessmentTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentType>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="AssessmentType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteAssessmentTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<AssessmentType>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="AssessmentType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderAssessmentTypeAccuracy()
        {
            VerifyLookupReorder<AssessmentType>();
        }

        #endregion AssessmentType

        #region BusinessUnit

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="BusinessUnit"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateBusinessUnitAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<BusinessUnit>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="BusinessUnit"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateBusinessUnitAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<BusinessUnit>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="BusinessUnit"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteBusinessUnitAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<BusinessUnit>(1);

            VerifyLookupDelete(entity, 1111);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="BusinessUnit"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderBusinessUnitAccuracy()
        {
            VerifyLookupReorder<BusinessUnit>();
        }

        #endregion BusinessUnit

        #region Category

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="Category"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateCategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Category>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="Category"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateCategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Category>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="Category"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteCategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Category>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="Category"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderCategoryAccuracy()
        {
            VerifyLookupReorder<Category>();
        }

        #endregion Category

        #region ChangeType

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ChangeType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateChangeTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ChangeType>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ChangeType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateChangeTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ChangeType>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ChangeType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteChangeTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ChangeType>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ChangeType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderChangeTypeAccuracy()
        {
            VerifyLookupReorder<ChangeType>();
        }

        #endregion ChangeType

        #region ControlDesign

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ControlDesign"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateControlDesignAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlDesign>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ControlDesign"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateControlDesignAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlDesign>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ControlDesign"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteControlDesignAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlDesign>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ControlDesign"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderControlDesignAccuracy()
        {
            VerifyLookupReorder<ControlDesign>();
        }

        #endregion ControlDesign

        #region ControlFrequency

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ControlFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateControlFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlFrequency>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ControlFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateControlFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlFrequency>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ControlFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteControlFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlFrequency>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ControlFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderControlFrequencyAccuracy()
        {
            VerifyLookupReorder<ControlFrequency>();
        }

        #endregion ControlFrequency

        #region ControlTrigger

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ControlTrigger"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateControlTriggerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlTrigger>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ControlTrigger"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateControlTriggerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlTrigger>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ControlTrigger"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteControlTriggerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlTrigger>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ControlTrigger"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderControlTriggerAccuracy()
        {
            VerifyLookupReorder<ControlTrigger>();
        }

        #endregion ControlTrigger

        #region ControlType

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ControlType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateControlTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlType>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ControlType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateControlTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlType>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ControlType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteControlTypeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ControlType>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ControlType"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderControlTypeAccuracy()
        {
            VerifyLookupReorder<ControlType>();
        }

        #endregion ControlType

        #region CoreProcess

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="CoreProcess"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateCoreProcessAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<CoreProcess>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            entity.SubProcessRisks = new List<SubProcessRisk>() { new SubProcessRisk() { Id = 1111 } };

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="CoreProcess"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateCoreProcessAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<CoreProcess>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            entity.SubProcessRisks = new List<SubProcessRisk>() { new SubProcessRisk() { Id = 1111 } };
            entity.Id = 1111;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="CoreProcess"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteCoreProcessAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<CoreProcess>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            entity.SubProcessRisks = new List<SubProcessRisk>() { new SubProcessRisk() { Id = 1111 } };
            entity.Id = 1111;

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="CoreProcess"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderCoreProcessAccuracy()
        {
            VerifyLookupReorder<CoreProcess>();
        }

        #endregion CoreProcess

        #region Department

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="Department"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateDepartmentAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Department>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="Department"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateDepartmentAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Department>(1);
            entity.BusinessUnitId = 1;
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="Department"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteDepartmentAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Department>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="Department"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderDepartmentAccuracy()
        {
            VerifyLookupReorder<Department>();
        }

        #endregion Department

        #region DepartmentHead

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="DepartmentHead"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateDepartmentHeadAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<DepartmentHead>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="DepartmentHead"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateDepartmentHeadAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<DepartmentHead>(1);
            entity.BusinessUnitId = 1;
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="DepartmentHead"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteDepartmentHeadAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<DepartmentHead>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="DepartmentHead"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderDepartmentHeadAccuracy()
        {
            VerifyLookupReorder<DepartmentHead>();
        }

        #endregion DepartmentHead

        #region FunctionalArea

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="FunctionalArea"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateFunctionalAreaAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalArea>(1);
            entity.BusinessUnitId = 1;
            entity.Category = new Category() { Id = 1 };
            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="FunctionalArea"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateFunctionalAreaAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalArea>(1);
            entity.BusinessUnitId = 1;
            entity.Category = new Category() { Id = 1 };
            entity.Id = 1111;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="FunctionalArea"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteFunctionalAreaAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalArea>(1);
            entity.BusinessUnitId = 1;
            entity.Category = new Category() { Id = 1 };

            VerifyLookupDelete(entity, 1111);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="FunctionalArea"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderFunctionalAreaAccuracy()
        {
            VerifyLookupReorder<FunctionalArea>();
        }

        #endregion FunctionalArea

        #region FunctionalAreaOwner

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="FunctionalAreaOwner"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateFunctionalAreaOwnerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalAreaOwner>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="FunctionalAreaOwner"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateFunctionalAreaOwnerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalAreaOwner>(1);
            entity.BusinessUnitId = 1;
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="FunctionalAreaOwner"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteFunctionalAreaOwnerAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<FunctionalAreaOwner>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="FunctionalAreaOwner"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderFunctionalAreaOwnerAccuracy()
        {
            VerifyLookupReorder<FunctionalAreaOwner>();
        }

        #endregion FunctionalAreaOwner

        #region KPI

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="KPI"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateKPIAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPI>(1);
            entity.KPICategory = new KPICategory() { Id = 1 };

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="KPI"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateKPIAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPI>(1);
            entity.KPICategory = new KPICategory() { Id = 1 };
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="KPI"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteKPIAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPI>(1);
            entity.KPICategory = new KPICategory() { Id = 1 };

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="KPI"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderKPIAccuracy()
        {
            VerifyLookupReorder<KPI>();
        }

        #endregion KPI

        #region KPICategory

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="KPICategory"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateKPICategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPICategory>(1);
            entity.KPIs = new List<KPI>() { new KPI() { Id = 1 } };
            entity.SLAs = new List<SLA>() { new SLA() { Id = 1 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="KPICategory"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateKPICategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPICategory>(1);
            entity.KPIs = new List<KPI>() { new KPI() { Id = 1 } };
            entity.SLAs = new List<SLA>() { new SLA() { Id = 1 } };
            entity.Id = 1111;
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="KPICategory"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteKPICategoryAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KPICategory>(1);
            entity.Id = 1111;

            VerifyLookupDelete(entity, 1111);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="KPICategory"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderKPICategoryAccuracy()
        {
            VerifyLookupReorder<KPICategory>();
        }

        #endregion KPICategory

        #region KeyControlsMaturity

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="KeyControlsMaturity"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateKeyControlsMaturityAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KeyControlsMaturity>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="KeyControlsMaturity"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateKeyControlsMaturityAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KeyControlsMaturity>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="KeyControlsMaturity"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteKeyControlsMaturityAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<KeyControlsMaturity>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="KeyControlsMaturity"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderKeyControlsMaturityAccuracy()
        {
            VerifyLookupReorder<KeyControlsMaturity>();
        }

        #endregion KeyControlsMaturity

        #region LikelihoodOfOccurrence

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="LikelihoodOfOccurrence"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateLikelihoodOfOccurrenceAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<LikelihoodOfOccurrence>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="LikelihoodOfOccurrence"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateLikelihoodOfOccurrenceAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<LikelihoodOfOccurrence>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="LikelihoodOfOccurrence"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteLikelihoodOfOccurrenceAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<LikelihoodOfOccurrence>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="LikelihoodOfOccurrence"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderLikelihoodOfOccurrenceAccuracy()
        {
            VerifyLookupReorder<LikelihoodOfOccurrence>();
        }

        #endregion LikelihoodOfOccurrence

        #region Percentage

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="Percentage"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreatePercentageAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Percentage>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="Percentage"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdatePercentageAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Percentage>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="Percentage"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeletePercentageAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Percentage>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="Percentage"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderPercentageAccuracy()
        {
            VerifyLookupReorder<Percentage>();
        }

        #endregion Percentage

        #region ProcessRisk

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="ProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ProcessRisk>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;
            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="ProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ProcessRisk>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.Id = 2;
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="ProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<ProcessRisk>(1);
            entity.ControlTypes = new List<ControlType>() { new ControlType { Id = 1111 } };
            entity.FunctionalAreaId = 1;
            entity.BusinessUnitId = 1;

            VerifyLookupDelete(entity, 1111);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="ProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderProcessRiskAccuracy()
        {
            VerifyLookupReorder<ProcessRisk>();
        }

        #endregion ProcessRisk

        #region Product

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="Product"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateProductAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Product>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="Product"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateProductAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Product>(1);
            entity.BusinessUnitId = 1;
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="Product"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteProductAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Product>(1);
            entity.BusinessUnitId = 1;

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="Product"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderProductAccuracy()
        {
            VerifyLookupReorder<Product>();
        }

        #endregion Product

        #region RiskExposure

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="RiskExposure"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateRiskExposureAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskExposure>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="RiskExposure"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateRiskExposureAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskExposure>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="RiskExposure"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteRiskExposureAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskExposure>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="RiskExposure"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderRiskExposureAccuracy()
        {
            VerifyLookupReorder<RiskExposure>();
        }

        #endregion RiskExposure

        #region RiskImpact

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="RiskImpact"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateRiskImpactAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskImpact>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="RiskImpact"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateRiskImpactAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskImpact>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="RiskImpact"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteRiskImpactAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskImpact>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="RiskImpact"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderRiskImpactAccuracy()
        {
            VerifyLookupReorder<RiskImpact>();
        }

        #endregion RiskImpact

        #region RiskScoreRange

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="RiskScoreRange"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateRiskScoreRangeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskScoreRange>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="RiskScoreRange"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateRiskScoreRangeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskScoreRange>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="RiskScoreRange"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteRiskScoreRangeAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<RiskScoreRange>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="RiskScoreRange"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderRiskScoreRangeAccuracy()
        {
            VerifyLookupReorder<RiskScoreRange>();
        }

        #endregion RiskScoreRange

        #region SLA

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="SLA"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateSLAAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SLA>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="SLA"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateSLAAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SLA>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="SLA"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteSLAAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SLA>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="SLA"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderSLAAccuracy()
        {
            VerifyLookupReorder<SLA>();
        }

        #endregion SLA

        #region Site

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="Site"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateSiteAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Site>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="Site"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateSiteAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Site>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="Site"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteSiteAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<Site>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="Site"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderSiteAccuracy()
        {
            VerifyLookupReorder<Site>();
        }

        #endregion Site

        #region SubProcessRisk

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="SubProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateSubProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SubProcessRisk>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="SubProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateSubProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SubProcessRisk>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="SubProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteSubProcessRiskAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<SubProcessRisk>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="SubProcessRisk"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderSubProcessRiskAccuracy()
        {
            VerifyLookupReorder<SubProcessRisk>();
        }

        #endregion SubProcessRisk

        #region TestingFrequency

        /// <summary>
        /// Accuracy test of <c>Create</c> method of <see cref="TestingFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestCreateTestingFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<TestingFrequency>(1);

            VerifyLookupCreate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Update</c> method of <see cref="TestingFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestUpdateTestingFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<TestingFrequency>(1);
            entity.Id = 2;

            VerifyLookupUpdate(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Delete</c> method of <see cref="TestingFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestDeleteTestingFrequencyAccuracy()
        {
            // arrange
            var entity = CreateTestEntity<TestingFrequency>(1);

            VerifyLookupDelete(entity);
        }

        /// <summary>
        /// Accuracy test of <c>Reorder</c> method of <see cref="TestingFrequency"/>
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestReorderTestingFrequencyAccuracy()
        {
            VerifyLookupReorder<TestingFrequency>();
        }

        #endregion TestingFrequency

        #endregion Admin related method tests

        #region private methods

        /// <summary>
        /// Verifies the lookup update operation.
        /// </summary>
        /// <typeparam name="T">They type of lookup entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="testName">The name of test method.</param>
        private void VerifyLookupCreate<T>(T entity, [CallerMemberName]string testName = null)
            where T : LookupEntity
        {
            // act
            T result = instance.Create(entity);

            // assert
            AssessLookupEntity(entity);

            ResetDynamicFields(result, true);
            AssertResult(result, testName);
        }

        /// <summary>
        /// Verifies the lookup update operation.
        /// </summary>
        /// <typeparam name="T">They type of lookup entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="testName">The name of test method.</param>
        private void VerifyLookupUpdate<T>(T entity, [CallerMemberName]string testName = null)
            where T : LookupEntity
        {
            // act
            T result = instance.Update(entity);

            // assert
            AssessLookupEntity(entity);

            ResetDynamicFields(result, false);
            AssertResult(result, testName);
        }

        /// <summary>
        /// Verifies the lookup delete operation.
        /// </summary>
        /// <typeparam name="T">They type of lookup entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The id to delete if provided won't create the entity.</param>
        /// <param name="testName">The name of test method.</param>
        private void VerifyLookupDelete<T>(T entity, long id = 0, [CallerMemberName]string testName = null)
            where T : LookupEntity
        {
            if (id == 0)
            {
                entity = instance.Create(entity);
                id = entity.Id;
            }

            // act
            instance.Delete<T>(id);

            // assert
            var parameters = new Dictionary<string, object>();
            parameters["Id"] = id;
            TestHelper.AssertDatabaseRecordCount(typeof(T).Name, parameters, 0);
        }

        /// <summary>
        /// Verifies the reorder operation of lookup entity.
        /// </summary>
        /// <typeparam name="T">They type of lookup entity.</typeparam>
        /// <param name="testName">The name of test method.</param>
        private void VerifyLookupReorder<T>([CallerMemberName]string testName = null)
            where T : LookupEntity
        {
            var ids = new long[] { 1, 2, 3 };
            var displayOrder = new int[] { 3, 2, 1 };

            // act
            instance.Reorder<T>(ids, displayOrder, "CoeusAdminUser");

            // assert
            var parameters = new Dictionary<string, object>();
            for (var i = 0; i < 3; i++)
            {
                parameters["id"] = ids[i];
                parameters["DisplayOrder"] = displayOrder[i];
                TestHelper.AssertDatabaseRecordExists(typeof(T).Name, parameters);
            }
        }

        /// <summary>
        /// Resets the dynamic fields.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="resetId">Determines whether Id should be reset.</param>
        private void ResetDynamicFields<T>(T entity, bool resetId = false) where T : IdentifiableEntity
        {
            if (resetId)
            {
                entity.Id = 0;
            }
            var properties = typeof(T).GetProperties().Where(p =>
            typeof(IdentifiableEntity).IsAssignableFrom(p.PropertyType) ||
            typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(p.PropertyType)).ToList();

            foreach (var property in properties)
            {
                if (typeof(IdentifiableEntity).IsAssignableFrom(property.PropertyType))
                {
                    var value = property.GetValue(entity, null) as IdentifiableEntity;
                    value.Id = 0;
                    property.SetValue(entity, value, null);
                }
                if (typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(property.PropertyType))
                {
                    dynamic items = null;
                    if (property.PropertyType == typeof(IList<SubProcessRisk>))
                    {
                        items = property.GetValue(entity, null) as IList<SubProcessRisk>;
                    }
                    else if (property.PropertyType == typeof(IList<ControlType>))
                    {
                        items = property.GetValue(entity, null) as IList<ControlType>;
                    }
                    else if (property.PropertyType == typeof(IList<KPI>))
                    {
                        items = property.GetValue(entity, null) as IList<KPI>;
                    }
                    else if (property.PropertyType == typeof(IList<SLA>))
                    {
                        items = property.GetValue(entity, null) as IList<SLA>;
                    }
                    if (items != null)
                    {
                        foreach (var val in items)
                        {
                            val.Id = 0;
                        }
                    }
                    property.SetValue(entity, items, null);
                }
            }
        }

        #endregion private methods
    }
}