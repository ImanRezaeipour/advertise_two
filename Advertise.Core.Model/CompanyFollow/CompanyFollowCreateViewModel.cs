using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyFollow
{

    public class CompanyFollowCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CompanyId { get; set; }

        public Guid FollowedById { get; set; }

        /// <summary>
        /// </summary>
        public bool IsFollow { get; set; }

        #endregion Public Properties
    }
}