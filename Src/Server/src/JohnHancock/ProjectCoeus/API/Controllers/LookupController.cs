/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.API.Entities;
using JohnHancock.ProjectCoeus.Entities;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common;
using JohnHancock.Common.API.Controllers;
using JohnHancock.ProjectCoeus.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace JohnHancock.ProjectCoeus.API.Controllers
{
    /// <summary>
    /// This controller exposes actions to retrieve lookup entities.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// <remarks>
    /// Changes in 1.1:
    /// - Added new methods for site, assessmentStatus and changeType
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    ///  <para>
    /// Changes in 1.3 during John Hancock - Project Coeus Admin Frontend Assembly Part 1
    /// </para>
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, veshu, albertwang</author>
    /// <version>1.3</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    [RoutePrefix("api/v1")]
    public class LookupController : BaseController
    {
        /// <summary>
        /// Gets or sets the <see cref="ILookupService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for retrieving lookup entities.
        /// </remarks>
        ///
        /// <value>The <see cref="ILookupService"/> dependency.</value>
        [Dependency]
        public ILookupService LookupService { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IAuditService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for creating audit records.
        /// </remarks>
        ///
        /// <value>The <see cref="IAuditService"/> dependency.</value>
        [Dependency]
        public IAuditService AuditService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupController"/> class.
        /// </summary>
        public LookupController()
        {
        }

        /// <summary>
        /// Checks that all configuration properties were properly initialized.
        /// </summary>
        ///
        /// <exception cref="ConfigurationException">
        /// If any of required injection fields are not injected or have invalid values.
        /// </exception>
        public override void CheckConfiguration()
        {
            base.CheckConfiguration();
            CommonHelper.ValidateConfigPropertyNotNull(LookupService, nameof(LookupService));
        }

        #region

        /// <summary>
        /// Retrieves all <see cref="AssessmentStatus"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("assessmentStatuses")]
        public IList<AssessmentStatus> GetAllAssessmentStatuses(bool includeDisabled = false)
        {
            return LookupService.GetAllAssessmentStatuses(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="ChangeType"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("changeTypes")]
        public IList<ChangeType> GetAllChangeTypes(bool includeDisabled = false)
        {
            return LookupService.GetAllChangeTypes(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Site"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("sites")]
        public IList<Site> GetAllSites(bool includeDisabled = false)
        {
            return LookupService.GetAllSites(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="BusinessUnit"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("businessUnits")]
        public IList<BusinessUnit> GetAllBusinessUnits(bool includeDisabled = false)
        {
            return LookupService.GetAllBusinessUnits(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="DepartmentHead"/> entities within a business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("departmentHeads")]
        public IList<DepartmentHead> GetAllDepartmentHeads(long businessUnitId, bool includeDisabled = false)
        {
            return LookupService.GetAllDepartmentHeads(businessUnitId, includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Product"/>  within a business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("products")]
        public IList<Product> GetAllProducts(long businessUnitId, bool includeDisabled = false)
        {
            return LookupService.GetAllProducts(businessUnitId, includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Department"/> entities within a business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("departments")]
        public IList<Department> GetAllDepartments(long businessUnitId, bool includeDisabled = false)
        {
            return LookupService.GetAllDepartments(businessUnitId, includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="AssessmentType"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("assessmentTypes")]
        public IList<AssessmentType> GetAllAssessmentTypes(bool includeDisabled = false)
        {
            return LookupService.GetAllAssessmentTypes(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="RiskExposure"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("riskExposures")]
        public IList<RiskExposure> GetAllRiskExposures(bool includeDisabled = false)
        {
            return LookupService.GetAllRiskExposures(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Category"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("categories")]
        public IList<Category> GetAllCategories(bool includeDisabled = false)
        {
            return LookupService.GetAllCategories(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="LikelihoodOfOccurrence"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("likelihoodOfOccurrences")]
        public IList<LikelihoodOfOccurrence> GetAllLikelihoodOfOccurrences(bool includeDisabled = false)
        {
            return LookupService.GetAllLikelihoodOfOccurrences(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="RiskImpact"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("riskImpacts")]
        public IList<RiskImpact> GetAllRiskImpacts(bool includeDisabled = false)
        {
            return LookupService.GetAllRiskImpacts(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="KPICategory"/> entities.
        /// </summary>
        /// <param name="businessUnitId">The optional business unit id.</param>
        /// <param name="functionalAreaId">The optional functional area Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">An optional flag whether to include global core processes</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("KPICategories")]
        public IList<KPICategory> GetKPICategories(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return LookupService.GetKPICategories(businessUnitId, functionalAreaId, includeDisabled, includeGlobal);
        }

        /// <summary>
        /// Retrieves all <see cref="ProcessRisk"/> entities.
        /// </summary>
        /// <param name="businessUnitId">The optional business unit id.</param>
        /// <param name="functionalAreaId">The optional functional area Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">An optional flag whether to include global core processes</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("processRisks")]
        public IList<ProcessRisk> GetAllProcessRisks(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return LookupService.GetAllProcessRisks(businessUnitId, functionalAreaId, includeDisabled, includeGlobal);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlFrequency"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("controlFrequencies")]
        public IList<ControlFrequency> GetAllControlFrequencies(bool includeDisabled = false)
        {
            return LookupService.GetAllControlFrequencies(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlTrigger"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("controlTriggers")]
        public IList<ControlTrigger> GetAllControlTriggers(bool includeDisabled = false)
        {
            return LookupService.GetAllControlTriggers(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="KeyControlsMaturity"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("keyControlsMaturities")]
        public IList<KeyControlsMaturity> GetAllKeyControlsMaturities(bool includeDisabled = false)
        {
            return LookupService.GetAllKeyControlsMaturities(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlDesign"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("controlDesigns")]
        public IList<ControlDesign> GetAllControlDesigns(bool includeDisabled = false)
        {
            return LookupService.GetAllControlDesigns(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="TestingFrequency"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("testingFrequencies")]
        public IList<TestingFrequency> GetAllTestingFrequencies(bool includeDisabled = false)
        {
            return LookupService.GetAllTestingFrequencies(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Percentage"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("percentages")]
        public IList<Percentage> GetAllPercentages(bool includeDisabled = false)
        {
            return LookupService.GetAllPercentages(includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="FunctionalAreaOwner"/> entities within business unit.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <param name="businessUnitId">The business unit Id.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("functionalAreaOwners")]
        public IList<FunctionalAreaOwner> GetFunctionalAreaOwners(long businessUnitId, bool includeDisabled = false)
        {
            return LookupService.GetFunctionalAreaOwners(businessUnitId, includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="CoreProcess"/> entities within functional area.
        /// </summary>
        /// <param name="businessUnitId">The optional business unit id.</param>
        /// <param name="functionalAreaId">The optional functional area Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">An optional flag whether to include global core processes</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("coreProcesses")]
        public IList<CoreProcess> GetCoreProcesses(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return LookupService.GetCoreProcesses(businessUnitId, functionalAreaId, includeDisabled, includeGlobal);
        }

        /// <summary>
        /// Retrieves all <see cref="FunctionalArea"/> entities within business unit.
        /// </summary>
        ///
        ///
        /// <param name="businessUnitId">The business unit Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("functionalAreas")]
        public IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, bool includeDisabled = false)
        {
            return LookupService.GetFunctionalAreas(businessUnitId, includeDisabled);
        }

        #endregion

        #region admin related methods

        /// <summary>
        /// Retrieves all <see cref="FunctionalArea"/> entities within a business unit and associated to a category.
        /// </summary>
        /// <param name="businessUnitId">The business ID.</param>
        /// <param name="categoryId">The category ID.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("functionalAreas")]
        public IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, long categoryId,
            bool includeDisabled = false)
        {
            return LookupService.GetFunctionalAreas(businessUnitId, categoryId, includeDisabled);
        }

        /// <summary>
        /// Retrieve all business units associated to a category.
        /// </summary>
        /// <param name="categoryId">The category ID.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("businessUnits")]
        public IList<BusinessUnit> GetAllBusinessUnits(long categoryId, bool includeDisabled = false)
        {
            return LookupService.GetBusinessUnits(categoryId, includeDisabled);
        }

        /// <summary>
        /// Create <see cref="AssessmentStatus"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("assessmentStatuses")]
        public AssessmentStatus CreateAssessmentStatus(AssessmentStatus entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="AssessmentStatus"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("assessmentStatuses/{id}")]
        public AssessmentStatus UpdateAssessmentStatus(long id, AssessmentStatus entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="AssessmentStatus"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("assessmentStatuses/{id}")]
        public void DeleteAssessmentStatus(long id)
        {
            LookupService.Delete<AssessmentStatus>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="AssessmentStatus"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("assessmentStatuses/reorder")]
        public void ReorderAssessmentStatuses(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<AssessmentStatus>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="AssessmentType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("assessmentTypes")]
        public AssessmentType CreateAssessmentType(AssessmentType entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="AssessmentType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("assessmentTypes/{id}")]
        public AssessmentType UpdateAssessmentType(long id, AssessmentType entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="AssessmentType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("assessmentTypes/{id}")]
        public void DeleteAssessmentType(long id)
        {
            LookupService.Delete<AssessmentType>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="AssessmentType"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("assessmentTypes/reorder")]
        public void ReorderAssessmentTypes(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<AssessmentType>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="BusinessUnit"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("businessUnits")]
        public BusinessUnit CreateBusinessUnit(BusinessUnit entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="BusinessUnit"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("businessUnits/{id}")]
        public BusinessUnit UpdateBusinessUnit(long id, BusinessUnit entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="BusinessUnit"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("businessUnits/{id}")]
        public void DeleteBusinessUnit(long id)
        {
            LookupService.Delete<BusinessUnit>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="BusinessUnit"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("businessUnits/reorder")]
        public void ReorderBusinessUnits(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<BusinessUnit>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="Department"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("departments")]
        public Department CreateDepartment(Department entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="Department"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("departments/{id}")]
        public Department UpdateDepartment(long id, Department entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="Department"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("departments/{id}")]
        public void DeleteDepartment(long id)
        {
            LookupService.Delete<Department>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="Department"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("departments/reorder")]
        public void ReorderDepartments(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<Department>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="DepartmentHead"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("departmentHeads")]
        public DepartmentHead CreateDepartmentHead(DepartmentHead entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="DepartmentHead"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("departmentHeads/{id}")]
        public DepartmentHead UpdateDepartmentHead(long id, DepartmentHead entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="DepartmentHead"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("departmentHeads/{id}")]
        public void DeleteDepartmentHead(long id)
        {
            LookupService.Delete<DepartmentHead>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="DepartmentHead"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("departmentHeads/reorder")]
        public void ReorderDepartmentHeads(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<DepartmentHead>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="FunctionalArea"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("functionalAreas")]
        public FunctionalArea CreateFunctionalArea(FunctionalArea entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="FunctionalArea"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("functionalAreas/{id}")]
        public FunctionalArea UpdateFunctionalArea(long id, FunctionalArea entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="FunctionalArea"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("functionalAreas/{id}")]
        public void DeleteFunctionalArea(long id)
        {
            LookupService.Delete<FunctionalArea>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="FunctionalArea"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("functionalAreas/reorder")]
        public void ReorderFunctionalAreas(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<FunctionalArea>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="FunctionalAreaOwner"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("functionalAreaOwners")]
        public FunctionalAreaOwner CreateFunctionalAreaOwner(FunctionalAreaOwner entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="FunctionalAreaOwner"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("functionalAreaOwners/{id}")]
        public FunctionalAreaOwner UpdateFunctionalAreaOwner(long id, FunctionalAreaOwner entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="FunctionalAreaOwner"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("functionalAreaOwners/{id}")]
        public void DeleteFunctionalAreaOwner(long id)
        {
            LookupService.Delete<FunctionalAreaOwner>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="FunctionalAreaOwner"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("functionalAreaOwners/reorder")]
        public void ReorderFunctionalAreaOwners(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<FunctionalAreaOwner>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="Product"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("products")]
        public Product CreateProduct(Product entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="Product"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("products/{id}")]
        public Product UpdateProduct(long id, Product entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="Product"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("products/{id}")]
        public void DeleteProduct(long id)
        {
            LookupService.Delete<Product>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="Product"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("products/reorder")]
        public void ReorderProducts(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<Product>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="Category"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ServiceException">If weight is outside of allowed range.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("categories")]
        public Category CreateCategory(Category entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CheckValueRange((double)entity.Weight, "weight of category");
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="Category"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ServiceException">If weight is outside of allowed range.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("categories/{id}")]
        public Category UpdateCategory(long id, Category entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CheckValueRange((double)entity.Weight, "weight of category");
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="Category"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("categories/{id}")]
        public void DeleteCategory(long id)
        {
            LookupService.Delete<Category>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="Category"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("categories/reorder")]
        public void ReorderCategories(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<Category>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ChangeType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("changeTypes")]
        public ChangeType CreateChangeType(ChangeType entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ChangeType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("changeTypes/{id}")]
        public ChangeType UpdateChangeType(long id, ChangeType entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ChangeType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("changeTypes/{id}")]
        public void DeleteChangeType(long id)
        {
            LookupService.Delete<ChangeType>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ChangeType"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("changeTypes/reorder")]
        public void ReorderChangeTypes(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ChangeType>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ControlDesign"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("controlDesigns")]
        public ControlDesign CreateControlDesign(ControlDesign entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ControlDesign"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlDesigns/{id}")]
        public ControlDesign UpdateControlDesign(long id, ControlDesign entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ControlDesign"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("controlDesigns/{id}")]
        public void DeleteControlDesign(long id)
        {
            LookupService.Delete<ControlDesign>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ControlDesign"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlDesigns/reorder")]
        public void ReorderControlDesigns(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ControlDesign>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ControlFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("controlFrequencies")]
        public ControlFrequency CreateControlFrequency(ControlFrequency entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ControlFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlFrequencies/{id}")]
        public ControlFrequency UpdateControlFrequency(long id, ControlFrequency entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ControlFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("controlFrequencies/{id}")]
        public void DeleteControlFrequency(long id)
        {
            LookupService.Delete<ControlFrequency>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ControlFrequency"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlFrequencies/reorder")]
        public void ReorderControlFrequencies(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ControlFrequency>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ControlTrigger"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("controlTriggers")]
        public ControlTrigger CreateControlTrigger(ControlTrigger entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ControlTrigger"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlTriggers/{id}")]
        public ControlTrigger UpdateControlTrigger(long id, ControlTrigger entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ControlTrigger"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("controlTriggers/{id}")]
        public void DeleteControlTrigger(long id)
        {
            LookupService.Delete<ControlTrigger>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ControlTrigger"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlTriggers/reorder")]
        public void ReorderControlTriggers(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ControlTrigger>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ControlType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("controlTypes")]
        public ControlType CreateControlType(ControlType entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ControlType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlTypes/{id}")]
        public ControlType UpdateControlType(long id, ControlType entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ControlType"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("controlTypes/{id}")]
        public void DeleteControlType(long id)
        {
            LookupService.Delete<ControlType>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ControlType"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("controlTypes/reorder")]
        public void ReorderControlTypes(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ControlType>(reorderRequest);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlType"/> entities.
        /// </summary>
        ///
        /// <param name="categoryId">The category id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("controlTypes")]
        public IList<ControlType> GetAllControlTypes(long categoryId, bool includeDisabled = false)
        {
            return LookupService.GetAllControlTypes(categoryId, includeDisabled);
        }

        /// <summary>
        /// Create <see cref="CoreProcess"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("coreProcesses")]
        public CoreProcess CreateCoreProcess(CoreProcess entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="CoreProcess"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("coreProcesses/{id}")]
        public CoreProcess UpdateCoreProcess(long id, CoreProcess entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="CoreProcess"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("coreProcesses/{id}")]
        public void DeleteCoreProcess(long id)
        {
            LookupService.Delete<CoreProcess>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="CoreProcess"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("coreProcesses/reorder")]
        public void ReorderCoreProcesses(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<CoreProcess>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="KeyControlsMaturity"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("keyControlsMaturities")]
        public KeyControlsMaturity CreateKeyControlsMaturity(KeyControlsMaturity entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="KeyControlsMaturity"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("keyControlsMaturities/{id}")]
        public KeyControlsMaturity UpdateKeyControlsMaturity(long id, KeyControlsMaturity entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="KeyControlsMaturity"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("keyControlsMaturities/{id}")]
        public void DeleteKeyControlsMaturity(long id)
        {
            LookupService.Delete<KeyControlsMaturity>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="KeyControlsMaturity"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("keyControlsMaturities/reorder")]
        public void ReorderKeyControlsMaturities(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<KeyControlsMaturity>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="KPI"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("kpis")]
        public KPI CreateKPI(KPI entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CommonHelper.ValidateArgumentNotNull(entity.KPICategory, nameof(entity.KPICategory));

            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="KPI"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("kpis/{id}")]
        public KPI UpdateKPI(long id, KPI entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CommonHelper.ValidateArgumentNotNull(entity.KPICategory, nameof(entity.KPICategory));

            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="KPI"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("kpis/{id}")]
        public void DeleteKPI(long id)
        {
            LookupService.Delete<KPI>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="KPI"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("kpis/reorder")]
        public void ReorderKPIs(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<KPI>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="KPICategory"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("kpiCategories")]
        public KPICategory CreateKPICategory(KPICategory entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="KPICategory"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("kpiCategories/{id}")]
        public KPICategory UpdateKPICategory(long id, KPICategory entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="KPICategory"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("kpiCategories/{id}")]
        public void DeleteKPICategory(long id)
        {
            LookupService.Delete<KPICategory>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="KPICategory"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("kpiCategories/reorder")]
        public void ReorderKPICategories(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<KPICategory>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="LikelihoodOfOccurrence"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("likelihoodOfOccurrences")]
        public LikelihoodOfOccurrence CreateLikelihoodOfOccurrence(LikelihoodOfOccurrence entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="LikelihoodOfOccurrence"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("likelihoodOfOccurrences/{id}")]
        public LikelihoodOfOccurrence UpdateLikelihoodOfOccurrence(long id, LikelihoodOfOccurrence entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="LikelihoodOfOccurrence"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("likelihoodOfOccurrences/{id}")]
        public void DeleteLikelihoodOfOccurrence(long id)
        {
            LookupService.Delete<LikelihoodOfOccurrence>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="LikelihoodOfOccurrence"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("likelihoodOfOccurrences/reorder")]
        public void ReorderLikelihoodOfOccurrences(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<LikelihoodOfOccurrence>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="Percentage"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ServiceException">If value is outside of allowed range.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("percentages")]
        public Percentage CreatePercentage(Percentage entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CheckValueRange(entity.Value, "percentage value");
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="Percentage"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("percentages/{id}")]
        public Percentage UpdatePercentage(long id, Percentage entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            CheckValueRange(entity.Value, "percentage value");
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="Percentage"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("percentages/{id}")]
        public void DeletePercentage(long id)
        {
            LookupService.Delete<Percentage>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="Percentage"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("percentages/reorder")]
        public void ReorderPercentages(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<Percentage>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="ProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("processRisks")]
        public ProcessRisk CreateProcessRisk(ProcessRisk entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="ProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("processRisks/{id}")]
        public ProcessRisk UpdateProcessRisk(long id, ProcessRisk entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="ProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("processRisks/{id}")]
        public void DeleteProcessRisk(long id)
        {
            LookupService.Delete<ProcessRisk>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="ProcessRisk"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("processRisks/reorder")]
        public void ReorderProcessRisks(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<ProcessRisk>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="SubProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("subProcessRisks")]
        public SubProcessRisk CreateSubProcessRisk(SubProcessRisk entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="SubProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("subProcessRisks/{id}")]
        public SubProcessRisk UpdateSubProcessRisk(long id, SubProcessRisk entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="SubProcessRisk"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("subProcessRisks/{id}")]
        public void DeleteSubProcessRisk(long id)
        {
            LookupService.Delete<SubProcessRisk>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="SubProcessRisk"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("subProcessRisks/reorder")]
        public void ReorderSubProcessRisks(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<SubProcessRisk>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="RiskExposure"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("riskExposures")]
        public RiskExposure CreateRiskExposure(RiskExposure entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="RiskExposure"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("riskExposures/{id}")]
        public RiskExposure UpdateRiskExposure(long id, RiskExposure entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="RiskExposure"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("riskExposures/{id}")]
        public void DeleteRiskExposure(long id)
        {
            LookupService.Delete<RiskExposure>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="RiskExposure"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("riskExposures/reorder")]
        public void ReorderRiskExposures(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<RiskExposure>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="RiskImpact"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("riskImpacts")]
        public RiskImpact CreateRiskImpact(RiskImpact entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="RiskImpact"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("riskImpacts/{id}")]
        public RiskImpact UpdateRiskImpact(long id, RiskImpact entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="RiskImpact"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("riskImpacts/{id}")]
        public void DeleteRiskImpact(long id)
        {
            LookupService.Delete<RiskImpact>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="RiskImpact"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("riskImpacts/reorder")]
        public void ReorderRiskImpacts(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<RiskImpact>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="Site"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("sites")]
        public Site CreateSite(Site entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="Site"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("sites/{id}")]
        public Site UpdateSite(long id, Site entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="Site"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("sites/{id}")]
        public void DeleteSite(long id)
        {
            LookupService.Delete<Site>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="Site"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("sites/reorder")]
        public void ReorderSites(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<Site>(reorderRequest);
        }

        /// <summary>
        /// Create <see cref="SLA"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("slas")]
        public SLA CreateSLA(SLA entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="SLA"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("slas/{id}")]
        public SLA UpdateSLA(long id, SLA entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="SLA"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("slas/{id}")]
        public void DeleteSLA(long id)
        {
            LookupService.Delete<SLA>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="SLA"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("slas/reorder")]
        public void ReorderSLAs(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<SLA>(reorderRequest);
        }

        /// <summary>
        /// Retrieves all <see cref="SLA"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("slas")]
        public IList<SLA> GetAllSLAs(bool includeDisabled = false)
        {
            return LookupService.GetAllSLAs(includeDisabled);
        }

        /// <summary>
        /// Create <see cref="TestingFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("testingFrequencies")]
        public TestingFrequency CreateTestingFrequency(TestingFrequency entity)
        {
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="TestingFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("testingFrequencies/{id}")]
        public TestingFrequency UpdateTestingFrequency(long id, TestingFrequency entity)
        {
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="TestingFrequency"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("testingFrequencies/{id}")]
        public void DeleteTestingFrequency(long id)
        {
            LookupService.Delete<TestingFrequency>(id);
        }

        /// <summary>
        /// This method is used to reorder <see cref="TestingFrequency"/> entities.
        /// </summary>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("testingFrequencies/reorder")]
        public void ReorderTestingFrequencies(LookupEntityReorderRequest reorderRequest)
        {
            ReorderLookupEntities<TestingFrequency>(reorderRequest);
        }

        /// <summary>
        /// Get all pending add-ons.
        /// </summary>
        ///
        /// <returns>The lookup entities in Pending Add-on status.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("pendingAddOns")]
        public IList<LookupEntity> GetPendingAddOns()
        {
            return LookupService.GetPendingAddOns();
        }

        /// <summary>
        /// Get count of pending add-ons.
        /// </summary>
        ///
        /// <returns>The count of pending add-ons.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("countOfPendingAddOns")]
        public int CountPendingAddOns()
        {
            return LookupService.CountPendingAddOns();
        }

        /// <summary>
        /// Import lookup entities from uploaded Excel file.
        /// </summary>
        ///
        /// <returns>The <see cref="Task"/> to do the import job.</returns>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("importLookupEntities")]
        public HttpResponseMessage Import()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            Task.Factory.StartNew(() => Request.Content.ReadAsMultipartAsync(provider),
                             CancellationToken.None,
                             TaskCreationOptions.LongRunning, // guarantees separate thread
                             TaskScheduler.Default).Wait();
            if (provider.Contents.Count == 0)
            {
                throw new ServiceException("The request doesn't contain file");
            }
            var mediaType = provider.Contents[0].Headers.ContentType.MediaType;
            if (!mediaType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                throw new ServiceException("The file must be valid excel(.xlsx) file");
            }
            using (var stream = provider.Contents[0].ReadAsStreamAsync().Result)
            {
                LookupService.Import(stream, CurrentUser.Username);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Create <see cref="RiskScoreRange"/> lookup entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ServiceException">If risk score range contains negative lower bound or
        /// upper bound less than the lower bound.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPost]
        [Route("riskScoreRanges")]
        public RiskScoreRange CreateRiskScoreRange(RiskScoreRange entity)
        {
            ValidateAndPrepareRiskScore(entity);
            return CreateLookupEntity(entity);
        }

        /// <summary>
        /// Update <see cref="RiskScoreRange"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ServiceException">If risk score range contains negative lower bound or
        /// upper bound less than the lower bound.</exception>
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpPut]
        [Route("riskScoreRanges/{id}")]
        public RiskScoreRange UpdateRiskScoreRange(long id, RiskScoreRange entity)
        {
            ValidateAndPrepareRiskScore(entity);
            return UpdateLookupEntity(id, entity);
        }

        /// <summary>
        /// Delete <see cref="RiskScoreRange"/> lookup entity.
        /// </summary>
        ///
        /// <param name="id">The Id.</param>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpDelete]
        [Route("riskScoreRanges/{id}")]
        public void DeleteRiskScoreRange(long id)
        {
            LookupService.Delete<RiskScoreRange>(id);
        }

        /// <summary>
        /// Retrieve all risk score ranges.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The entities.</returns>
        ///
        /// <remarks>All exceptions from back-end services will be propagated.</remarks>
        [HttpGet]
        [Route("riskScoreRanges")]
        public IList<RiskScoreRange> GetAllRiskScoreRanges(bool includeDisabled = false)
        {
            return LookupService.GetAllRiskScoreRanges(includeDisabled);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Creates the lookup entity.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity to create.</typeparam>
        /// <param name="entity">The lookup entity to create</param>
        /// <returns>The created entity</returns>
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <remarks>All other exceptions from back-end service or this method will be propagated.</remarks>
        private T CreateLookupEntity<T>(T entity) where T : LookupEntity
        {
            return WithTransaction(() =>
            {
                CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));

                // populate audit fields
                PopulateAuditFields(entity, null, true);

                // create record
                T result = LookupService.Create(entity);

                Helper.Audit(AuditService, null, result,
                     CommonHelper.GetFullActionName(ActionContext, includeController: false),
                     CurrentUser.Username);

                return result;
            });
        }

        /// <summary>
        /// Updates the lookup entity.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity to update.</typeparam>
        /// <param name="id">The entity id.</param>
        /// <param name="entity">The lookup entity to update</param>
        /// <returns>The updated entity</returns>
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="EntityNotFoundException">If entity is not found.</exception>
        /// <remarks>All other exceptions from back-end service or this method will be propagated.</remarks>
        private T UpdateLookupEntity<T>(long id, T entity) where T : LookupEntity
        {
            return WithTransaction(() =>
            {
                CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));

                var existings = LookupService.Get<T>(new List<long> { id });

                CommonHelper.CheckFoundEntity(existings.First(), id);

                // populate audit fields
                PopulateAuditFields(entity, existings.First());

                // update
                var newEntity = LookupService.Update(entity);

                Helper.Audit(AuditService, existings.First(), newEntity,
                     CommonHelper.GetFullActionName(ActionContext, includeController: false),
                     CurrentUser.Username);
                return newEntity;
            });
        }

        /// <summary>
        /// Reorders the lookup entities
        /// </summary>
        /// <typeparam name="T">The type of lookup entity to reorder.</typeparam>
        ///
        /// <param name="reorderRequest">The reorder request.</param>
        ///
        /// <exception cref="ArgumentNullException">If reorderRequest is null.</exception>
        /// <remarks>All other exceptions from back-end service or this method will be propagated.</remarks>
        private void ReorderLookupEntities<T>(LookupEntityReorderRequest reorderRequest)
            where T : LookupEntity, new()
        {
            WithTransaction(() =>
            {
                CommonHelper.ValidateArgumentNotNull(reorderRequest, nameof(reorderRequest));
                var existings = LookupService.Get<T>(reorderRequest.Ids).OrderBy(p => p.Id).ToList();
                LookupService.Reorder<T>(reorderRequest.Ids, reorderRequest.DisplayOrders, CurrentUser.Username);
                var updated = LookupService.Get<T>(reorderRequest.Ids).OrderBy(p => p.Id).ToList();
                for (int i = 0; i < existings.Count; i++)
                {
                    Helper.Audit(AuditService, existings[i], updated[i],
                     CommonHelper.GetFullActionName(ActionContext, includeController: false),
                     CurrentUser.Username);
                }
            });
        }

        /// <summary>
        /// Validates and prepares the risk score range entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="ArgumentException">If upper bound is less than lower bound or
        /// either lower bound is null or not positive</exception>
        /// <remarks>Any other exceptions will be propagated to caller.</remarks>
        private static void ValidateAndPrepareRiskScore(RiskScoreRange entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            Helper.ValidateRiskScoreEntities(new List<RiskScoreRange> { entity });
        }

        /// <summary>
        /// Validates the value is within given range or not.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="name">The name of value.</param>
        /// <param name="lowerRange">The optional lower end of allowed range.</param>
        /// <param name="upperRange">The optional upper end of allowed range.</param>
        /// <exception cref="ServiceException">If value is outside of allowed range.</exception>
        private static void CheckValueRange(double value, string name, double lowerRange = 1, double upperRange = 100)
        {
            if (value < lowerRange || value > upperRange)
            {
                throw new ServiceException($"The {name} must be within {lowerRange} and {upperRange}");
            }
        }

        #endregion
    }
}