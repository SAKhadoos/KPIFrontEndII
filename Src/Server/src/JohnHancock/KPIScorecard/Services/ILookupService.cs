/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using JohnHancock.Common.Exceptions;
using JohnHancock.KPIScorecard.Entities;

namespace JohnHancock.KPIScorecard.Services
{
    /// <summary>
    /// This interface defines operations for retrieving lookup and value entities.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public interface ILookupService
    {
        /// <summary>
        /// Retrieves all lookup entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="type"/> is empty string.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<LookupEntity> GetLookupEntities(string type);

        /// <summary>
        /// Retrieves all value entities of the given type.
        /// </summary>
        ///
        /// <returns>The retrieved entities. Empty list will be returned in case none is found.</returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// If the <paramref name="type"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If the <paramref name="type"/> is empty string.
        /// </exception>
        /// <exception cref="PersistenceException">
        /// If error occurs while accessing the persistence.
        /// </exception>
        /// <exception cref="ServiceException">
        /// If any other errors occur while performing this operation.
        /// </exception>
        IList<ValueEntity> GetValueEntities(string type);
    }
}
