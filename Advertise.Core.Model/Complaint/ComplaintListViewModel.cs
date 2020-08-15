using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Complaint
{
    public class ComplaintListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public IEnumerable<ComplaintViewModel> Complaints { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public ComplaintSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}