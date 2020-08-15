using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductReview
{

    public class ProductReviewViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نمایش یا عدم نمایش نقد و بررسی
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductImageFileName { get; set; }

        public string ProductTitle { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}