using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyFollow
{

    public class CompanyFollowSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? FollowedById { get; set; }
        public bool? IsFollow { get; set; }

        #endregion Public Properties
    }
}