/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.KPIScorecard.Services;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using Microsoft.Practices.Unity;
using JohnHancock.Common.API.Controllers;
using System.Web.Http;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common;
using JohnHancock.KPIScorecard.Exceptions;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.KPIScorecard.API.Controllers
{
    /// <summary>
    /// This controller exposes actions to manage audit findings.
    /// </summary>
    /// 
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    [RoutePrefix("api/v1")]
    public class AuditFindingController : BaseController
    {
        /// <summary>
        /// Gets or sets the <see cref="IAuditFindingService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for managing corresponding entities.
        /// </remarks>
        ///
        /// <value>The <see cref="IAuditFindingService"/> dependency.</value>
        [Dependency]
        public IAuditFindingService AuditFindingService { get; set; }

        /// <summary>
        /// Gets or sets the allowed number of days from the beginning
        /// of the month when entity can be created/updated.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should be positive after initialization.
        /// </para>
        /// It is used for validation in create/update actions.
        /// </remarks>
        ///
        /// <value>The allowed number of days from the beginning
        /// of the month when entity can be created/updated.</value>
        [Dependency]
        public int InputAllowedInDays { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditFindingController"/> class.
        /// </summary>
        public AuditFindingController()
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

            CommonHelper.ValidateConfigPropertyNotNull(AuditFindingService, nameof(AuditFindingService));
            CommonHelper.ValidateConfigPropertyPositive(InputAllowedInDays, nameof(InputAllowedInDays));
        }

        /// <summary>
        /// Retrieves entity with the given Id.
        /// </summary>
        ///
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The retrieved entity.</returns>
        ///
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("auditFindings/{id}")]
        public AuditFinding Get(long id)
        {
            return AuditFindingService.Get(id);
        }

        /// <summary>
        /// Retrieves entities matching given search criteria.
        /// </summary>
        ///
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The matched entities.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("auditFindings")]
        public SearchResult<AuditFinding> Search([FromUri]AuditFindingSearchCriteria criteria)
        {
            criteria = criteria ?? new AuditFindingSearchCriteria();
            return AuditFindingService.Search(criteria);
        }

        /// <summary>
        /// Updates given entity.
        /// </summary>
        ///
        /// <param name="id">The id of the entity to update.</param>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="entity"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If entity's Year or Month is null or cannot be parsed.
        /// </exception>
        /// <exception cref="BusinessProcessingException">
        /// If current action is forbidden due to restriction of input allowed days,
        /// or if user is not admin and entity is not in a Draft status.
        /// </exception>
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpPut]
        [Route("auditFindings/{id}")]
        public AuditFinding Update(long id, AuditFinding entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            Helper.ValidateTodayIsAllowedUpdateDate(entity.AuditYear, entity.AuditMonth, InputAllowedInDays);

            var existing = AuditFindingService.Get(id);
            if (!IsAdmin())
            {
                Helper.ValidateStatusIsDraft(existing.Status);
            }

            // populate audit fields
            PopulateAuditFields(entity, existing);

            entity.Id = id;
            return AuditFindingService.Update(entity);
        }

        /// <summary>
        /// Creates given entity.
        /// </summary>
        ///
        /// <param name="entity">The entity to create.</param>
        /// <returns>The Id of the created entity.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="entity"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If entity's Year or Month is null or cannot be parsed.
        /// </exception>
        /// <exception cref="BusinessProcessingException">
        /// If current action is forbidden due to restriction of input allowed days.
        /// </exception>
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpPost]
        [Route("auditFindings")]
        public long Create(AuditFinding entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            Helper.ValidateTodayIsAllowedUpdateDate(entity.AuditYear, entity.AuditMonth, InputAllowedInDays);

            // populate audit fields
            PopulateAuditFields(entity, null, creating: true);

            return AuditFindingService.Create(entity).Id;
        }

        /// <summary>
        /// Gets the last tallied number for the given year and month.
        /// </summary>
        /// 
        /// <param name="year">The year to match.</param>
        /// <param name="month">The month to match.</param>
        /// <returns>The last tallied number.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("auditFindingLastTalliedNumber")]
        public int GetLastTalliedNumber(int year, int month)
        {
            return AuditFindingService.GetLastTalliedNumber(year, month);
        }
    }
}
