/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An entity class that represents the sub process and risk. The name is process, the 'Risk' field is risk.
    /// </summary>
    ///
    /// <remarks>
    /// Note that the properties are implemented without any validation.
    /// Changes in 1.1 during JOHN HANCOCK - PROJECT COEUS ADMIN BACKEND ASSEMBLY
    /// </remarks>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>veshu, albertwang</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public class SubProcessRisk : ProcessRiskEntity
    {
        /// <summary>
        /// Gets or sets the core process.
        /// </summary>
        /// <value>The core process.</value>
        public CoreProcess CoreProcess { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubProcessRisk"/> class.
        /// </summary>
        public SubProcessRisk()
        {
        }
    }
}