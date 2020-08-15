using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Statistic
{

    public class StatisticCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// </summary>
        public string Referrer { get; set; }

        /// <summary>
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// </summary>
        public string UserOs { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ViewedOn { get; set; }

        #endregion Public Properties
    }
}