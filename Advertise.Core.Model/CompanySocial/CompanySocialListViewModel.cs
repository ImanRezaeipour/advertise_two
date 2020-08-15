using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanySocial
{
    public class CompanySocialListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<CompanySocialViewModel> CompanySocials { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanySocialSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}