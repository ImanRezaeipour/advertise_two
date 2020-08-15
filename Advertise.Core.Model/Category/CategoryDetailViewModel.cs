using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Category
{

    public class CategoryDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public string Alias { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public CategoryOptionViewModel CategoryOption { get; set; }

        public CategoryType? CategoryType { get; set; }

        public CategoryViewModel Childs { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int CompanyCount { get; set; }

        /// <summary>
        ///     توضیحات دسته بندی
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int FollowerCount { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// فایل
        /// </summary>
        public string ImageFileName { get; set; }

        public bool InitFollow { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        ///     عنوان دسته بندی
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int VisitCount { get; set; }

        #endregion Public Properties
    }
}