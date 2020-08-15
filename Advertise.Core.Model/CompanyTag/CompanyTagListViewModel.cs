using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyTag
{

    public class CompanyTagListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public IEnumerable<CompanyTagViewModel> CompanyTags { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyTagSearchRequest SearchRequest { get; set; }

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