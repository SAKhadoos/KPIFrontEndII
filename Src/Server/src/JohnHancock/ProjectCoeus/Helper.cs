/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using JohnHancock.ProjectCoeus.Entities;
using JohnHancock.ProjectCoeus.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using JohnHancock.Common;
using JohnHancock.Common.Entities;
using JohnHancock.Common.Entities.DTOs;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.ProjectCoeus
{
    /// <summary>
    /// This class is the helper class for this project.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is immutable and thread safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT
    /// - Added method 'SetPaging'
    /// Changes in 1.2 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// Changes in 1.3 - Extracted common methods to CommonHelper class.
    /// </remarks>
    ///
    /// <author>NightWolf, veshu, NightWolf</author>
    /// <version>1.3</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    internal static class Helper
    {
        /// <summary>
        /// Applies the condition to filter the enabled and approved lookup entities only.
        /// </summary>
        /// <typeparam name="T">The type of the lookup entities to retrieve.</typeparam>
        ///
        /// <param name="query">The query.</param>
        ///
        /// <returns>The query.</returns>
        /// <remarks>Any exceptions are thrown to the caller.</remarks>
        internal static IQueryable<T> ActiveOnly<T>(this IQueryable<T> query) where T : LookupEntity
        {
            return query.Where(x => x.Enabled && x.AddOnStatus == AddOnStatus.Approved);
        }

        /// <summary>
        /// Creates IQueryable pagination with search criteria.
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="source">The IQueryable source.</param>
        /// <param name="criteria">The search criteria</param>
        /// <returns>The new IQueryable with paging.</returns>
        /// <remarks>The internal exception may be thrown directly.</remarks>
        internal static IQueryable<T> SetPaging<T>(this IQueryable<T> source, BaseSearchCriteria criteria)
        {
            return source.Skip(criteria.PageSize * (criteria.PageNumber - 1)).Take(criteria.PageSize);
        }

        /// <summary>
        /// Validates the risk score range.
        /// </summary>
        /// <param name="riskScoreRanges">The risk scores.</param>
        /// <exception cref="ServiceException">If any risk score range contains negative lower bound or
        /// upper bound less than the lower bound.</exception>
        internal static void ValidateRiskScoreEntities(IList<RiskScoreRange> riskScoreRanges)
        {
            foreach (var entity in riskScoreRanges)
            {
                CommonHelper.ValidateNotNullPositive(entity.LowerBound, nameof(entity.LowerBound));

                if (entity.LowerBound != null && entity.UpperBound.HasValue
                    && entity.UpperBound < entity.LowerBound.Value)
                {
                    throw new ArgumentException(
                        "The upper bound of risk score range should not be less than the lower bound");
                }
            }
        }

        /// <summary>
        /// Audits assessment CUD operations.
        /// </summary>
        /// <param name="service">The audit service instance.</param>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <param name="action">The action name.</param>
        /// <param name="username">The current username.</param>
        /// <param name="propertiesToSkipAuditing">The properties to skip.</param>
        /// <remarks>All exceptions will be propagated to caller method.</remarks>
        internal static void Audit<T>(IAuditService service, T oldEntity, T newEntity,
            string action, string username,
            IList<string> propertiesToSkipAuditing = null)
            where T : IdentifiableEntity
        {
            JObject oldObject = null;
            var serializwer = JsonSerializer.Create(CommonHelper.SerializerSettings);
            JObject newObject = JObject.FromObject(newEntity, serializwer);
            IList<JProperty> oldProperties = null;
            IList<JProperty> newProperties = newObject.Properties().ToList();

            if (oldEntity != null)
            {
                oldObject = JObject.FromObject(oldEntity, serializwer);
                oldProperties = oldObject.Properties().ToList();
            }

            // keep time, so that all records have the same timestamp (also slightly improves performance)
            DateTime now = DateTime.Now;

            // iterate through all object properties
            IEnumerable<string> propertyNames = (oldProperties ?? newProperties).Select(p => p.Name);
            foreach (string propertyName in propertyNames)
            {
                if (propertiesToSkipAuditing != null && propertiesToSkipAuditing.Contains(propertyName))
                {
                    continue;
                }

                JToken oldPropertyValue = null;
                JToken newPropertyValue = newObject.Property(propertyName).Value;

                if (oldEntity != null)
                {
                    oldPropertyValue = oldObject.Property(propertyName).Value;
                }

                // skip when both are null
                if (newPropertyValue.Type == JTokenType.Null && oldPropertyValue == null)
                {
                    continue;
                }

                // when properties are the same - skip auditing
                if (JToken.DeepEquals(oldPropertyValue, newPropertyValue))
                {
                    continue;
                }

                var record = new AuditRecord
                {
                    Action = action,
                    Field = propertyName,
                    ItemId = newEntity.Id,
                    ItemType = typeof(T).FullName,
                    Timestamp = now,
                    PreviousValue = CommonHelper.GetJtokenValue(oldPropertyValue),
                    NewValue = CommonHelper.GetJtokenValue(newPropertyValue),
                    Username = username
                };

                service.Create(record);
            }
        }


        /// <summary>
        /// Handles the exception occurred during delete operation to check the
        /// references constraint violation
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="entityName">The entity name.</param>
        /// <param name="message">The message for exception.</param>
        internal static void HandleDeleteException(Exception ex, string entityName, string message = null)
        {
            var dbUpdateEx = ex as DbUpdateException;
            var sqlException = dbUpdateEx?.InnerException?.InnerException as SqlException;

            if (sqlException == null)
            {
                throw ex;
            }

            switch (sqlException.Number)
            {
                case 547: // Constraint check violation
                    throw new ServiceException(
                        message ?? $"The {entityName} could not be deleted " +
                        "because either this entity or its child entity is referenced by assessment(s).");

                default:
                    throw ex;
            }
        }

        /// <summary>
        /// Handles the exception occurred during create/update operation to check the
        /// references unique key constraint violation.
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="entityName">The entity name.</param>
        /// <param name="message">The message for exception.</param>
        internal static void HandleCreateOrUpdateException(Exception ex, string entityName, string message = null)
        {
            var dbUpdateEx = ex as DbUpdateException;
            var sqlException = dbUpdateEx?.InnerException?.InnerException as SqlException;

            if (sqlException == null)
            {
                throw ex;
            }

            switch (sqlException.Number)
            {
                case 2627: // Unique constraint error
                    throw new ServiceException(
                        message ?? $"The {entityName} with given name/value already exists.");

                default:
                    throw ex;
            }
        }
    }
}