using Advertise.Core.Models.Common;
using System;
using System.Web.Mvc;

namespace Advertise.Core.Models.CategoryReview
{

    public class CategoryReviewCreateViewModel : BaseViewModel
    {
        #region Public Properties

        [AllowHtml]
        public string Body { get; set; }

        public Guid CategoryId { get; set; }

        public bool IsActive { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}