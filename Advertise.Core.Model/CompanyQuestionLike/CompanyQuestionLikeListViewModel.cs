using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyQuestionLike
{

    public class CompanyQuestionLikeListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<CompanyQuestionLikeViewModel> CompanyQuestionLikes { get; set; }
        public IEnumerable<SelectListItem> FollowList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyQuestionLikeSearchRequest SearchRequest { get; set; }

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