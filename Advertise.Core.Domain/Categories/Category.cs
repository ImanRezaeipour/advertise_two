using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Adses;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Categories
{
    /// <summary>
    ///     نشان دهنده دسته بندی محصولات
    /// </summary>
    public class Category : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     کد دسته بندی
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// اسم مستعار برای دسته بندی
        /// </summary>
        public virtual string Alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Order { get; set; }
        /// <summary>
        ///     عنوان دسته بندی
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     توضیحات دسته بندی
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// </summary>
        public virtual string ImageFileName { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? HasChild { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        public virtual CategoryType? Type { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaTitle { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? Level { get; set; }



        #endregion

        #region NavigationProperties

        /// <summary>
        ///     والد دسته بندی
        /// </summary>
        public virtual Category Parent { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        ///     نوع دسته‌بندی
        /// </summary>
        public virtual CategoryOption CategoryOption { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CategoryOptionId { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<Category> Childrens { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<Company> Companies { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CategoryFollow> Follows { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CategoryReview> Reviews { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<Ads> Ads { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }



        #endregion
    }
}