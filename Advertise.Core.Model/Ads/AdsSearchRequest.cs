using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Ads
{

    public class AdsSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public bool? IsApprove { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? OwnerId { get; set; }

        #endregion Public Properties
    }
}