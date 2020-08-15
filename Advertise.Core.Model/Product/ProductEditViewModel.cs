using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductFeature;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Models.Tag;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Product
{

    public class ProductEditViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// توضیح کامل
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// انتخاب دسته
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// </summary>
        public string CategoryTitle { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public Guid CreatedById { get; set; }

        /// <summary>
        /// توضیح کوتاه
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductFeatureCreateViewModel> Features { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductImageCreateViewModel> Images { get; set; }

        /// <summary>
        /// لیست تمام کلمات کلیدی
        /// </summary>
        public IEnumerable<SelectListItem> KeywordList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal PreviousPrice { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// لیست تمام کلمات کلیدی محصول در حال حاضر
        /// </summary>
        public IEnumerable<Guid?> ProductKeywordList { get; set; }

        /// <summary>
        /// لیست تمام کلمات کلیدی - ارسالی
        /// </summary>
        public IEnumerable<string> ProductKeywords { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<ProductTagCreateViewModel> ProductTags { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SellType Sell { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> SellTypeList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductSpecificationEditViewModel> Specifications { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<TagViewModel> Tags { get; set; }

        /// <summary>
        /// </summary>
        [StringLength(30, MinimumLength = 2)]
        public string Title { get; set; }

        #endregion Public Properties

    }
}