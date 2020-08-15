using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyReview
{

    public class CompanyReviewEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن بررسی
        /// </summary>
        [Required]
        public string Body { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public string CompanyTitle { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نمایش با عدم نمایش نفد و بررسی کمپانی
        /// </summary>
        public bool IsActive { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]

        public string Title { get; set; }

        #endregion Public Properties
    }
}