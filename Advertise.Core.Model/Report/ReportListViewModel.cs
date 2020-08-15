using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Report
{
    public class ReportListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ReportViewModel> Reports { get; set; }
        public ReportSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}