using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Categories
{
    /// <summary>
    ///     این دامین جهت ایجاد تمایز میان دسته‌بندی‌های مختلف و نیز قابل فهم شدن صفحات سایت برای مخاطبان ایجاد شده است.
    /// </summary>
    public class CategoryOption : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     عنوان آپشن
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «محصولات» می‌شود
        /// </summary>
        public virtual string Products { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «شرح محصول» می‌شود
        /// </summary>
        public virtual string ProductDescription { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «مدیریت محصولات» می‌شود
        /// </summary>
        public virtual string ProductsManagement { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «کمپانی‌ها» می‌شود
        /// </summary>
        public virtual string Companies { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «اطلاعات کمپانی» می‌شود
        /// </summary>
        public virtual string CompanyInfo { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «مدیریت کمپانی» می‌شود
        /// </summary>
        public virtual string CompanyManagement { get; set; }

        /// <summary>
        ///     عبارت کلیدی در ریسورس که در هر زبان جایگزین عبارت «کمپانی من» می‌شود
        /// </summary>
        public virtual string MyCompany { get; set; }

        /// <summary>
        ///     نشان می‌دهد آیا محصولات کمپانی‌های این دسته‌بندی قابل قیمت‌گذاری هستند یا خیر
        /// </summary>
        public virtual bool? HasPrice { get; set; }

        /// <summary>
        ///     بسته به نوع دسته‌بندی، عکس پترن تکرار شونده صفحه جزئیات محصول، کمپانی و خود آن دسته‌بندی را تعیین می‌کند
        /// </summary>
        public virtual string BackgroundFileName { get; set; }



        #endregion

        #region NavigationProperties


        /// <summary>
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }

        #endregion
    }
}