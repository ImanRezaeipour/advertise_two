using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyBalance
{
    public class CompanyBalanceListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyBalanceViewModel> CompanyBalances { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyBalanceSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}