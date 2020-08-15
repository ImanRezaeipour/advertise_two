using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Plan
{
    public class PlanListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public IEnumerable<PlanViewModel> Plans { get; set; }

        public PlanSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}