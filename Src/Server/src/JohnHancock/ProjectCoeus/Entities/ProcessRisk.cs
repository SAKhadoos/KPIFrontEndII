/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

using System.Collections.Generic;

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the process and risk. The name is process, the 'Risk' field is risk.
    /// </summary>
    ///
    /// <remarks>
    /// Note that the properties are implemented without any validation.
    ///
    /// Changes in 1.1 during John Hancock - Project Coeus Admin Frontend Assembly Part 1
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>LOY, NightWolf, veshu</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class ProcessRisk : BusinessUnitFunctionalAreaLookupEntity
    {
        /// <summary>
        /// Gets or sets the risk.
        /// </summary>
        /// <value>
        /// The risk.
        /// </value>
        public string Risk { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the control types.
        /// </summary>
        /// <value>
        /// The additional control types.
        /// </value>
        public IList<ControlType> ControlTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessRisk"/> class.
        /// </summary>
        public ProcessRisk()
        {
        }
    }
}