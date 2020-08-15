using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyReview
{

    public class CompanyReviewDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن بررسی
        /// </summary>
        public string Body { get; set; }

        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نمایش با عدم نمایش نفد و بررسی کمپانی
        /// </summary>
        public bool IsActive { get; set; }

        #endregion Public Properties
    }
}