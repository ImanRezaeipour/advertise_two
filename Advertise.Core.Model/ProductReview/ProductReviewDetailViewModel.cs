using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductReview
{
    public class ProductReviewDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        #endregion Public Properties
    }
}