/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JohnHancock.KPIScorecard.Services.Impl;
using JohnHancock.KPIScorecard.Entities;

namespace JohnHancock.KPIScorecard.Tests.Services.Impl
{
    /// <summary>
    /// Unit tests for <see cref="LookupService"/> class.
    /// </summary>
    ///
    /// <author>
    /// NightWolf
    /// </author>
    ///
    /// <version>
    /// 1.0
    /// </version>
    ///
    /// <copyright>
    /// Copyright (c) 2017, TopCoder, Inc. All rights reserved.
    /// </copyright>
    [TestClass]
    public class LookupServiceUnitTest : BaseServiceUnitTest<LookupService>
    {
        #region GetLookupEntities(string) method tests

        /// <summary>
        /// Accuracy test of <c>GetLookupEntities</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetLookupEntitiesAccuracy()
        {
            // arrange
            IList<Type> lookupTypes = GetAllEntities<LookupEntity>().ToList();

            // act
            var result = new List<LookupEntity>();
            foreach (Type type in lookupTypes)
            {
                IList<LookupEntity> entities = instance.GetLookupEntities(type.Name);
                result.AddRange(entities);
            }

            // assert
            AssertResult(result);
        }

        #endregion

        #region GetValueEntities(string) method tests

        /// <summary>
        /// Accuracy test of <c>GetValueEntities</c> method,
        /// result should be correct.
        /// </summary>
        [TestMethod]
        public void TestGetValueEntitiesAccuracy()
        {
            // arrange
            IList<Type> lookupTypes = GetAllEntities<ValueEntity>().ToList();

            // act
            var result = new List<ValueEntity>();
            foreach (Type type in lookupTypes)
            {
                IList<ValueEntity> entities = instance.GetValueEntities(type.Name);
                result.AddRange(entities);
            }

            // assert
            AssertResult(result);
        }

        #endregion

        /// <summary>
        /// Gets all entities derived from <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The base type.</typeparam>
        /// <returns>All entities derived from <typeparamref name="T"/>.</returns>
        private IEnumerable<Type> GetAllEntities<T>()
        {
            Type baseType = typeof(T);
            return baseType.Assembly.GetExportedTypes()
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
        }
    }
}
