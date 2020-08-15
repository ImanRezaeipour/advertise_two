using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Email
{
    public class EmailListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<EmailViewModel> Emails { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public EmailSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}