/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Services
{
    /// <summary>
    /// This interface defines operations for managing configuration.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public interface IKPIScorecardConfigurationService
    {
        /// <summary>
        /// Gets the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <returns>The KPI Scorecard configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        KPIScorecardConfiguration GetKPIScorecardConfiguration();

        /// <summary>
        /// Saves the KPI Scorecard configuration.
        /// </summary>
        /// 
        /// <param name="configuration">The KPI Scorecard configuration.</param>
        /// 
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="configuration"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        void SaveKPIScorecardConfiguration(KPIScorecardConfiguration configuration);

        /// <summary>
        /// Gets the operational incident configuration.
        /// </summary>
        /// 
        /// <returns>The operational incident configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        OperationalIncidentConfig GetOperationalIncidentConfiguration();

        /// <summary>
        /// Gets the audit finding configuration.
        /// </summary>
        /// 
        /// <returns>The audit finding configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        AuditFindingConfig GetAuditFindingConfiguration();

        /// <summary>
        /// Gets the privacy incident configuration.
        /// </summary>
        /// 
        /// <returns>The privacy incident configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        PrivacyIncidentConfig GetPrivacyIncidentConfiguration();

        /// <summary>
        /// Gets the business unit configuration.
        /// </summary>
        /// 
        /// <returns>The business unit configuration.</returns>
        /// 
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        BusinessUnitConfig GetBusinessUnitConfiguration();
    }
}
