using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductCommentLike
{
    public class ProductCommentLikeSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CommentId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Guid? LikedById { get; set; }
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}