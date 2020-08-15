using System;
using System.Collections.Generic;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CompanyOfficial
{
    public class CompanyOfficialListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyOfficialViewModel> CompanyOfficials { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CompanyOfficialSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> StateList { get; set; }

        #endregion Public Properties
    }
}