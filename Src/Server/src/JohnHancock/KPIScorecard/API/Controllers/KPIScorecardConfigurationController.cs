/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.KPIScorecard.Services;
using JohnHancock.KPIScorecard.Entities.DTOs;
using Microsoft.Practices.Unity;
using System.Web.Http;
using JohnHancock.Common;
using JohnHancock.Common.API.Controllers;
using JohnHancock.Common.Exceptions;

namespace JohnHancock.KPIScorecard.API.Controllers
{
    /// <summary>
    /// This controller exposes actions to manage admin configurations.
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
    public class KPIScorecardConfigurationController : BaseController
    {
        /// <summary>
        /// Gets or sets the <see cref="IKPIScorecardConfigurationService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for managing admin configurations.
        /// </remarks>
        ///
        /// <value>The <see cref="IKPIScorecardConfigurationService"/> dependency.</value>
        [Dependency]
        public IKPIScorecardConfigurationService KPIScorecardConfigurationService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIScorecardConfigurationController"/> class.
        /// </summary>
        public KPIScorecardConfigurationController()
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

            CommonHelper.ValidateConfigPropertyNotNull(KPIScorecardConfigurationService,
                nameof(KPIScorecardConfigurationService));
        }

        /// <summary>
        /// Gets the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <returns>The KPI Scorecard configuration.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("kpiScorecardConfiguration")]
        public KPIScorecardConfiguration GetKPIScorecardConfiguration()
        {
            return KPIScorecardConfigurationService.GetKPIScorecardConfiguration();
        }

        /// <summary>
        /// Saves the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <param name="configuration">The KPI Scorecard configuration.</param>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpPut]
        [Route("kpiScorecardConfiguration")]
        public void SaveKPIScorecardConfiguration(KPIScorecardConfiguration configuration)
        {
            KPIScorecardConfigurationService.SaveKPIScorecardConfiguration(configuration);
        }

        /// <summary>
        /// Gets the business unit configuration.
        /// </summary>
        /// 
        /// <returns>The business unit configuration.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("businessUnitConfiguration")]
        public BusinessUnitConfig GetBusinessUnitConfiguration()
        {
            return KPIScorecardConfigurationService.GetBusinessUnitConfiguration();
        }

        /// <summary>
        /// Gets the operational incident configuration.
        /// </summary>
        /// 
        /// <returns>The operational incident configuration.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("operationalIncidentConfiguration")]
        public OperationalIncidentConfig GetOperationalIncidentConfiguration()
        {
            return KPIScorecardConfigurationService.GetOperationalIncidentConfiguration();
        }

        /// <summary>
        /// Gets the audit finding configuration.
        /// </summary>
        /// 
        /// <returns>The audit finding configuration.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("auditFindingConfiguration")]
        public AuditFindingConfig GetAuditFindingConfiguration()
        {
            return KPIScorecardConfigurationService.GetAuditFindingConfiguration();
        }

        /// <summary>
        /// Gets the privacy incident configuration.
        /// </summary>
        /// 
        /// <returns>The privacy incident configuration.</returns>
        /// 
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("privacyIncidentConfiguration")]
        public PrivacyIncidentConfig GetPrivacyIncidentConfiguration()
        {
            return KPIScorecardConfigurationService.GetPrivacyIncidentConfiguration();
        }
    }
}
