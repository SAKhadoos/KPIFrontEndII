/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.Common.Entities;
using JohnHancock.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Reflection;

namespace JohnHancock.Common.Services.Impl
{
    /// <summary>
    /// This abstract class is a base for all service implementations that access database persistence.
    /// </summary>
    ///
    /// <typeparam name="TContext">The type of the database context to use.</typeparam>
    /// 
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], TCSASSEMBLER</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public abstract class BasePersistenceService<TContext> : BaseService
        where TContext: DbContext, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePersistenceService{TContext}"/> class.
        /// </summary>
        protected BasePersistenceService()
        {
        }

        /// <summary>
        /// Creates the database context.
        /// </summary>
        ///
        /// <remarks>
        /// All thrown exceptions will be propagated to caller method.
        /// </remarks>
        ///
        /// <returns>The database context.</returns>
        protected TContext CreateDbContext()
        {
            var db = new TContext();
            db.Configuration.LazyLoadingEnabled = false;
            return db;
        }

        /// <summary>
        /// Processes the specified action and wraps it with common logging and error handling logic.
        /// </summary>
        /// <remarks>
        /// If any exception is thrown, the <see cref="ArgumentException"/>, <see cref="ConfigurationException"/>,
        /// and <see cref="ServiceException"/> exceptions will be simply re-thrown. <see cref="EntityException"/>
        /// exceptions will be wrapped in <see cref="PersistenceException"/> exceptions. All other exceptions
        /// will be wrapped in <see cref="ServiceException"/> and thrown.
        /// </remarks>
        /// <param name="action">The action to process.</param>
        /// <param name="methodDescription">The short description of what the source method does.</param>
        /// <param name="saveChanges">The value indicating whether changes should be saved to database.</param>
        /// <param name="callingMethod">The source method information.</param>
        /// <param name="parameters">The parameters for the source method.</param>
        protected void ProcessWithDb(Action<TContext> action, string methodDescription,
            bool saveChanges = false, MethodBase callingMethod = null, params object[] parameters)
        {
            callingMethod = callingMethod ?? new StackTrace().GetFrame(1).GetMethod();
            Logger.Process(() =>
            {
                try
                {
                    using (var context = CreateDbContext())
                    {
                        action(context);
                        if (saveChanges)
                        {
                            context.SaveChanges();
                        }
                    }
                }
                catch (EntityException ex)
                {
                    throw new PersistenceException("Error occurred while accessing database persistence.", ex);
                }
            },
                methodDescription,
                callingMethod: callingMethod,
                parameters: parameters);
        }

        /// <summary>
        /// Processes the specified action and wraps it with common logging and error handling logic.
        /// </summary>
        /// <remarks>
        /// If any exception is thrown, the <see cref="ArgumentException"/>, <see cref="ConfigurationException"/>,
        /// and <see cref="ServiceException"/> exceptions will be simply re-thrown. <see cref="EntityException"/>
        /// exceptions will be wrapped in <see cref="PersistenceException"/> exceptions. All other exceptions
        /// will be wrapped in <see cref="ServiceException"/> and thrown.
        /// </remarks>
        /// <typeparam name="T">The type of the function result.</typeparam>
        /// <param name="function">The function to process.</param>
        /// <param name="methodDescription">The short description of what the source method does.</param>
        /// <param name="saveChanges">The value indicating whether changes should be saved to database.</param>
        /// <param name="callingMethod">The source method information.</param>
        /// <param name="parameters">The parameters for the source method.</param>
        /// <returns>The result of the function.</returns>
        protected T ProcessWithDb<T>(Func<TContext, T> function, string methodDescription,
            bool saveChanges = false, MethodBase callingMethod = null, params object[] parameters)
        {
            callingMethod = callingMethod ?? new StackTrace().GetFrame(1).GetMethod();
            return Logger.Process(() =>
            {
                try
                {
                    using (var context = CreateDbContext())
                    {
                        T result = function(context);
                        if (saveChanges)
                        {
                            context.SaveChanges();
                        }
                        return result;
                    }
                }
                catch (EntityException ex)
                {
                    throw new PersistenceException("Error occurred while accessing database persistence.", ex);
                }
            },
                methodDescription,
                callingMethod: callingMethod,
                parameters: parameters);
        }

        /// <summary>
        /// Resolves given identifiable entities.
        /// </summary>
        /// <typeparam name="T">The actual type of entities in the collection.</typeparam>
        /// <param name="context">The DB context.</param>
        /// <param name="items">The entities to resolve.</param>
        /// <remarks>All exceptions will be propagated.</remarks>
        protected static void ResolveEntities<T>(DbContext context, IList<T> items)
            where T : IdentifiableEntity
        {
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = ResolveChildEntity(context, items[i]);
                }
            }
        }

        /// <summary>
        /// Check that entity is not <c>null</c> and tries to retrieve its updated value from the database context.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity from the database context.</returns>
        /// <remarks>All exceptions will be propagated.</remarks>
        protected static TEntity ResolveChildEntity<TEntity>(DbContext context, TEntity entity)
            where TEntity : IdentifiableEntity
        {
            if (entity == null)
            {
                return null;
            }

            TEntity child = context.Set<TEntity>().Find(entity.Id);

            if (child == null)
            {
                throw new ServiceException(
                    $"Child entity {typeof(TEntity).Name} with Id={entity.Id} was not found.");
            }

            return child;
        }
    }
}