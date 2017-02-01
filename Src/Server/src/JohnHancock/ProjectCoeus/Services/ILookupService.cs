/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.ProjectCoeus.Services
{
    /// <summary>
    /// This service interface defines methods to retrieve lookup entities.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// - Added new methods for site, assessmentStatus and changeType</remarks>
    ///
    /// <remarks>
    /// <para>
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// - new methods are added to address new admin features.
    /// - updated
    /// </para>
    ///  <para>
    /// Changes in 1.3 during John Hancock - Project Coeus Admin Frontend Assembly Part 1
    /// </para>
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, veshu, albertwang, veshu</author>
    /// <version>1.3</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public interface ILookupService
    {
        #region Get All methods

        /// <summary>
        /// Retrieves all <see cref="AssessmentStatus"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<AssessmentStatus> GetAllAssessmentStatuses(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="ChangeType"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ChangeType> GetAllChangeTypes(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="Site"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<Site> GetAllSites(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="BusinessUnit"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<BusinessUnit> GetAllBusinessUnits(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="DepartmentHead"/> entities within a business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<DepartmentHead> GetAllDepartmentHeads(long businessUnitId, bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="Product"/> entities within a business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<Product> GetAllProducts(long businessUnitId, bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="Department"/> entities within a business unit.
        /// </summary>
        ///
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<Department> GetAllDepartments(long businessUnitId, bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="AssessmentType"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<AssessmentType> GetAllAssessmentTypes(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="RiskExposure"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<RiskExposure> GetAllRiskExposures(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="Category"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<Category> GetAllCategories(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="LikelihoodOfOccurrence"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<LikelihoodOfOccurrence> GetAllLikelihoodOfOccurrences(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="RiskImpact"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<RiskImpact> GetAllRiskImpacts(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="KPICategory"/> entities.
        /// </summary>
        ///
        /// <param name="businessUnitId">The optional business unit id.</param>
        /// <param name="functionalAreaId">The optional functional area Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">An optional flag whether to include global core processes</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<KPICategory> GetKPICategories(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true);

        /// <summary>
        /// Retrieves all <see cref="ProcessRisk"/> entities.
        /// </summary>
        ///
        /// <param name="businessUnitId">The optional business unit id.</param>
        /// <param name="functionalAreaId">The optional functional area Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">An optional flag whether to include global core processes</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ProcessRisk> GetAllProcessRisks(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true);

        /// <summary>
        /// Retrieves all <see cref="ControlFrequency"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ControlFrequency> GetAllControlFrequencies(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="ControlTrigger"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ControlTrigger> GetAllControlTriggers(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="KeyControlsMaturity"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<KeyControlsMaturity> GetAllKeyControlsMaturities(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="ControlDesign"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ControlDesign> GetAllControlDesigns(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="TestingFrequency"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<TestingFrequency> GetAllTestingFrequencies(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="Percentage"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<Percentage> GetAllPercentages(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="FunctionalAreaOwner"/> entities within business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<FunctionalAreaOwner> GetFunctionalAreaOwners(long businessUnitId, bool includeDisabled = false);

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
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> or <paramref name="functionalAreaId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        IList<CoreProcess> GetCoreProcesses(long? businessUnitId, long? functionalAreaId,
            bool includeDisabled = false, bool includeGlobal = true);

        /// <summary>
        /// Retrieves all <see cref="FunctionalArea"/> entities within business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit Id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, bool includeDisabled = false);

        #endregion Get All methods

        #region admin methods

        /// <summary>
        /// Retrieves all FunctionalArea entities within a business unit, for a category.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit ID.</param>
        /// <param name="categoryId">The category ID</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">If businessUnitId/categoryId is not positive.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, long categoryId, bool includeDisabled = false);

        /// <summary>
        /// Retrieves all BusinessUnit entities for a category including global(without category).
        /// </summary>
        ///
        /// <param name="categoryId">The category ID</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">If categoryId is not positive.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        IList<BusinessUnit> GetBusinessUnits(long categoryId, bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="SLA"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        IList<SLA> GetAllSLAs(bool includeDisabled = false);

        /// <summary>
        /// Retrieves all <see cref="ControlType"/> entities for given category.
        /// </summary>
        ///
        /// <param name="categoryId">The category id.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">If categoryId is not positive.</exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        IList<ControlType> GetAllControlTypes(long categoryId, bool includeDisabled = false);

        /// <summary>
        /// This method is used to create new entity.
        /// </summary>
        ///
        /// <typeparam name="T">The entity type, should extend LookupEntity.</typeparam>
        ///
        /// <param name="entity">The entity to create.</param>
        ///
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        T Create<T>(T entity) where T : LookupEntity;

        /// <summary>
        /// This method is used to update an entity.
        /// </summary>
        ///
        /// <typeparam name="T">The entity type, should extend LookupEntity.</typeparam>
        ///
        /// <param name="entity">The entity to update.</param>
        ///
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If entity is null.</exception>
        /// <exception cref="EntityNotFoundException">If the entity does not exist.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        T Update<T>(T entity) where T : LookupEntity;

        /// <summary>
        /// Retrieves lookup with the given Id.
        /// </summary>
        ///
        /// <param name="ids">The ids of the entities to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If <paramref name="ids"/> is null.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        IList<T> Get<T>(IList<long> ids) where T : LookupEntity;

        /// <summary>
        /// This method is used to delete an entity.
        /// </summary>
        ///
        /// <typeparam name="T">The entity type, should extend LookupEntity.</typeparam>
        ///
        /// <param name="id">The id of the entity to delete.</param>
        ///
        /// <exception cref="ArgumentException">If id is not positive.</exception>
        /// <exception cref="EntityNotFoundException">If entity with given id does not exist.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        void Delete<T>(long id) where T : LookupEntity;

        /// <summary>
        /// This method is used to reorder entities of a given type.
        /// </summary>
        ///
        /// <typeparam name="T">The entity type, should extend LookupEntity.</typeparam>
        ///
        /// <param name="ids">The ids.</param>
        /// <param name="displayOrders">The display orders.</param>
        /// <param name="username">The current username.</param>
        ///
        /// <exception cref="ArgumentNullException">
        /// If either ids or displayOrders or username argument is null</exception>
        /// <exception cref="ArgumentException">
        /// If any id is not positive or username is empty or
        /// the lengths of ids and displayOrders aren't the same or either argument is empty.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the lengths of ids and displayOrders aren't the same.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with any id does not exist.</exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        void Reorder<T>(long[] ids, int[] displayOrders, string username) where T : LookupEntity;

        /// <summary>
        /// Get all pending add-ons.
        /// </summary>
        ///
        /// <returns>The lookup entities in Pending Add-on status.</returns>
        ///
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.
        /// </exception>
        IList<LookupEntity> GetPendingAddOns();

        /// <summary>
        /// Get count of pending add-ons.
        /// </summary>
        ///
        /// <returns>The count of pending add-ons.</returns>
        ///
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        int CountPendingAddOns();

        /// <summary>
        /// This method is used to import lookup entities from stream.
        /// </summary>
        ///
        /// <param name="stream">The stream</param>
        /// <param name="currentUsername">The current username.</param>
        ///
        /// <exception cref="ArgumentNullException">If stream or
        /// <paramref name="currentUsername"/>is null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="currentUsername"/> is empty.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        void Import(Stream stream, string currentUsername);

        /// <summary>
        /// Retrieves all risk score ranges.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        IList<RiskScoreRange> GetAllRiskScoreRanges(bool includeDisabled = false);

        #endregion admin methods
    }
}