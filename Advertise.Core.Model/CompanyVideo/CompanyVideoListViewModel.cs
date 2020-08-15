using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyVideo
{
    public class CompanyVideoListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CompanyList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyVideoViewModel> CompanyVideos { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyVideoSearchRequest SearchRequest { get; set; }

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

        public bool IsMyself { get; set; }

        #endregion Public Properties
    }
}