using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Specification
{

    public class SpecificationListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public SpecificationSearchRequest SearchRequest { get; set; }

        /// <summary>
        /// جهت
        /// </summary>
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SpecificationViewModel> Specifications { get; set; }

        #endregion Public Properties
    }
}