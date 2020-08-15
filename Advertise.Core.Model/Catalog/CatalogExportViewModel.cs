using System;
using System.Collections.Generic;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Catalog
{
    public class CatalogExportViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Description { get; set; }

        public string FeatureTitle1 { get; set; }

        public string FeatureTitle2 { get; set; }

        public string FeatureTitle3 { get; set; }

        public string FeatureTitle4 { get; set; }

        public string FeatureTitle5 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ImageFileName1 { get; set; }

        public string ImageFileName2 { get; set; }

        public string ImageFileName3 { get; set; }

        public string ImageFileName4 { get; set; }

        public string ImageFileName5 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string KeywordId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid ManufacturerId { get; set; }

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
        public string ReviewBody { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<CatalogSpecificationViewModel> Specifications { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid CategoryId { get; set; }

        #endregion Public Properties
    }
}