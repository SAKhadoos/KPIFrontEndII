/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using ClosedXML.Excel;
using JohnHancock.ProjectCoeus.Entities;
using JohnHancock.Common.Services.Impl;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common;
using JohnHancock.Common.Entities;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Transactions;

namespace JohnHancock.ProjectCoeus.Services.Impl
{
    /// <summary>
    /// This service class provides operations for retrieving lookup entities.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// <remarks>
    /// <para>
    /// Changes in 1.1:
    /// - Added new methods for site, assessmentStatus and changeType
    /// </para>
    /// <para>
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// - updated 'GetAll' method to honor AddOnStatus, Enabled and DisplayOrder in the query</para>
    /// <para>
    /// Changes in 1.3 during John Hancock - Project Coeus Admin Frontend Assembly Part 1
    /// </para>
    /// <para>
    /// Changed in 1.4 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
    /// </para>
    /// </remarks>
    ///
    /// <author>LOY, NightWolf, veshu, TCSASSEMBLER</author>
    /// <version>1.4</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class LookupService : BasePersistenceService<CustomDbContext>, ILookupService
    {
        /// <summary>
        /// The cached properties of the entity type.
        /// </summary>
        private static readonly IDictionary<Type, ICollection<PropertyInfo>> Properties =
            new Dictionary<Type, ICollection<PropertyInfo>>();

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
        /// Initializes a new instance of the <see cref="LookupService"/> class.
        /// </summary>
        public LookupService()
        {
        }

        #region Get All methods

        /// <summary>
        /// Retrieves all <see cref="AssessmentStatus"/> entities.
        /// </summary>
        ///
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<AssessmentStatus> GetAllAssessmentStatuses(bool includeDisabled = false)
        {
            return GetAll<AssessmentStatus>(includeDisabled: includeDisabled);
        }

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
        public IList<ChangeType> GetAllChangeTypes(bool includeDisabled = false)
        {
            return GetAll<ChangeType>(includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="Site"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<Site> GetAllSites(bool includeDisabled = false)
        {
            return GetAll<Site>(includeDisabled: includeDisabled);
        }

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
        public IList<BusinessUnit> GetAllBusinessUnits(bool includeDisabled = false)
        {
            return GetAll<BusinessUnit>(includeChildren: q => q.Include(p => p.Category),
                includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="DepartmentHead"/> entities within a business unit.
        /// </summary>
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
        public IList<DepartmentHead> GetAllDepartmentHeads(long businessUnitId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                return GetAll<DepartmentHead>(predicate: p => p.BusinessUnitId == businessUnitId,
                    includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(DepartmentHead).Name} entities",
                parameters: new object[] { businessUnitId, includeDisabled });
        }

        /// <summary>
        /// Retrieves all <see cref="Product"/> entities within a business unit.
        /// </summary>
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
        public IList<Product> GetAllProducts(long businessUnitId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                return GetAll<Product>(predicate: p => p.BusinessUnitId == businessUnitId,
                    includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(Product).Name} entities",
                parameters: new object[] { businessUnitId, includeDisabled });
        }

        /// <summary>
        /// Retrieves all <see cref="Department"/> entities within a business unit.
        /// </summary>
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
        public IList<Department> GetAllDepartments(long businessUnitId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                return GetAll<Department>(predicate: p => p.BusinessUnitId == businessUnitId,
                     includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(Department).Name} entities",
                parameters: new object[] { businessUnitId, includeDisabled });
        }

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
        public IList<AssessmentType> GetAllAssessmentTypes(bool includeDisabled = false)
        {
            return GetAll<AssessmentType>(includeDisabled: includeDisabled);
        }

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
        public IList<RiskExposure> GetAllRiskExposures(bool includeDisabled = false)
        {
            return GetAll<RiskExposure>(includeDisabled: includeDisabled);
        }

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
        public IList<Category> GetAllCategories(bool includeDisabled = false)
        {
            return GetAll<Category>(includeDisabled: includeDisabled);
        }

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
        public IList<LikelihoodOfOccurrence> GetAllLikelihoodOfOccurrences(bool includeDisabled = false)
        {
            return GetAll<LikelihoodOfOccurrence>(includeDisabled: includeDisabled);
        }

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
        public IList<RiskImpact> GetAllRiskImpacts(bool includeDisabled = false)
        {
            return GetAll<RiskImpact>(includeDisabled: includeDisabled);
        }

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
        public IList<KPICategory> GetKPICategories(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return GetAllBusinessUnitFuncationalArea<KPICategory>(businessUnitId, functionalAreaId,
            includeChildren: q => q.Include(x => x.SLAs).Include(p => p.KPIs),
            includeDisabled: includeDisabled, includeGlobal: includeGlobal);
        }

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
        public IList<ProcessRisk> GetAllProcessRisks(long? businessUnitId = null, long? functionalAreaId = null,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return GetAllBusinessUnitFuncationalArea<ProcessRisk>(businessUnitId, functionalAreaId,
            includeChildren: q => q.Include(x => x.Category).Include(x => x.ControlTypes),
            includeDisabled: includeDisabled, includeGlobal: includeGlobal);
        }

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
        public IList<ControlFrequency> GetAllControlFrequencies(bool includeDisabled = false)
        {
            return GetAll<ControlFrequency>(includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlTrigger"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<ControlTrigger> GetAllControlTriggers(bool includeDisabled = false)
        {
            return GetAll<ControlTrigger>(includeDisabled: includeDisabled);
        }

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
        public IList<KeyControlsMaturity> GetAllKeyControlsMaturities(bool includeDisabled = false)
        {
            return GetAll<KeyControlsMaturity>(includeDisabled: includeDisabled);
        }

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
        public IList<ControlDesign> GetAllControlDesigns(bool includeDisabled = false)
        {
            return GetAll<ControlDesign>(includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="TestingFrequency"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<TestingFrequency> GetAllTestingFrequencies(bool includeDisabled = false)
        {
            return GetAll<TestingFrequency>(includeDisabled: includeDisabled);
        }

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
        public IList<Percentage> GetAllPercentages(bool includeDisabled = false)
        {
            return GetAll<Percentage>(includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="FunctionalAreaOwner"/> entities within business unit.
        /// </summary>
        ///
        /// <param name="businessUnitId">The business unit Id.</param>
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
        public IList<FunctionalAreaOwner> GetFunctionalAreaOwners(long businessUnitId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                return GetAll<FunctionalAreaOwner>(predicate: p => p.BusinessUnitId == businessUnitId,
                     includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(FunctionalAreaOwner).Name} entities",
                parameters: new object[] { businessUnitId, includeDisabled });
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
        /// <exception cref="ArgumentException">
        /// If <paramref name="businessUnitId"/> or <paramref name="functionalAreaId"/> is not positive.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<CoreProcess> GetCoreProcesses(long? businessUnitId, long? functionalAreaId,
            bool includeDisabled = false, bool includeGlobal = true)
        {
            return GetAllBusinessUnitFuncationalArea<CoreProcess>(businessUnitId, functionalAreaId,
                includeChildren: query => query.Include(x => x.Category).Include(x => x.SubProcessRisks)
                .Include(x => x.ControlTypes), includeDisabled: includeDisabled, includeGlobal: includeGlobal);
        }

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
        public IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                return GetAll<FunctionalArea>(p => p.BusinessUnitId == businessUnitId,
                   includeChildren: query => query.Include(x => x.Category),
                    includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(FunctionalArea).Name} entities",
                parameters: new object[] { businessUnitId, includeDisabled });
        }

        #endregion Get All methods

        #region admin related methods

        /// <summary>
        /// Retrieves all <see cref="SLA"/> entities.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<SLA> GetAllSLAs(bool includeDisabled = false)
        {
            return GetAll<SLA>(includeDisabled: includeDisabled);
        }

        /// <summary>
        /// Retrieves all <see cref="ControlType"/> entities for given category.
        /// </summary>
        ///
        /// <param name="categoryId">The category id</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentException">If categoryId is not positive.</exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        public IList<ControlType> GetAllControlTypes(long categoryId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(categoryId, nameof(categoryId));

                return GetAll<ControlType>(p => p.Category.Id == categoryId,
                   includeChildren: query => query.Include(x => x.Category),
                    includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(ControlType).Name} entities",
                parameters: new object[] { categoryId, includeDisabled });
        }

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
        public IList<FunctionalArea> GetFunctionalAreas(long businessUnitId, long categoryId
            , bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                CommonHelper.ValidateArgumentPositive(categoryId, nameof(categoryId));

                return GetAll<FunctionalArea>(p => p.BusinessUnitId == businessUnitId &&
                (p.Category.Id == categoryId || p.Category == null),
                  includeChildren: query => query.Include(x => x.Category),
                   includeDisabled: includeDisabled);
            },
                $"retrieving {typeof(FunctionalArea).Name} entities",
                parameters: new object[] { businessUnitId, categoryId, includeDisabled });
        }

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
        public IList<BusinessUnit> GetBusinessUnits(long categoryId, bool includeDisabled = false)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(categoryId, nameof(categoryId));

                return GetAll<BusinessUnit>(p => (p.Category.Id == categoryId || p.Category == null),
                  includeChildren: query => query.Include(x => x.Category),
                   includeDisabled: includeDisabled);
            }, $"retrieving {typeof(BusinessUnit).Name} entities",
                parameters: new object[] { categoryId, includeDisabled });
        }

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
        public T Create<T>(T entity) where T : LookupEntity
        {
            return ProcessWithDb(db =>
            {
                try
                {
                    CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));

                    entity = Create(entity, db, true);
                }
                catch (Exception ex)
                {
                    Helper.HandleCreateOrUpdateException(ex, typeof(T).Name);
                }

                return Get<T>(db, entity.Id);
            }, $"creating the {typeof(T).Name} entity", parameters: entity);
        }

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
        public T Update<T>(T entity) where T : LookupEntity
        {
            return ProcessWithDb(db =>
            {
                try
                {
                    CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
                    using (var tx = new TransactionScope())
                    {
                        var existing = Get<T>(db, entity.Id, "entity.Id");

                        Update(entity, db, existing, true);

                        tx.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Helper.HandleCreateOrUpdateException(ex, typeof(T).Name);
                }
                return Get<T>(db, entity.Id);
            }, $"updating the {typeof(T).Name} entity", parameters: entity);
        }

        /// <summary>
        /// Retrieves lookup with the given Ids.
        /// </summary>
        ///
        /// <param name="ids">The ids of the entities to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">If <paramref name="ids"/> is null.</exception>
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        public IList<T> Get<T>(IList<long> ids) where T : LookupEntity
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(ids, nameof(ids));

                IQueryable<T> query = db.Set<T>();
                query = query.Where(p => ids.Contains(p.Id));
                query = IncludeNavigationProperties(query);

                return query.ToList();
            }, $"retrieving the {typeof(T).Name} entity", parameters: ids);
        }

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
        public void Delete<T>(long id) where T : LookupEntity
        {
            ProcessWithDb(db =>
            {
                try
                {
                    CommonHelper.ValidateArgumentPositive(id, nameof(id));
                    using (var tx = new TransactionScope())
                    {
                        var existing = db.Set<T>().FirstOrDefault(e => e.Id == id);

                        CommonHelper.CheckFoundEntity(existing, id);

                        DeleteReferencedEntities(db, existing);

                        db.Set(typeof(T)).Remove(existing);

                        db.SaveChanges();

                        tx.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Helper.HandleDeleteException(ex, typeof(T).Name);
                }
            }, $"deleting the {typeof(T).Name} entity with id={id}",
                parameters: id);
        }

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
        public void Reorder<T>(long[] ids, int[] displayOrders, string username) where T : LookupEntity
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidatePositiveArray(ids, nameof(ids));
                CommonHelper.ValidatePositiveArray(displayOrders, nameof(displayOrders));
                if (ids.Length != displayOrders.Length)
                {
                    throw new ArgumentException($"The {nameof(ids)} and {nameof(displayOrders)} should "
                                                + "contain same number of items");
                }

                // get all records with given ids.
                var existingRecords = db.Set<T>().Where(p => ids.Contains(p.Id)).ToList();
                if (existingRecords.Count != ids.Length)
                {
                    var notFoundIds = string.Join(", ", ids.Except(existingRecords.Select(p => p.Id).ToArray()));

                    throw new EntityNotFoundException(
                        $"{typeof(T).Name} with Id(s)=({notFoundIds}) was not found.");
                }

                var mapping = ids.Zip(displayOrders, (a, b) => new { Id = a, DisplayOrder = b });

                DateTime now = DateTime.Now;
                // assign the new order and mark the state as modified
                existingRecords.ForEach(p =>
                {
                    p.DisplayOrder = mapping.Single(q => q.Id == p.Id).DisplayOrder;
                    p.LastUpdatedBy = username;
                    p.LastUpdatedTime = now;
                    // update only modified property
                    db.Entry(p).Property(x => x.DisplayOrder).IsModified = true;
                    db.Entry(p).Property(x => x.LastUpdatedBy).IsModified = true;
                    db.Entry(p).Property(x => x.LastUpdatedTime).IsModified = true;
                });

                db.SaveChanges();
            }, $"reordering the {typeof(T).Name} entity", parameters: new object[] { ids, displayOrders, username });
        }

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
        public IList<LookupEntity> GetPendingAddOns()
        {
            return ProcessWithDb(db =>
            {
                IList<LookupEntity> result = new List<LookupEntity>();
                GetPendingAddOns<Category>(db, result);

                GetPendingAddOns<BusinessUnit>(db, result, p => p.Include(q => q.Category));
                GetPendingAddOns<FunctionalArea>(db, result, p => p.Include(q => q.Category));
                GetPendingAddOns<Department>(db, result);
                GetPendingAddOns<DepartmentHead>(db, result);
                GetPendingAddOns<Product>(db, result);
                GetPendingAddOns<FunctionalAreaOwner>(db, result);

                GetPendingAddOns<KPICategory>(db, result, p => p.Include(q => q.KPIs).Include(q => q.SLAs));
                GetPendingAddOns<KPI>(db, result, p => p.Include(q => q.KPICategory));
                GetPendingAddOns<SLA>(db, result);

                GetPendingAddOns<CoreProcess>(db, result, p => p.Include(q => q.Category)
                    .Include(q => q.ControlTypes).Include(q => q.SubProcessRisks));
                GetPendingAddOns<SubProcessRisk>(db, result, p => p.Include(q => q.CoreProcess));
                GetPendingAddOns<ControlType>(db, result, q => q.Include(p => p.Category));

                GetPendingAddOns<ProcessRisk>(db, result,
                    p => p.Include(q => q.Category).Include(q => q.ControlTypes));

                GetPendingAddOns<Site>(db, result);
                GetPendingAddOns<Percentage>(db, result);
                GetPendingAddOns<AssessmentType>(db, result);
                GetPendingAddOns<AssessmentStatus>(db, result);
                GetPendingAddOns<ChangeType>(db, result);
                GetPendingAddOns<LikelihoodOfOccurrence>(db, result);
                GetPendingAddOns<RiskImpact>(db, result);
                GetPendingAddOns<ControlFrequency>(db, result);
                GetPendingAddOns<ControlDesign>(db, result);
                GetPendingAddOns<TestingFrequency>(db, result);
                GetPendingAddOns<ControlTrigger>(db, result);
                GetPendingAddOns<KeyControlsMaturity>(db, result);
                GetPendingAddOns<RiskScoreRange>(db, result);
                GetPendingAddOns<RiskExposure>(db, result);
                return result;
            }, "retrieving pending add-ons");
        }

        /// <summary>
        /// Get count of pending add-ons.
        /// </summary>
        ///
        /// <returns>The count of pending add-ons.</returns>
        ///
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        /// <exception cref="ServiceException">If any other errors occur while performing this operation.</exception>
        public int CountPendingAddOns()
        {
            return ProcessWithDb(db =>
            {
                var totalPendings = 0;
                totalPendings += GetPendingAddOnCount<Category>(db);

                totalPendings += GetPendingAddOnCount<BusinessUnit>(db);
                totalPendings += GetPendingAddOnCount<FunctionalArea>(db);
                totalPendings += GetPendingAddOnCount<Department>(db);
                totalPendings += GetPendingAddOnCount<DepartmentHead>(db);
                totalPendings += GetPendingAddOnCount<Product>(db);
                totalPendings += GetPendingAddOnCount<FunctionalAreaOwner>(db);

                totalPendings += GetPendingAddOnCount<KPICategory>(db);
                totalPendings += GetPendingAddOnCount<KPI>(db);
                totalPendings += GetPendingAddOnCount<SLA>(db);

                totalPendings += GetPendingAddOnCount<CoreProcess>(db);
                totalPendings += GetPendingAddOnCount<SubProcessRisk>(db);
                totalPendings += GetPendingAddOnCount<ControlType>(db);

                totalPendings += GetPendingAddOnCount<ProcessRisk>(db);

                totalPendings += GetPendingAddOnCount<Site>(db);
                totalPendings += GetPendingAddOnCount<Percentage>(db);
                totalPendings += GetPendingAddOnCount<AssessmentType>(db);
                totalPendings += GetPendingAddOnCount<AssessmentStatus>(db);
                totalPendings += GetPendingAddOnCount<ChangeType>(db);
                totalPendings += GetPendingAddOnCount<LikelihoodOfOccurrence>(db);
                totalPendings += GetPendingAddOnCount<RiskImpact>(db);
                totalPendings += GetPendingAddOnCount<ControlFrequency>(db);
                totalPendings += GetPendingAddOnCount<ControlDesign>(db);
                totalPendings += GetPendingAddOnCount<TestingFrequency>(db);
                totalPendings += GetPendingAddOnCount<ControlTrigger>(db);
                totalPendings += GetPendingAddOnCount<KeyControlsMaturity>(db);
                totalPendings += GetPendingAddOnCount<RiskScoreRange>(db);
                totalPendings += GetPendingAddOnCount<RiskExposure>(db);
                return totalPendings;
            }, "counting pending add-ons");
        }

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
        public void Import(Stream stream, string currentUsername)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(stream, nameof(stream));
                CommonHelper.ValidateArgumentNotNullOrEmpty(currentUsername, nameof(currentUsername));

                var now = DateTime.Now;

                using (var ts = new TransactionScope())
                {
                    // Open the stream as excel file
                    using (var wb = new XLWorkbook(stream, XLEventTracking.Disabled))
                    {
                        foreach (var ws in wb.Worksheets)
                        {
                            var sheetName = ws.Name;
                            var dtRecords = ReadFromSheet(ws);
                            ParseToEntityAndAdd(currentUsername, db, now, sheetName, dtRecords);
                        }
                    }
                    // save changes
                    db.SaveChanges();

                    ts.Complete();
                }
            }, "importing the add-ons", parameters: new object[] { stream, currentUsername });
        }

        /// <summary>
        /// Retrieves all risk score ranges.
        /// </summary>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">If error occurs while accessing the persistence.</exception>
        public IList<RiskScoreRange> GetAllRiskScoreRanges(bool includeDisabled = false)
        {
            return GetAll<RiskScoreRange>(includeDisabled: includeDisabled);
        }

        #endregion admin related methods

        #region private methods

        /// <summary>
        /// Retrieves all lookup entities of type <typeparamref name="T"/> matching given
        /// predicate in case it is not <c>null</c>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the lookup entities to retrieve.</typeparam>
        /// <param name="predicate">The optional predicate to match.</param>
        /// <param name="includeChildren">The optional delegate that is used to include child entities.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        private IList<T> GetAll<T>(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IQueryable<T>> includeChildren = null, bool includeDisabled = false)
            where T : LookupEntity
        {
            return ProcessWithDb(
                db =>
                {
                    IQueryable<T> query = db.Set<T>();

                    if (predicate != null)
                    {
                        query = query.Where(predicate);
                    }

                    query = query.Where(p => p.AddOnStatus == AddOnStatus.Approved);

                    if (!includeDisabled)
                    {
                        query = query.Where(p => p.Enabled == true);
                    }

                    if (includeChildren != null)
                    {
                        query = includeChildren(query);
                    }

                    query = query.OrderBy(x => x.DisplayOrder);

                    return query.ToList();
                },
                $"retrieving {typeof(T).Name} entities",
                callingMethod: new StackTrace().GetFrame(1).GetMethod(), parameters: includeDisabled);
        }

        /// <summary>
        /// Retrieves all lookup entities of type <typeparamref name="T"/> matching given
        /// predicate in case it is not <c>null</c>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the lookup entities to retrieve.</typeparam>
        ///
        /// <param name="businessUnitId">The business unit id.</param>
        /// <param name="functionalAreaId">The functional area id.</param>
        /// <param name="includeChildren">The optional delegate that is used to include child entities.</param>
        /// <param name="includeDisabled">Flag whether to include disabled(rejected) lookups or not.</param>
        /// <param name="includeGlobal">The flag whether to include global or not</param>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        private IList<T> GetAllBusinessUnitFuncationalArea<T>(long? businessUnitId, long? functionalAreaId,
            Func<IQueryable<T>, IQueryable<T>> includeChildren = null, bool includeDisabled = false,
            bool includeGlobal = true)
            where T : BusinessUnitFunctionalAreaLookupEntity
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(businessUnitId, nameof(businessUnitId));
                CommonHelper.ValidateArgumentPositive(functionalAreaId, nameof(functionalAreaId));

                IQueryable<T> query = db.Set<T>();

                if (includeGlobal)
                {
                    query = query.Where(p => p.BusinessUnitId == null || p.BusinessUnitId == businessUnitId);

                    if (functionalAreaId != null)
                    {
                        query = query.Where(p => p.FunctionalAreaId == null || p.FunctionalAreaId == functionalAreaId);
                    }
                    else
                    {
                        query = query.Where(p => p.FunctionalAreaId == null);
                    }
                }
                else
                {
                    query = query.Where(p => p.BusinessUnitId == businessUnitId &&
                                        p.FunctionalAreaId == functionalAreaId);
                }

                query = query.Where(p => p.AddOnStatus == AddOnStatus.Approved);

                if (!includeDisabled)
                {
                    query = query.Where(p => p.Enabled == true);
                }

                if (includeChildren != null)
                {
                    query = includeChildren(query);
                }

                query = query.OrderBy(x => x.DisplayOrder);

                return query.ToList();
            }, $"retrieving {typeof(KPICategory).Name} entities",
               parameters: new object[] { businessUnitId, functionalAreaId, includeChildren,
                   includeDisabled, includeGlobal });
        }

        /// <summary>
        /// Retrieves entity with the given Id.
        /// </summary>
        ///
        /// <param name="context">The database context.</param>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <param name="idParamName">The name of the Id parameter in the method.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <exception cref="ArgumentException"> If <paramref name="id"/> is not positive.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with the given Id doesn't exist in DB.
        /// </exception>
        /// <remarks>Other exceptions will be propagated.</remarks>
        private static T Get<T>(DbContext context, long id, string idParamName = "id")
            where T : LookupEntity
        {
            CommonHelper.ValidateArgumentPositive(id, idParamName);

            IQueryable<T> query = context.Set<T>();
            query = IncludeNavigationProperties(query);

            var entity = query.FirstOrDefault(e => e.Id == id);
            CommonHelper.CheckFoundEntity(entity, id);

            return entity;
        }

        /// <summary>
        /// Gets the pending add ons.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity</typeparam>
        /// <param name="context">The db context.</param>
        /// <param name="container">The result container.</param>
        /// <param name="includeChildren">The optional delegate that is used to include child entities.</param>
        /// <remarks>Any exceptions will be propagated to the caller.</remarks>
        private static void GetPendingAddOns<T>(DbContext context, ICollection<LookupEntity> container,
            Func<IQueryable<T>, IQueryable<T>> includeChildren = null)
            where T : LookupEntity
        {
            var query = context.Set<T>().Where(p => p.AddOnStatus == AddOnStatus.Pending);

            if (includeChildren != null)
            {
                query = includeChildren(query);
            }

            var items = query.ToList();

            foreach (var item in items)
            {
                container.Add(item);
            }
        }

        /// <summary>
        /// Gets the pending add-ons count.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity</typeparam>
        /// <param name="context">The db context.</param>
        /// <returns>The count of pending add-on.</returns>
        /// <remarks>Any exceptions will be propagated to the caller.</remarks>
        private static int GetPendingAddOnCount<T>(DbContext context)
            where T : LookupEntity
        {
            return context.Set<T>().Count(p => p.AddOnStatus == AddOnStatus.Pending);
        }

        /// <summary>
        /// Gets the property info of a type.
        /// </summary>
        /// <param name="objType">The type.</param>
        /// <returns>The properties.</returns>
        private static IEnumerable<PropertyInfo> GetProperties(Type objType)
        {
            ICollection<PropertyInfo> properties;
            lock (Properties)
            {
                if (!Properties.TryGetValue(objType, out properties))
                {
                    properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                    Properties.Add(objType, properties);
                }
            }

            return properties;
        }

        #region create, update and delete related private methods

        /// <summary>
        /// Creates the lookup entity
        /// </summary>
        /// <typeparam name="T">The type of lookup entity to create.</typeparam>
        /// <param name="entity">The entity to create.</param>
        /// <param name="db">The db context.</param>
        /// <param name="saveChanges">The flag whether to save the changes or not.</param>
        /// <remarks>Any exceptions will be propagated to the caller.</remarks>
        private static T Create<T>(T entity, CustomDbContext db, bool saveChanges = false)
            where T : LookupEntity
        {
            // get existing child entities from DB, otherwise new entities will be created in database
            ResolveChildEntities(db, entity);

            entity = db.Set<T>().Add(entity);

            if (saveChanges)
            {
                db.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Updates the lookup entity
        /// </summary>
        /// <typeparam name="T">The type of lookup entity to update.</typeparam>
        /// <param name="entity">The entity to update.</param>
        /// <param name="db">The db context.</param>
        /// <param name="existing">The existing entity.</param>
        /// <param name="saveChanges">The flag whether to save the changes or not.</param>
        /// <remarks>Any exceptions will be propagated to the caller.</remarks>
        private static T Update<T>(T entity, CustomDbContext db, T existing, bool saveChanges = false)
            where T : LookupEntity
        {
            // get existing child entities from DB, otherwise new entities will be created in database
            ResolveChildEntities(db, entity);

            // delete existing one-to-many relations which are not in the current entity.
            RemoveOneToManyEntities(db, entity, existing);

            db.Entry(existing).CurrentValues.SetValues(entity);

            // copy fields to existing entity (attach approach doesn't work for child entities)
            UpdateEntityFields(existing, entity);

            if (saveChanges)
            {
                db.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Removes one to many child entities from <paramref name="existing"/>
        ///  which are not in <paramref name="entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity.</typeparam>
        /// <param name="db">The db set.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="existing">The existing entity.</param>
        private static void RemoveOneToManyEntities<T>(CustomDbContext db, T entity, T existing)
            where T : LookupEntity
        {
            if (typeof(T) == typeof(CoreProcess))
            {
                var newIds = (entity as CoreProcess)?.SubProcessRisks.Select(p => p.Id).ToList();
                var existings = (existing as CoreProcess)?.SubProcessRisks;
                if (existings != null)
                {
                    var itemsToDelete =
                        existings.Where(p => newIds != null && !newIds.Contains(p.Id)).Select(q => q.Id).ToList();
                    TryDelete<KPI>(db, p => itemsToDelete.Contains(p.Id), typeof(T).Name, "Updated");
                }
            }
            else if (typeof(T) == typeof(KPICategory))
            {
                var newIds = (entity as KPICategory)?.KPIs.Select(p => p.Id).ToList();
                var existings = (existing as KPICategory)?.KPIs;
                if (existings != null)
                {
                    var itemsToDelete =
                        existings.Where(p => newIds != null && !newIds.Contains(p.Id)).Select(q => q.Id).ToList();
                    TryDelete<KPI>(db, p => itemsToDelete.Contains(p.Id), typeof(T).Name, "Updated");
                }
            }
        }

        /// <summary>
        /// Includes the navigation properties loading for the entity.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity.</typeparam>
        ///
        /// <param name="query">The query.</param>
        ///
        /// <returns>The updated query.</returns>
        private static IQueryable<T> IncludeNavigationProperties<T>(IQueryable<T> query) where T : LookupEntity
        {
            var properties = GetProperties(typeof(T))
                .Where(p =>
                    typeof(IdentifiableEntity).IsAssignableFrom(p.PropertyType) ||
                    typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(p.PropertyType));

            return properties.Aggregate(query, (current, property) => current.Include(property.Name));
        }

        /// <summary>
        /// Updates the <paramref name="existing"/> entity according to <paramref name="newEntity"/> entity.
        /// </summary>
        ///  /// <typeparam name="T">The type of lookup entity.</typeparam>
        /// <remarks>Override in child services to update navigation properties.</remarks>
        /// <param name="existing">The existing entity.</param>
        /// <param name="newEntity">The new entity.</param>
        private static void UpdateEntityFields<T>(T existing, T newEntity)
            where T : LookupEntity
        {
            var properties = GetProperties(typeof(T));
            foreach (var property in properties
                .Where(p => typeof(IdentifiableEntity).IsAssignableFrom(p.PropertyType)
                            || typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(p.PropertyType)))
            {
                var value = property.GetValue(newEntity, null);
                property.SetValue(existing, value, null);
            }
        }

        /// <summary>
        /// Resolves the child entities.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity.</typeparam>
        ///
        /// <param name="db">The db context.</param>
        /// <param name="entity">The entity</param>
        private static void ResolveChildEntities<T>(CustomDbContext db, T entity) where T : IdentifiableEntity
        {
            var properties = GetProperties(typeof(T));
            if (typeof(BusinessUnitLookupEntity).IsAssignableFrom(typeof(T)))
            {
                var buEntity = entity as BusinessUnitLookupEntity;
                if (buEntity != null)
                {
                    // ensure the existence of business unit
                    ResolveChildEntity(db, new BusinessUnit { Id = buEntity.BusinessUnitId });
                }
            }
            else if (typeof(BusinessUnitFunctionalAreaLookupEntity).IsAssignableFrom(typeof(T)))
            {
                var faEntity = entity as BusinessUnitFunctionalAreaLookupEntity;
                if (faEntity != null)
                {
                    if (faEntity.FunctionalAreaId != null)
                    {
                        // ensure the existence of functional area
                        ResolveChildEntity(db, new FunctionalArea { Id = (long)faEntity.FunctionalAreaId });
                    }
                }
            }

            foreach (var property in properties
                .Where(p => typeof(IdentifiableEntity).IsAssignableFrom(p.PropertyType)
                            || typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(p.PropertyType)))
            {
                // if property is of type of IdentifiableEntity
                if (typeof(IdentifiableEntity).IsAssignableFrom(property.PropertyType))
                {
                    dynamic ob = null;
                    if (property.PropertyType == typeof(Category))
                    {
                        ob = property.GetValue(entity, null) as Category;
                    }
                    if (property.PropertyType == typeof(KPICategory))
                    {
                        ob = property.GetValue(entity, null) as KPICategory;
                    }
                    if (property.PropertyType == typeof(CoreProcess))
                    {
                        ob = property.GetValue(entity, null) as CoreProcess;
                    }
                    if (ob != null)
                    {
                        var resolvedValue = ResolveChildEntity(db, ob);
                        property.SetValue(entity, resolvedValue, null);
                    }
                }
                else if (typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(property.PropertyType))
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
                        ResolveEntities(db, items);
                        property.SetValue(entity, items, null);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the referenced lookup entities.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity.</typeparam>
        /// <param name="context">The db context.</param>
        /// <param name="entity">The entity.</param>
        private static void DeleteReferencedEntities<T>(CustomDbContext context, T entity)
            where T : LookupEntity
        {
            var mainEntityName = typeof(T).Name;
            if (typeof(T) == typeof(Category))
            {
                TryDelete<ControlType>(context, p => p.Category.Id == entity.Id, mainEntityName);
                TryDelete<ProcessRisk>(context, p => p.Category.Id == entity.Id, mainEntityName);
                TryDelete<CoreProcess>(context, p => p.Category.Id == entity.Id, mainEntityName);
                TryDelete<FunctionalArea>(context, p => p.Category.Id == entity.Id, mainEntityName);
                TryDelete<BusinessUnit>(context, p => p.Category.Id == entity.Id, mainEntityName);
            }
        }

        ///  <summary>
        ///  Deletes the entities based on predicate.
        ///  </summary>
        ///  <typeparam name="T">The type of entity to delete.</typeparam>
        ///
        ///  <param name="context">The delete action.</param>
        ///  <param name="predicate">The predicate to match the items to delete.</param>
        ///  <param name="mainEntityName">The main entity name which is deleting.</param>
        /// <param name="operation">The type of operation performing on main entity.</param>
        private static void TryDelete<T>(CustomDbContext context,
            Expression<Func<T, bool>> predicate, string mainEntityName, string operation = "deleted")
            where T : IdentifiableEntity
        {
            try
            {
                var items = context.Set<T>().Where(predicate).ToList();
                if (items.Any())
                {
                    context.Set<T>().RemoveRange(items);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Helper.HandleDeleteException(ex, mainEntityName,
                    $"The {mainEntityName} can not be {operation} because it is referenced by {typeof(T).Name} "
                    + "which is referenced by assessment(s).");
            }
        }

        /// <summary>
        /// Updates entity audit fields.
        /// </summary>
        /// <remarks>All exceptions will be propagated to caller method.</remarks>
        ///
        /// <param name="currentUsername">The current username.</param>
        /// <param name="now">The timestamp when the operation is performed.</param>
        /// <param name="entity">The entity to update.</param>
        /// <param name="existing">The existing entity.</param>
        private static void PopulateAuditFields(string currentUsername, DateTime now,
            AuditableEntity entity, AuditableEntity existing = null)
        {
            if (existing != null)
            {
                entity.CreatedBy = existing.CreatedBy;
                entity.CreatedTime = existing.CreatedTime;
            }
            else
            {
                entity.CreatedBy = currentUsername;
                entity.CreatedTime = now;
            }

            entity.LastUpdatedBy = currentUsername;
            entity.LastUpdatedTime = now;
        }

        #endregion create, update and delete related private methods

        #region import related private method

        /// <summary>
        /// Gets the data from excel sheet.
        /// </summary>
        /// <param name="workSheet">The worksheet.</param>
        /// <returns>The data table with records.</returns>
        private static DataTable ReadFromSheet(IXLWorksheet workSheet)
        {
            //Create a new DataTable.
            var dt = new DataTable();

            //Loop through the Worksheet rows.
            var firstRow = true;
            foreach (var row in workSheet.RowsUsed())
            {
                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (var cell in row.CellsUsed())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    //Add rows to DataTable.
                    dt.Rows.Add();
                    var i = 0;
                    foreach (var cell in row.CellsUsed())
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                        i++;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Adds or updates the look up entity.
        /// </summary>
        /// <typeparam name="T">The type of the lookup entities to update or add.</typeparam>
        ///
        /// <param name="db">The db context.</param>
        /// <param name="entities">The entities to update or create</param>
        /// <param name="currentUsername">The username of user importing.</param>
        /// <param name="now">The timestamp of operation.</param>
        ///
        /// <remarks>Any exceptions will be propagated to the caller.</remarks>
        private void AddOrUpdate<T>(CustomDbContext db, IEnumerable<T> entities, string currentUsername,
            DateTime now) where T : LookupEntity
        {
            foreach (var entity in entities)
            {
                IQueryable<T> query = db.Set<T>();
                query = IncludeNavigationProperties(query);

                var existing = query.FirstOrDefault(e => e.Name == entity.Name);

                PopulateAuditFields(currentUsername, now, entity, existing);
                T newEntity = null;
                if (existing != null)
                {
                    entity.Id = existing.Id;
                    newEntity = Update(entity, db, existing);
                }
                else
                {
                    newEntity = Create(entity, db);
                }
                Helper.Audit(AuditService, existing, newEntity, "Lookup.Import", currentUsername);
            }
        }

        /// <summary>
        /// Parse the lookup entities based on sheet name and adds in database context.
        /// </summary>
        /// <param name="currentUsername">The current username.</param>
        /// <param name="db">The db context.</param>
        /// <param name="now">The current timestamp.</param>
        /// <param name="sheetName">The sheet name.</param>
        /// <param name="dtRecords">The records read from excel sheet.</param>
        /// <exception cref="ServiceException">If the sheet name if unknown or risk score range is
        /// invalid.</exception>
        /// <remarks>Any other exceptions from are propagated to the caller.</remarks>
        private void ParseToEntityAndAdd(string currentUsername, CustomDbContext db, DateTime now,
            string sheetName, DataTable dtRecords)
        {
            switch (sheetName.Trim())
            {
                case nameof(Category):
                    AddOrUpdate(db, ConvertToLookup<Category>(dtRecords, sheetName, new List<string>
                    {
                        nameof(Category.Weight)
                    }), currentUsername, now);
                    break;

                case nameof(BusinessUnit):
                    AddOrUpdate(db, ConvertToLookup<BusinessUnit>(dtRecords, sheetName,
                        new List<string>
                        {
                            nameof(BusinessUnit.Category),
                        }), currentUsername, now);
                    break;

                case nameof(Product):
                    AddOrUpdate(db, ConvertToLookup<Product>(dtRecords, sheetName,
                        new List<string> { nameof(Product.BusinessUnitId) }), currentUsername, now);
                    break;

                case nameof(Department):
                    AddOrUpdate(db, ConvertToLookup<Department>(dtRecords, sheetName,
                        new List<string> { nameof(Department.BusinessUnitId) }), currentUsername, now);
                    break;

                case nameof(DepartmentHead):
                    AddOrUpdate(db, ConvertToLookup<DepartmentHead>(dtRecords, sheetName,
                        new List<string> { nameof(DepartmentHead.BusinessUnitId) }), currentUsername, now);
                    break;

                case nameof(FunctionalAreaOwner):
                    AddOrUpdate(db, ConvertToLookup<FunctionalAreaOwner>(dtRecords, sheetName,
                        new List<string> { nameof(FunctionalAreaOwner.BusinessUnitId) }), currentUsername, now);
                    break;

                case nameof(FunctionalArea):
                    AddOrUpdate(db, ConvertToLookup<FunctionalArea>(dtRecords, sheetName,
                        new List<string>
                        {
                            nameof(FunctionalArea.BusinessUnitId),
                            nameof(FunctionalArea.Category)
                        }), currentUsername, now);
                    break;

                case nameof(AssessmentStatus):
                    AddOrUpdate(db, ConvertToLookup<AssessmentStatus>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(AssessmentType):
                    AddOrUpdate(db, ConvertToLookup<AssessmentType>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(ChangeType):
                    AddOrUpdate(db, ConvertToLookup<ChangeType>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(ControlDesign):
                    AddOrUpdate(db, ConvertToLookup<ControlDesign>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(ControlFrequency):
                    AddOrUpdate(db, ConvertToLookup<ControlFrequency>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(ControlTrigger):
                    AddOrUpdate(db, ConvertToLookup<ControlTrigger>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(ControlType):
                    AddOrUpdate(db, ConvertToLookup<ControlType>(dtRecords, sheetName,
                        new List<string> { nameof(ControlType.Category) }), currentUsername, now);
                    break;

                case nameof(CoreProcess):
                    AddOrUpdate(db, ConvertToLookup<CoreProcess>(dtRecords, sheetName, new List<string>
                    {
                        nameof(CoreProcess.Category),
                        nameof(CoreProcess.ControlTypes),
                        nameof(CoreProcess.BusinessUnitId),
                        nameof(CoreProcess.FunctionalAreaId),
                        nameof(CoreProcess.SubProcessRisks)
                    }), currentUsername, now);
                    break;

                case nameof(KPI):
                    AddOrUpdate(db, ConvertToLookup<KPI>(dtRecords, sheetName, new List<string>
                    {
                        nameof(KPI.KPICategory)
                    }), currentUsername, now);
                    break;

                case nameof(KPICategory):
                    AddOrUpdate(db, ConvertToLookup<KPICategory>(dtRecords, sheetName, new List<string>
                    {
                         nameof(KPICategory.BusinessUnitId),
                        nameof(KPICategory.FunctionalAreaId),
                        nameof(KPICategory.KPIs),
                        nameof(KPICategory.SLAs)
                    }), currentUsername, now);
                    break;

                case nameof(KeyControlsMaturity):
                    AddOrUpdate(db, ConvertToLookup<KeyControlsMaturity>(dtRecords, sheetName, new List<string>
                    {
                        nameof(KeyControlsMaturity.Value)
                    }), currentUsername, now);
                    break;

                case nameof(LikelihoodOfOccurrence):
                    AddOrUpdate(db, ConvertToLookup<LikelihoodOfOccurrence>(dtRecords, sheetName, new List<string>
                    {
                        nameof(LikelihoodOfOccurrence.Value)
                    }), currentUsername, now);
                    break;

                case nameof(Percentage):
                    AddOrUpdate(db, ConvertToLookup<Percentage>(dtRecords, sheetName, new List<string>
                    {
                        nameof(Percentage.Value)
                    }), currentUsername, now);
                    break;

                case nameof(ProcessRisk):
                    AddOrUpdate(db, ConvertToLookup<ProcessRisk>(dtRecords, sheetName, new List<string>
                    {
                        nameof(ProcessRisk.BusinessUnitId),
                        nameof(ProcessRisk.FunctionalAreaId),
                        nameof(ProcessRisk.Category),
                        nameof(ProcessRisk.ControlTypes)
                    }), currentUsername, now);
                    break;

                case nameof(RiskImpact):
                    AddOrUpdate(db, ConvertToLookup<RiskImpact>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(RiskScoreRange):
                    var riskScoreRanges = ConvertToLookup<RiskScoreRange>(dtRecords, sheetName, new List<string>
                    {
                        nameof(RiskScoreRange.UpperBound),
                        nameof(RiskScoreRange.LowerBound),
                        nameof(RiskScoreRange.Color)
                    });
                    Helper.ValidateRiskScoreEntities(riskScoreRanges);
                    AddOrUpdate(db, riskScoreRanges, currentUsername, now);
                    break;

                case nameof(RiskExposure):
                    AddOrUpdate(db, ConvertToLookup<RiskExposure>(dtRecords, sheetName, new List<string>
                    {
                        nameof(RiskExposure.Value)
                    }), currentUsername, now);
                    break;

                case nameof(SLA):
                    AddOrUpdate(db, ConvertToLookup<SLA>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(Site):
                    AddOrUpdate(db, ConvertToLookup<Site>(dtRecords, sheetName), currentUsername, now);
                    break;

                case nameof(SubProcessRisk):
                    AddOrUpdate(db, ConvertToLookup<SubProcessRisk>(dtRecords, sheetName, new List<string>
                    {
                        nameof(SubProcessRisk.CoreProcess)
                    }), currentUsername, now);
                    break;

                case nameof(TestingFrequency):
                    AddOrUpdate(db, ConvertToLookup<TestingFrequency>(dtRecords, sheetName), currentUsername, now);
                    break;

                default:
                    throw new ServiceException($"The sheet name '{sheetName}' is unknown");
            }
        }

        /// <summary>
        /// Converts the data table to lookup entity.
        /// </summary>
        /// <typeparam name="T">The type of lookup entity.</typeparam>
        /// <param name="records">The data table.</param>
        /// <param name="sheetName">The sheet name.</param>
        /// <param name="additionalIncludeProperties">
        /// The properties to include in addition to properties from <see cref="LookupEntity"/>
        /// </param>
        /// <returns>The list of lookup entities generated from data table.</returns>
        /// <exception cref="ServiceException">If the sheet doesn't contain required properties
        /// or the cell data is invalid for the property of lookup entity type</exception>
        /// <remarks>Any other exceptions will be propagated to the caller.</remarks>
        private IList<T> ConvertToLookup<T>(DataTable records, string sheetName,
            IList<string> additionalIncludeProperties = null)
            where T : LookupEntity, new()
        {
            // default included from lookup entity
            IEnumerable<string> includedProperties = new List<string>
            {
                nameof(LookupEntity.Name),
                nameof(LookupEntity.Enabled),
                nameof(LookupEntity.DisplayOrder),
                nameof(LookupEntity.AddOnStatus)
            };

            if (additionalIncludeProperties != null)
            {
                includedProperties = includedProperties.Concat(additionalIncludeProperties).Distinct();
            }

            ICollection<PropertyInfo> properties = GetProperties(typeof(T))
                .Where(p => includedProperties.Contains(p.Name)).ToList();

            // check if sheet contains all the columns
            foreach (var property in properties)
            {
                var columnName = property.Name;
                if (typeof(IdentifiableEntity).IsAssignableFrom(property.PropertyType))
                {
                    columnName += "Id";
                }
                else if (typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(property.PropertyType))
                {
                    columnName += "Ids";
                }
                if (!records.Columns.Contains(columnName))
                {
                    throw new ServiceException($"The {sheetName} sheet doesn't contains {columnName} column.");
                }
            }

            // result container
            var list = new List<T>();

            foreach (var row in records.AsEnumerable())
            {
                var obj = new T();

                foreach (var prop in properties)
                {
                    var columnName = prop.Name;
                    try
                    {
                        var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                        if (typeof(IdentifiableEntity).IsAssignableFrom(propType))
                        {
                            columnName += "Id";
                        }
                        else if (typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(propType))
                        {
                            columnName += "Ids";
                        }
                        var rawValue = row[columnName];
                        if (rawValue != null)
                        {
                            object safeValue;
                            if (propType.IsEnum)
                            {
                                safeValue = Enum.Parse(propType, rawValue.ToString());
                            }
                            else if (typeof(IdentifiableEntity).IsAssignableFrom(propType))
                            {
                                safeValue = Activator.CreateInstance(propType);
                                ConvertIdentifiableEntity(safeValue as IdentifiableEntity, rawValue);
                            }
                            else if (typeof(IEnumerable<IdentifiableEntity>).IsAssignableFrom(propType))
                            {
                                if (propType == typeof(IList<SubProcessRisk>))
                                {
                                    safeValue = ConvertToIdentfiableEntities<SubProcessRisk>(rawValue);
                                }
                                else if (propType == typeof(IList<ControlType>))
                                {
                                    safeValue = ConvertToIdentfiableEntities<ControlType>(rawValue);
                                }
                                else if (propType == typeof(IList<KPI>))
                                {
                                    safeValue = ConvertToIdentfiableEntities<KPI>(rawValue);
                                }
                                else if (propType == typeof(IList<SLA>))
                                {
                                    safeValue = ConvertToIdentfiableEntities<SLA>(rawValue);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(rawValue.ToString()))
                                {
                                    safeValue = Convert.ChangeType(rawValue, propType);
                                }
                                else
                                {
                                    safeValue = null;
                                }
                            }

                            prop.SetValue(obj, safeValue, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ServiceException(
                            $"The data {columnName}({row[columnName]}) in {sheetName} sheet is invalid.", ex);
                    }
                }
                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// Assigns the value of id to <see cref="IdentifiableEntity"/> entity.
        /// </summary>
        /// <param name="obj">The <see cref="IdentifiableEntity"/> object.</param>
        /// <param name="rawValue">The data row raw value.</param>
        private static void ConvertIdentifiableEntity(IdentifiableEntity obj, object rawValue)
        {
            obj.Id = long.Parse(rawValue.ToString());
        }

        /// <summary>
        /// Assigns the value of id to <see cref="IdentifiableEntity"/> entities.
        /// </summary>
        /// <param name="rawValue">The data row raw value, comma separated ids.</param>
        private static IList<T> ConvertToIdentfiableEntities<T>(object rawValue)
            where T : IdentifiableEntity, new()

        {
            var entities = new List<T>();
            var ids = rawValue.ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string id in ids)
            {
                var obj = new T();
                ConvertIdentifiableEntity(obj, id);
                entities.Add(obj);
            }
            return entities;
        }

        #endregion import related private method

        #endregion private methods
    }
}