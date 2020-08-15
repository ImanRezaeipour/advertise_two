﻿using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Bags;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Guarantees;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Manufacturers;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Products
{
    public class Product : BaseEntity, ICloneable
    {
        #region Properties

        public virtual string Code { get; set; }

        public virtual string Title { get; set; }

        public virtual bool? IsSecondHand { get; set; }

        public virtual string SecondHandCode { get; set; }

        public virtual decimal? Price { get; set; }

        public virtual string Description { get; set; }

        public virtual string Body { get; set; }

        public virtual string MobileNumber { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Email { get; set; }

        public virtual bool? IsAllowComment { get; set; }

        public virtual bool? IsAllowCommentForAnonymous { get; set; }

        public virtual bool? IsEnableForShare { get; set; }

        public virtual StateType? State { get; set; }

        public virtual SellType? Sell { get; set; }

        public virtual string RejectDescription { get; set; }

        public virtual string MetaTitle { get; set; }

        public virtual string MetaKeywords { get; set; }

        public virtual string MetaDescription { get; set; }

        public virtual string ImageFileName { get; set; }

        public virtual decimal? DiscountPercent { get; set; }

        public virtual decimal? PreviousPrice { get; set; }

        public virtual bool? IsCatalog { get; set; }

        public virtual ColorType? Color { get; set; }

        public virtual int? AvailableCount { get; set; }

        #endregion

        #region NavigationProperties

        public virtual User ApprovedBy { get; set; }

        public virtual Guid? ApprovedById { get; set; }

        public virtual DateTime? ModifiedOn { get; set; }

        public virtual Address Address { get; set; }

        public virtual Guid? AddressId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Guid? CategoryId { get; set; }

        public virtual Company Company { get; set; }

        public virtual Guid? CompanyId { get; set; }

        public virtual ICollection<ProductComment> Comments { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }

        public virtual ICollection<ProductLike> Likes { get; set; }

        public virtual ICollection<ProductSpecification> Specifications { get; set; }

        public virtual ICollection<ProductFeature> Features { get; set; }

        public virtual ICollection<ProductTag> Tags { get; set; }

        public virtual ICollection<ProductReview> Reviews { get; set; }

        public virtual ICollection<ProductVisit> Visits { get; set; }

        public virtual ICollection<Bag> Bags { get; set; }

        public virtual ICollection<ProductKeyword> ProductKeywords { get; set; }

        public virtual ICollection<CompanySlide> CompanySlides { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual Guid? CreatedById { get; set; }

        public virtual Catalog Catalog { get; set; }

        public virtual Guid? CatalogId { get; set; }

        public virtual Guarantee Guarantee { get; set; }

        public virtual Guid? GuaranteeId { get; set; }

        public virtual string GuaranteeTitle { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Guid? ManufacturerId { get; set; }

        #endregion

        public object Clone()
        {
            return (Product)this.MemberwiseClone();
        }
    }
}