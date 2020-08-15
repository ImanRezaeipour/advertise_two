using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.User
{
    public class UserListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> GenderList { get; set; }

        public IEnumerable<SelectListItem> IsActiveList { get; set; }

        public IEnumerable<SelectListItem> IsBanList { get; set; }

        public IEnumerable<SelectListItem> IsVerifyList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public UserSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<UserViewModel> UserList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<UserViewModel> Users { get; set; }

        #endregion Public Properties
    }
}