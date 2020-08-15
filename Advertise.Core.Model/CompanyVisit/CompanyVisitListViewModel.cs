using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyVisit
{
    public class CompanyVisitListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<CompanyVisitViewModel> CompanyVisits { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyVisitSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        #endregion Public Properties
    }
}