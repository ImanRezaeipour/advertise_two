using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyFollow
{

    public class CompanyFollowListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<CompanyFollowViewModel> CompanyFollows { get; set; }
        public IEnumerable<SelectListItem> FollowList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyFollowSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}