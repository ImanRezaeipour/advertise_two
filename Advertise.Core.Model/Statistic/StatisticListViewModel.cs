using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Statistic
{
    public class StatisticListViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public StatisticSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<StatisticViewModel> Statistics { get; set; }

        #endregion Public Properties
    }
}