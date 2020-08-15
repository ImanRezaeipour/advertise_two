using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CategoryReview
{

    public class CategoryReviewDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن نقد و بررسی
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// دسته
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}