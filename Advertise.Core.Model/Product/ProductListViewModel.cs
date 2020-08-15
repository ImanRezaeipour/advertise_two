using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Product
{
    public class ProductListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> CityList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductAll { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductApproved { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductPendeing { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductReject { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; set; }

        /// <summary>
        /// </summary>
        public ProductSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<SelectListItem> StateTypeList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}