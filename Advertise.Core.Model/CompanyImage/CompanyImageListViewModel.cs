using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyImage
{

    public class CompanyImageListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyImageViewModel> CompanyImages { get; set; }

        public IEnumerable<SelectListItem> CompanyList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyImageSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}