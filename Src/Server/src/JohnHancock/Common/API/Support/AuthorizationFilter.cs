/*
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 */
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using JohnHancock.Common.Entities.DTOs;
using JohnHancock.Common.Exceptions;
using JohnHancock.Common.Services;
using log4net;
using Microsoft.Practices.Unity;

namespace JohnHancock.Common.API.Support
{
    /// <summary>
    /// This action filter checks if user is logged in, and has permission to perform the action.
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
    /// <author>LOY, NightWolf, [es]/TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.</copyright>
    public class AuthorizationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the logger used for logging in this class.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for logging in this class and its sub-classes.
        /// </remarks>
        ///
        /// <value>The logger.</value>
        [Dependency]
        public ILog Logger { get; set; }

        /// <summary>
        /// Gets or sets the Security service.
        /// </summary>
        ///
        /// <remarks>
        /// <para>
        /// It is expected to be initialized by Unity and never changed after that.
        /// Should not be <c>null</c> after initialization.
        /// </para>
        /// It is used for user authentication.
        /// </remarks>
        ///
        /// <value>The Security service.</value>
        [Dependency]
        public ISecurityService SecurityService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilter"/> class.
        /// </summary>
        public AuthorizationFilter()
        {
        }

        /// <summary>
        /// Checks that all configuration properties were properly initialized.
        /// </summary>
        ///
        /// <exception cref="ConfigurationException">
        /// If any of required injection fields are not injected or have invalid values.
        /// </exception>
        public void CheckConfiguration()
        {
            CommonHelper.ValidateConfigPropertyNotNull(Logger, nameof(Logger));
            CommonHelper.ValidateConfigPropertyNotNull(SecurityService, nameof(SecurityService));
        }

        /// <summary>
        /// Validates user token and authorization.
        /// </summary>
        ///
        /// <remarks>
        /// All exceptions from back-end services will be propagated.
        /// </remarks>
        ///
        /// <param name="context">The action context.</param>
        /// 
        /// <exception cref="AuthenticationException">
        /// If Bearer token is not provided or token is invalid or expired.
        /// </exception>
        /// <exception cref="AuthorizationException">
        /// If user is not authorized to perform current action.
        /// </exception>
        public override void OnActionExecuting(HttpActionContext context)
        {
            string methodName = $"{nameof(AuthorizationFilter)}.{nameof(OnActionExecuting)}";
            Logger.DebugFormat("Entering '{0}' to validate the token.", methodName);

            // skip controllers or actions which allow anonymous access
            var actionDescriptor = context.ActionDescriptor;
            if (actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any() ||
                actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any())
            {
                Logger.Debug("Token is not required for the current action.");
                return;
            }

            // check whether Bearer token is provided
            if (context.Request.Headers.Authorization == null ||
                context.Request.Headers.Authorization.Scheme != "Bearer")
            {
                throw new AuthenticationException("Bearer Token is missing.");
            }

            // perform authentication
            User user = SecurityService.Authenticate(context.Request.Headers.Authorization.Parameter);
            if (user == null)
            {
                throw new AuthenticationException("Token was not found or has been expired.");
            }

            Logger.Debug("Token is valid.");

            // check authorization
            string actionName = context.GetFullActionName(false);
            bool authorized = user.Role != null && SecurityService.IsAuthorized(user.Role.Value, actionName);
            if (!authorized)
            {
                authorized = user.KPIRole != null && SecurityService.IsAuthorized(user.KPIRole.Value, actionName);
            }

            if (!authorized)
            {
                throw new AuthorizationException("You are not authorized to perform this action.");
            }

            context.Request.Properties.Add(CommonHelper.CurrentUserPropertyName, user);
            Logger.DebugFormat("Exiting '{0}'.", methodName);
        }
    }
}
