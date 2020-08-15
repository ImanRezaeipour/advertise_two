using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductReview
{

    public class ProductReviewSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public bool? IsActive { get; set; }

        public string ProductCode { get; set; }
        public Guid? ProductId { get; set; }
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}