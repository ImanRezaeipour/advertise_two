using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Category
{

    public class CategoryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     نام مستعار و نمایشی برای آدرس بار
        /// </summary>
        public string Alias { get; set; }

        public CategoryOptionViewModel CategoryOption { get; set; }

        /// <summary>
        ///     کد معرف دسته بندی
        /// </summary>
        public string Code { get; set; }

        public int CompanyCount { get; set; }

        /// <summary>
        ///     توضیحات دسته بندی
        /// </summary>
        public string Description { get; set; }

        public bool? HasChild { get; set; }

        public string Icon { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     مسیر(نام) عکس مربوط به دسته
        /// </summary>
        public string ImageFileName { get; set; }

        public bool InitFollow { get; set; }

        /// <summary>
        ///     نمایش یا عدم نمایش دسته
        /// </summary>
        public bool? IsActive { get; set; }

        public string MetaTitle { get; set; }

        public int Order { get; set; }

        /// <summary>
        ///     عنوان دسته بندی والد
        /// </summary>
        public string ParentAlias { get; set; }

        /// <summary>
        ///     کد معرف دسته بندی والد
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// </summary>
        public Guid? ParentId { get; set; }

        public string ParentImageFileName { get; set; }

        /// <summary>
        ///     عنوان دسته بندی والد
        /// </summary>
        public string ParentMetaTitle { get; set; }

        /// <summary>
        ///     عنوان دسته بندی والد
        /// </summary>
        public string ParentTitle { get; set; }

        public int ProductCount { get; set; }

        /// <summary>
        ///     عنوان دسته بندی
        /// </summary>
        public string Title { get; set; }

        public CategoryType? Type { get; set; }

        #endregion Public Properties
    }
}