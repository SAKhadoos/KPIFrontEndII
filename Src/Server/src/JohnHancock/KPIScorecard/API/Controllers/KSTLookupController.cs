/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using System.Web.Http;
using JohnHancock.Common;
using JohnHancock.Common.API.Controllers;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Services;
using Microsoft.Practices.Unity;

namespace JohnHancock.KPIScorecard.API.Controllers
{
    /// <summary>
    /// This controller exposes actions to retrieve lookup and value entities.
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
    public class KSTLookupController : BaseController
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
        /// It is used for retrieving lookup and value entities.
        /// </remarks>
        ///
        /// <value>The <see cref="ILookupService"/> dependency.</value>
        [Dependency]
        public ILookupService LookupService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KSTLookupController"/> class.
        /// </summary>
        public KSTLookupController()
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

        /// <summary>
        /// Retrieves all lookup entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("lookups")]
        public IList<LookupEntity> GetLookupEntities(string type)
        {
            return LookupService.GetLookupEntities(type);
        }

        /// <summary>
        /// Retrieves all value entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <remarks>Exceptions from services will be propagated.</remarks>
        [HttpGet]
        [Route("values")]
        public IList<ValueEntity> GetValueEntities(string type)
        {
            return LookupService.GetValueEntities(type);
        }
    }
}
