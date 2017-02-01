/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.KPIScorecard.Entities;
using JohnHancock.KPIScorecard.Entities.DTOs;

namespace JohnHancock.KPIScorecard.Services
{
    /// <summary>
    /// This interface defines operations for managing business unit KPI scorecards.
    /// </summary>
    ///
    /// <threadsafety>
    /// Implementations of this interface should be effectively thread safe.
    /// </threadsafety>
    /// 
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public interface IBusinessUnitKPIScorecardService :
        IGenericService<BusinessUnitKPIScorecard, BusinessUnitKPIScorecardSearchCriteria>
    {
    }
}
