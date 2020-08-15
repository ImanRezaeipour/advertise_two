using System;
using System.Collections.Generic;
using Advertise.Core.Models.CatalogFeature;
using Advertise.Core.Models.CatalogImage;
using Advertise.Core.Models.CatalogKeyword;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Catalog
{
    public class CatalogCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ManufacturerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CatalogSpecificationViewModel> Specifications { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CatalogFeatureViewModel> Features { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> KeywordList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> CatalogKeywords { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CatalogImageViewModel> Images { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageFileName { get; set; }

        #endregion Public Properties
    }
}