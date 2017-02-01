/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Web.Http;
using JohnHancock.Common;
using JohnHancock.Common.API.Controllers;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities.DTOs;
using JohnHancock.KPIScorecard.Services;
using Microsoft.Practices.Unity;

namespace JohnHancock.KPIScorecard.API.Controllers
{
    /// <summary>
    /// This controller exposes action to get statistics summary.
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
    public class SummaryController : BaseController
    {
        /// <summary>
        /// Gets or sets the <see cref="ISummaryService"/> dependency.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for retrieving statistics summary.
        /// </remarks>
        ///
        /// <value>The <see cref="ISummaryService"/> dependency.</value>
        [Dependency]
        public ISummaryService SummaryService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryController"/> class.
        /// </summary>
        public SummaryController()
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

            CommonHelper.ValidateConfigPropertyNotNull(SummaryService, nameof(SummaryService));
        }

        /// <summary>
        /// Gets the statistics summary.
        /// </summary>
        /// 
        /// <param name="businessUnitId">The business unit Id to get summary for.</param>
        /// <param name="yearId">The year Id to get summary for.</param>
        /// <param name="monthId">The month Id to get summary for.</param>
        /// <returns>The statistics summary.</returns>
        ///
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("summaries")]
        public Summary GetSummary(long businessUnitId, long yearId, long monthId)
        {
            return SummaryService.GetSummary(businessUnitId, yearId, monthId);
        }
    }
}
