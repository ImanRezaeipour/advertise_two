using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyAttachment
{

    public class CompanyAttachmentListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanyAttachmentViewModel> CompanyAttachments { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> CompanyList { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyAttachmentSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> UserList { get; set; }

        public bool IsMyself { get; set; }

        #endregion Public Properties
    }
}