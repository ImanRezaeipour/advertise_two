using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.ProductReview
{

    public class ProductReviewEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن بررسی
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نمایش یا عدم نمایش نقد و بررسی
        /// </summary>
        public bool IsActive { get; set; }

        public string ProductTitle { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        #endregion Public Properties
    }
}