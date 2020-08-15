using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductFeature;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Models.Tag;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Product
{
    public class ProductCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? CreatedById { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public IEnumerable<ProductFeatureCreateViewModel> Features { get; set; }
        public string ImageFileName { get; set; }
        public IEnumerable<ProductImageCreateViewModel> Images { get; set; }
        public IEnumerable<SelectListItem> KeywordList { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public decimal? PreviousPrice { get; set; }
        public decimal? Price { get; set; }
        public IEnumerable<string> ProductKeywords { get; set; }
        public IEnumerable<ProductTagCreateViewModel> ProductTags { get; set; }
        public SellType? Sell { get; set; }
        public IEnumerable<SelectListItem> SellTypeList { get; set; }
        public IList<ProductSpecificationCreateViewModel> Specifications { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}