using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Company
{
    public class CompanyListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyViewModel> Companies { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanySearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }

        #endregion Public Properties
    }
}