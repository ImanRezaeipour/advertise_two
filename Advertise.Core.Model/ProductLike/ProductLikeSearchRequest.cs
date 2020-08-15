using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductLike
{

    public class ProductLikeSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public bool? IsLike { get; set; }
        public Guid? LikedById { get; set; }

        public Guid? ProductId { get; set; }

        #endregion Public Properties
    }
}