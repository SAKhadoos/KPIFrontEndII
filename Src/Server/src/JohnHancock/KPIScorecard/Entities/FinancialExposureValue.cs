/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents financial exposure value.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class FinancialExposureValue : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        /// <value>
        /// The value type.
        /// </value>
        public FinancialExposureValueType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialExposureValue"/> class.
        /// </summary>
        public FinancialExposureValue()
        {
        }
    }
}
