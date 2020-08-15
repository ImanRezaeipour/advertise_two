using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CategoryReview
{

    public class CategoryReviewEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// متن نقد و بررسی
        /// </summary>
        ///
        //[AllowHtml]
        public string Body { get; set; }

        /// <summary>
        /// دسته
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// فعال
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}