using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Models.ProductTag;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.CategoryOption;

namespace Advertise.Core.Models.Product
{

    public class ProductViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public AddressViewModel Address { get; set; }

        public string CatAlias { get; set; }

        /// <summary>
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// </summary>
        public string CategoryTitle { get; set; }

        public string CatMetaTitle { get; set; }

        public string Code { get; set; }

        public string CompanyAlias { get; set; }

        /// <summary>
        /// </summary>
        ///
        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyLogoFileName { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyTitle { get; set; }

        public Guid CreatedById { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        public decimal? DiscountPercent { get; set; }

        /// <summary>
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductImageViewModel> Images { get; set; }
      
        public bool IsExist { get; set; }

        /// <summary>
        /// </summary>
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// </summary>
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string PhoneNumber { get; set; }
         

        public decimal? PreviousPrice { get; set; }

        /// <summary>
        /// </summary>
        public decimal? Price { get; set; }

        /// توضیح برای عدم تائید
        public string RejectDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SellType Sell { get; set; }

        /// <summary>
        /// </summary>
        public StateType State { get; set; }

        public int TagCount { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductTagViewModel> Tags { get; set; }

        public string TagTitle { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsCatalog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? CatalogId { get; set; }

        public Guid? ManufacturerId { get; set; }

        public decimal? HighestPrice { get; set; }

        public decimal? LowestPrice { get; set; }

        public int CatalogCompanyCount { get; set; }
        public string GuaranteeTitle { get; set; }

        #endregion Public Properties
    }
}