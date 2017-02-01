/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JohnHancock.Common;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Services.Impl;
using JohnHancock.KPIScorecard.Impl;

namespace JohnHancock.KPIScorecard.Services.Impl
{
    /// <summary>
    /// This abstract class is a base for all <see cref="IGenericService{T,S}"/> service implementations. It
    /// provides CRUD, search and export functionality.
    /// </summary>
    /// 
    /// <typeparam name="T">The type of the managed entities.</typeparam>
    /// <typeparam name="S">The type of the entities search criteria.</typeparam>
    /// 
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class BaseGenericService<T, S> : BasePersistenceService<CustomDbContext>, IGenericService<T, S>
        where T : IdentifiableEntity
        where S : BaseSearchCriteria
    {
        /// <summary>
        /// The cached name of the entity type.
        /// </summary>
        protected readonly string _entityName = typeof(T).Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGenericService{T,S}"/> class.
        /// </summary>
        protected BaseGenericService()
        {
        }

        /// <summary>
        /// Creates given entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="entity"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public T Create(T entity)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));

                // get existing child entities from DB, otherwise new entities will be created in database
                ResolveChildEntities(db, entity);

                entity = db.Set<T>().Add(entity);
                db.SaveChanges();

                // load entity again to return all fields populated, because child entities may contain just Ids
                return Get(entity.Id);
            },
            $"creating {_entityName} entity",
            parameters: entity);
        }

        /// <summary>
        /// Updates given entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="entity"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with the given Id doesn't exist in DB.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public T Update(T entity)
        {
            return ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));

                T existing = Get(db, entity.Id, "entity.Id");

                // get existing child entities from DB, otherwise new entities will be created in database
                ResolveChildEntities(db, entity);

                // copy fields to existing entity (attach approach doesn't work for child entities)
                UpdateEntityFields(existing, entity, db);
                db.SaveChanges();

                // load entity again to return all fields populated, because child entities may contain just Ids
                return Get(entity.Id);
            },
            $"updating {_entityName} entity",
            parameters: entity);
        }

        /// <summary>
        /// Retrieves entity with the given Id.
        /// </summary>
        ///
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="id"/> is not positive.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with the given Id doesn't exist in DB.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public T Get(long id)
        {
            return ProcessWithDb(db =>
            {
                return Get(db, id);
            },
            $"retrieving {_entityName} entity",
            parameters: id);
        }

        /// <summary>
        /// Deletes entity with the given Id.
        /// </summary>
        ///
        /// <param name="id">The id of the entity to delete.</param>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="id"/> is not positive.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with the given Id doesn't exist in DB.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public void Delete(long id)
        {
            ProcessWithDb(db =>
            {
                CommonHelper.ValidateArgumentPositive(id, nameof(id));

                T entity = Get(db, id, full: false);
                db.Set<T>().Remove(entity);
            },
            $"deleting {_entityName} entity",
            saveChanges: true,
            parameters: id);
        }

        /// <summary>
        /// Retrieves entities matching given search criteria.
        /// </summary>
        ///
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The matched entities.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="criteria"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If criteria.PageNumber or criteria.PageSize is negative.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        public SearchResult<T> Search(S criteria)
        {
            return ProcessWithDb(db =>
            {
                Helper.CheckSearchCriteria(criteria);
                IQueryable<T> query = db.Set<T>();

                // include navigation properties
                query = IncludeNavigationProperties(query);

                // construct query conditions
                query = ConstructQueryConditions(query, criteria);

                // set total count of filtered records
                var result = new SearchResult<T>();
                result.TotalRecords = query.Count();

                // construct SortBy property selector expression
                if (criteria.SortBy == null)
                {
                    SetDefaultSortOption(criteria);
                }

                query = criteria.SortType == SortType.Ascending
                    ? query.OrderBy(criteria.SortBy)
                    : query.OrderByDescending(criteria.SortBy);

                // select required page
                if (criteria.PageNumber > 0)
                {
                    query = query.Skip(criteria.PageSize * (criteria.PageNumber - 1)).Take(criteria.PageSize);
                }

                // execute query and set result properties
                result.Items = query.ToList();
                SetSearchResultPageInfo(result, criteria);
                return result;
            },
            $"searching {_entityName} entities",
            parameters: criteria);
        }

        /// <summary>
        /// Sets the default sort column and order to given criteria.
        /// </summary>
        /// <param name="criteria">The search criteria.</param>
        protected virtual void SetDefaultSortOption(S criteria)
        {
            // if not overridden, use Id ASC by default
            criteria.SortBy = nameof(IdentifiableEntity.Id);
            criteria.SortType = SortType.Ascending;
        }

        /// <summary>
        /// Applies filters to the given query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The updated query with applied filters.</returns>
        protected virtual IQueryable<T> ConstructQueryConditions(IQueryable<T> query, S criteria)
        {
            return query;
        }

        /// <summary>
        /// Updates the child entities by loading them from the database context.
        /// </summary>
        ///
        /// <remarks>
        /// All thrown exceptions will be propagated to caller method.
        /// </remarks>
        ///
        /// <param name="context">The database context.</param>
        /// <param name="entity">The entity to resolve.</param>
        protected virtual void ResolveChildEntities(DbContext context, T entity)
        {
            // do nothing by default
        }

        /// <summary>
        /// Updates the <paramref name="existing"/> entity according to <paramref name="newEntity"/> entity.
        /// </summary>
        /// <remarks>Override in child services to update navigation properties.</remarks>
        /// <param name="existing">The existing entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <param name="context">The database context.</param>
        protected virtual void UpdateEntityFields(T existing, T newEntity, DbContext context)
        {
            var existingAuditable = existing as AuditableEntity;
            if (existingAuditable != null)
            {
                // audit fields should not be updated
                var newAuditable = newEntity as AuditableEntity;
                newAuditable.CreatedBy = existingAuditable.CreatedBy;
                newAuditable.CreatedTime = existingAuditable.CreatedTime;
            }

            context.Entry(existing).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Includes the navigation properties loading for the entity.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The updated query.</returns>
        protected virtual IQueryable<T> IncludeNavigationProperties(IQueryable<T> query)
        {
            // by default do not include any child property
            return query;
        }

        /// <summary>
        /// Gets the last tallied number.
        /// </summary>
        /// <typeparam name="TSource">The type of the source entities.</typeparam>
        /// <param name="year">The year to match.</param>
        /// <param name="month">The month to match.</param>
        /// <param name="prefix">The prefix to match.</param>
        /// <param name="source">The source entities.</param>
        /// <param name="selector">The property selector of tallied number in the entity.</param>
        /// <returns>The last tallied number, or 0 if no matched entities were found.</returns>
        /// <exception cref="ArgumentException">
        /// If <paramref name="year"/> or <paramref name="month"/> is not positive, or month is greater than 12.
        /// </exception>
        /// <remarks>All other thrown exceptions will be propagated to caller method.</remarks>
        protected int GetLastTalliedNumber<TSource>(int year, int month, string prefix,
            IQueryable<TSource> source, Expression<Func<TSource, string>> selector)
        {
            CommonHelper.ValidateArgumentPositive(year, nameof(year));
            CommonHelper.ValidateArgumentPositive(month, nameof(month));
            if (month > 12)
            {
                throw new ArgumentException("month cannot be greater than 12.", nameof(month));
            }

            string startWith = prefix + (year % 100).ToString("00") + month.ToString("00");
            string lastNumber = source.Select(selector).Where(x => x.StartsWith(startWith))
                // order by length and then by the value itself, otherwise "A16122" will be greater than "A161211"
                .OrderByDescending(x => x.Length).ThenByDescending(x => x).FirstOrDefault();
            return lastNumber != null
                ? Convert.ToInt32(lastNumber.Substring(startWith.Length)) // get the part after {Prefix}{Year}{Month}
                : 0;
        }

        /// <summary>
        /// Retrieves entity with the given Id.
        /// </summary>
        ///
        /// <param name="context">The database context.</param>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <param name="idParamName">The name of the Id parameter in the method.</param>
        /// <param name="full">Determines whether navigation properties should also be loaded.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <exception cref="ArgumentException">
        /// If <paramref name="id"/> is not positive.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// If entity with the given Id doesn't exist in DB.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If a DB-based error occurs.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        private T Get(DbContext context, long id, string idParamName = "id", bool full = true)
        {
            CommonHelper.ValidateArgumentPositive(id, idParamName);

            IQueryable<T> query = context.Set<T>();
            if (full)
            {
                query = IncludeNavigationProperties(query);
            }
            T entity = query.FirstOrDefault(e => e.Id == id);
            CommonHelper.CheckFoundEntity(entity, id);
            return entity;
        }
    }
}
