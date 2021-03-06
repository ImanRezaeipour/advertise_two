using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Permission
{
    public class PermissionListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<PermissionViewModel> Permissions { get; set; }
        public PermissionSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}