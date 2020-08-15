using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.ProductReview
{

    public class ProductReviewCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن بررسی
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     نمایش یا عدم نمایش نقد و بررسی
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>

        public Guid ProductId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> ProductList { get; set; }

        #endregion Public Properties
    }
}