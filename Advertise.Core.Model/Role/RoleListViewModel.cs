using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Role
{
    public class RoleListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public RoleSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}