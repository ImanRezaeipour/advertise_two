using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Statistics
{

    public class Statistic : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public virtual string ActionName { get; set; }

        /// <summary>
        /// </summary>
        public virtual string ControllerName { get; set; }

        /// <summary>
        /// </summary>
        public virtual string IpAddress { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Latitude { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Longitude { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Referrer { get; set; }

        /// <summary>
        /// </summary>
        public virtual string UserAgent { get; set; }

        /// <summary>
        /// </summary>
        public virtual string UserOs { get; set; }

        /// <summary>
        /// </summary>
        public virtual DateTime? ViewedOn { get; set; }

        #endregion Public Properties
    }
}