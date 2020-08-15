using Advertise.Core.Models.Common;
using System.Collections.Generic;
using SelectListItem = Advertise.Core.Models.Common.SelectListItem;

namespace Advertise.Core.Models.UserOperator
{
    public class UserOperatorListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public UserOperatorSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<UserOperatorViewModel> UserOperators { get; set; }

        #endregion Public Properties
    }
}