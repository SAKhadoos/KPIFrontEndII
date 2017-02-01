/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */
using JohnHancock.Common.Entities;

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents decimal or percentage value.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <remarks>
    /// Changes in 1.1:
    /// John Hancock - Coeus Security Updates and KPI Scorecard Frontend Integration 1 Assembly v1.0
    /// https://www.topcoder.com/challenge-details/30056065
    /// </remarks>
    ///
    /// <author>[es], NightWolf, TCSASSEMBLER</author>
    /// <version>1.1</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class DecimalOrPercentageValue : IdentifiableEntity
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value represents percentage.
        /// </summary>
        /// <value>
        /// <c>true</c> if the value represents percentage; otherwise, <c>false</c>.
        /// </value>
        public bool Percentage { get; set; }

        /// <summary>
        /// Gets or sets the additional note.
        /// </summary>
        /// <value>
        /// The additional note.
        /// </value>
        public string AdditionalNote { get; set; }

        /// <summary>
        /// Copies the values from given source entity.
        /// </summary>
        /// <param name="source">The source.</param>
        internal void CopyValuesFrom(DecimalOrPercentageValue source)
        {
            Value = source.Value;
            Percentage = source.Percentage;
            AdditionalNote = source.AdditionalNote;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalOrPercentageValue"/> class.
        /// </summary>
        public DecimalOrPercentageValue()
        {
        }
    }
}
