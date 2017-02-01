/*
 * Copyright (c) 2016, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.ProjectCoeus.Entities
{
    /// <summary>
    /// An enum that represents the add-on status of a lookup entity.
    /// </summary>
    ///
    /// <threadsafety>
    /// Enum is immutable and thread-safe.
    /// </threadsafety>
    ///
    /// <author>albertwang, veshu</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2016, TopCoder, Inc. All rights reserved.</copyright>
    public enum AddOnStatus
    {
        /// <summary>
        /// This enum value indicates the add-on is pending.
        /// </summary>
        Pending,

        /// <summary>
        /// This enum value indicates the add-on is approved.
        /// </summary>
        Approved,

        /// <summary>
        /// This enum value indicates the add-on is rejected.
        /// </summary>
        Rejected
    }
}