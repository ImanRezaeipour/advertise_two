using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Manufacturers;
using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Catalogs
{

    public class Catalog : BaseEntity
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Description { get; set; }

        public virtual ICollection<CatalogFeature> Features { get; set; }

        public virtual ICollection<CatalogImage> Images { get; set; }

        public virtual ICollection<CatalogKeyword> Keywords { get; set; }

        public virtual ICollection<CatalogLike> Likes { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? ManufacturerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string MetaDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaTitle { get; set; }

        public virtual ICollection<CatalogReview> Reviews { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<CatalogSpecification> Specifications { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }


        /// <summary>
        ///
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ImageFileName { get; set; }

        #endregion Public Properties
    }
}