using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CategoryFollow
{

    public class CategoryFollowViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     نام مستعار و نمایشی برای آدرس بار
        /// </summary>
        public string CategoryAlias { get; set; }

        public int CategoryCompanyCount { get { return 47; } set { } }

        /// <summary>
        ///     عنوان دسته بندی
        /// </summary>
        public Guid CategoryId { get; set; }
        public Guid Id { get; set; }

        /// <summary>
        ///     مسیر(نام) عکس مربوط به دسته
        /// </summary>
        public string CategoryImageFileName { get; set; }

        /// <summary>
        ///     عنوان متا دسته بندی
        /// </summary>
        public string CategoryMetaTitle { get; set; }

        public int CategoryOrder { get; set; }

        public int CategoryProductCount { get { return 412; } set { } }

        /// <summary>
        ///     عنوان دسته بندی
        /// </summary>
        public string CategoryTitle { get; set; }

        public bool InitFollowCategory { get; set; }

        /// <summary>
        ///     کد معرف دسته بندی والد
        /// </summary>
        public string ParentCategoryAlias { get; set; }

        public string ParentCategoryImageFileName { get; set; }

        public string ParentCategoryMetaTitle { get; set; }

        /// <summary>
        ///     عنوان دسته بندی والد
        /// </summary>
        public string ParentCategoryTitle { get; set; }

        #endregion Public Properties
    }
}