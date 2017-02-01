/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// A DTO entity class that represents privacy incident configuration.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class PrivacyIncidentConfig
    {
        /// <summary>
        /// Gets or sets the root cause configuration.
        /// </summary>
        /// <value>
        /// The root cause configuration.
        /// </value>
        public IList<PrivacyIncidentRootCauseValue> RootCauseConfig { get; set; }

        /// <summary>
        /// Gets or sets the type configuration.
        /// </summary>
        /// <value>
        /// The type configuration.
        /// </value>
        public IList<PrivacyIncidentTypeValue> TypeConfig { get; set; }

        /// <summary>
        /// Gets or sets the migration code configuration.
        /// </summary>
        /// <value>
        /// The migration code configuration.
        /// </value>
        public IList<PrivacyIncidentMitigationCodeValue> MigrationCodeConfig { get; set; }

        /// <summary>
        /// Gets or sets the status configuration.
        /// </summary>
        /// <value>
        /// The status configuration.
        /// </value>
        public IList<PrivacyIncidentStatusValue> StatusConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyIncidentConfig"/> class.
        /// </summary>
        public PrivacyIncidentConfig()
        {
        }
    }
}
