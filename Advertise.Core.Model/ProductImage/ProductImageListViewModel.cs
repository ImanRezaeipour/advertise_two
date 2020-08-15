using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductImage
{

    public class ProductImageListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ProductImageViewModel> ProductImages { get; set; }
        public ProductImageSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}