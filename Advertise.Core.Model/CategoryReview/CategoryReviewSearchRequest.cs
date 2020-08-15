using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CategoryReview
{

    public class CategoryReviewSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CategoryId { get; set; }
        public Guid? CreatedById { get; set; }
        public bool? IsActive { get; set; }

        #endregion Public Properties
    }
}