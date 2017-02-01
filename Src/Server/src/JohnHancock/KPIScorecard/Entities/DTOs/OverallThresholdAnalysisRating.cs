/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities.DTOs
{
    /// <summary>
    /// An enum that represents overall threshold analysis rating.
    /// </summary>
    ///
    /// <threadsafety>
    /// Enum is immutable and thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public enum OverallThresholdAnalysisRating
    {
        /// <summary>
        /// Represents the Exceeding targets threshold analysis rating.
        /// </summary>
        ExceedingTargets,

        /// <summary>
        /// Represents the Meeting targets threshold analysis rating.
        /// </summary>
        MeetingTargets,

        /// <summary>
        /// Represents the Below targets threshold analysis rating.
        /// </summary>
        BelowTargets
    }
}
