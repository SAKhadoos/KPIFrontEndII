/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// An enum that represents financial exposure value type.
    /// </summary>
    ///
    /// <threadsafety>
    /// Enum is immutable and thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public enum FinancialExposureValueType
    {
        /// <summary>
        /// Represents the financial exposure Amount type.
        /// </summary>
        Amount,

        /// <summary>
        /// Represents the financial exposure TBD type.
        /// </summary>
        TBD,

        /// <summary>
        /// Represents the financial exposure N/A type.
        /// </summary>
        NA
    }
}
