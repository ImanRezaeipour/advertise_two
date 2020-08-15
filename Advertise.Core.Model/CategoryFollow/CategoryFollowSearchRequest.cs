using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CategoryFollow
{

    public class CategoryFollowSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CategoryId { get; set; }
        public Guid? FollowedById { get; set; }
        public bool? IsFollow { get; set; }

        #endregion Public Properties
    }
}