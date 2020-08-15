using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using Advertise.Core.Models.CatalogImage;

namespace Advertise.Core.Models.Product
{

    public class CatalogDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyAlias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyTitle { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string CompanyLogoFileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProductModifiedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? ManufacturerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SellType ProductSell { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ColorType ProductColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductGuaranteeTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? ProductPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ProductIsExist { get; set; }

        #endregion Public Properties
    }
}