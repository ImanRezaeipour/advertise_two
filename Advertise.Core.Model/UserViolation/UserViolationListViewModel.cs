using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.UserViolation
{

    public class UserViolationListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public IEnumerable<SelectListItem> ProductList { get; set; }
        public IEnumerable<SelectListItem> ReadList { get; set; }
        public IEnumerable<SelectListItem> ReasonTypeList { get; set; }
        public IEnumerable<UserViolationViewModel> UserViolations { get; set; }
        public UserViolationSearchRequest SearchRequest { get; set; }

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