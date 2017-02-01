/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.KPIScorecard.Services;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;
using Microsoft.Practices.Unity;
using System.Web.Http;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common;
using JohnHancock.Common.API.Controllers;
using JohnHancock.KPIScorecard.Exceptions;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.KPIScorecard.API.Controllers
{
    /// <summary>
    /// This controller exposes actions to manage business unit KPI scorecards.
    /// </summary>
    /// 
    /// <threadsafety>
    /// This class is mutable but effectively thread-safe.
    /// </threadsafety>
    /// 
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>[es], NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    [RoutePrefix("api/v1")]
    public class BusinessUnitKPIScorecardController : BaseController
    {
        /// <summary>
        /// Gets or sets the <see cref="IBusinessUnitKPIScorecardService"/> dependency.
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
        /// <value>The <see cref="IBusinessUnitKPIScorecardService"/> dependency.</value>
        [Dependency]
        public IBusinessUnitKPIScorecardService BusinessUnitKPIScorecardService { get; set; }

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
        /// Initializes a new instance of the <see cref="BusinessUnitKPIScorecardController"/> class.
        /// </summary>
        public BusinessUnitKPIScorecardController()
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

            CommonHelper.ValidateConfigPropertyNotNull(BusinessUnitKPIScorecardService,
                nameof(BusinessUnitKPIScorecardService));
            CommonHelper.ValidateConfigPropertyPositive(InputAllowedInDays, nameof(InputAllowedInDays));
        }

        /// <summary>
        /// Retrieves number of allowed days for scorecard modification.
        /// </summary>
        ///
        /// <returns>The number of allowed input days.</returns>
        [HttpGet]
        [Route("businessUnitKPIScorecards/inputAllowedDays")]
        public int GetInputAllowedDays()
        {
            return InputAllowedInDays;
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
        [Route("businessUnitKPIScorecards/{id}")]
        public BusinessUnitKPIScorecard Get(long id)
        {
            return BusinessUnitKPIScorecardService.Get(id);
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
        [Route("businessUnitKPIScorecards")]
        public SearchResult<BusinessUnitKPIScorecard> Search([FromUri]BusinessUnitKPIScorecardSearchCriteria criteria)
        {
            criteria = criteria ?? new BusinessUnitKPIScorecardSearchCriteria();
            return BusinessUnitKPIScorecardService.Search(criteria);
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
        [Route("businessUnitKPIScorecards/{id}")]
        public BusinessUnitKPIScorecard Update(long id, BusinessUnitKPIScorecard entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            Helper.ValidateTodayIsAllowedUpdateDate(entity.Year, entity.Month, InputAllowedInDays);

            var existing = BusinessUnitKPIScorecardService.Get(id);
            if (!IsAdmin())
            {
                Helper.ValidateStatusIsDraft(existing.Status);
            }

            // populate audit fields
            PopulateAuditFields(entity, existing);

            entity.Id = id;
            return BusinessUnitKPIScorecardService.Update(entity);
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
        /// If current action is forbidden due to restriction of input allowed days,
        /// or if <see cref="BusinessUnitKPIScorecard"/> already exists for the given year and month.
        /// </exception>
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpPost]
        [Route("businessUnitKPIScorecards")]
        public long Create(BusinessUnitKPIScorecard entity)
        {
            CommonHelper.ValidateArgumentNotNull(entity, nameof(entity));
            Helper.ValidateTodayIsAllowedUpdateDate(entity.Year, entity.Month, InputAllowedInDays);

            int count = BusinessUnitKPIScorecardService.Search(new BusinessUnitKPIScorecardSearchCriteria
            {
                // use PageNumber=1 and PageSize=0 to get count only
                PageNumber = 1,
                BusinessUnitId = entity.BusinessUnit?.Id,
                YearId = entity.Year.Id,
                MonthId = entity.Month.Id
            }).TotalRecords;

            if (count > 0)
            {
                throw new BusinessProcessingException(
                    "BusinessUnitKPIScorecard already exists for the given year and month.");
            }

            // populate audit fields
            PopulateAuditFields(entity, null, creating: true);

            return BusinessUnitKPIScorecardService.Create(entity).Id;
        }
    }
}
