using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductComment;
using Advertise.Core.Models.ProductFeature;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Product
{

    public class ProductDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string BrandName { get; set; }

        public string CategoryAlias { get; set; }

        /// <summary>
        /// </summary>
        public Guid CategoryId { get; set; }

        public CategoryOptionViewModel CategoryOption { get; set; }

        /// <summary>
        /// </summary>
        public string CategoryTitle { get; set; }

        public string CompanyAlias { get; set; }

        public string CompanyCode { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyDescription { get; set; }

        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyLogoFileName { get; set; }

        /// <summary>
        /// </summary>
        public string CompanySlogan { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyTitle { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        public double CurrentUserRate { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public decimal? DiscountPercent { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductFeatureViewModel> Features { get; set; }

        public bool HaveDiscount { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public int ImageCount { get; set; }

        /// <summary>
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductImageViewModel> Images { get; set; }

        public bool InitLike { get; set; }

        public bool InitNotify { get; set; }

        public bool IsExist { get; set; }

        /// <summary>
        /// </summary>
        public int LikeCount { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// </summary>
        public decimal? PreviousPrice { get; set; }

        /// <summary>
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ProductCommentListViewModel ProductCommentList { get; set; }

        /// <summary>
        /// </summary>
        public string ProductFeatures { get; set; }

        public IEnumerable<ProductSpecificationViewModel> ProductSpecifications { get; set; }

        public decimal RateNumber { get; set; }

        public int RateUsers { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SellType Sell { get; set; }

        /// <summary>
        /// </summary>
        public int TagCount { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductTagViewModel> Tags { get; set; }

        public string TagTitle { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public int VisitCount { get; set; }

        public Guid? ManufacturerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsCatalog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? CatalogId { get; set; }

        public IList<CatalogDetailViewModel> CatalogProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GuaranteeTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColorType Color { get; set; }

        public decimal? HighestPrice { get; set; }

        public decimal? LowestPrice { get; set; }

        public int CatalogCompanyCount { get; set; }

        #endregion Public Properties
    }
}