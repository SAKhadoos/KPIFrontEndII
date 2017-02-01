/*
 * Copyright (c) 2017, TopCoder, Inc. All rights reserved.
 */

namespace JohnHancock.KPIScorecard.Entities
{
    /// <summary>
    /// A entity class that represents KPI volume score.
    /// </summary>
    ///
    /// <threadsafety>
    /// This class is mutable, so it is not thread-safe.
    /// </threadsafety>
    ///
    /// <author>[es], NightWolf</author>
    /// <version>1.0</version>
    /// <copyright>Copyright (c) 2017, TopCoder, Inc. All rights reserved.</copyright>
    public class KPIVolumeScore : KPIScore
    {
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public decimal Volume { get; set; }

        /// <summary>
        /// Gets or sets the type of the volume.
        /// </summary>
        /// <value>
        /// The type of the volume.
        /// </value>
        public VolumeTypeValue VolumeType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIVolumeScore"/> class.
        /// </summary>
        public KPIVolumeScore()
        {
        }
    }
}
