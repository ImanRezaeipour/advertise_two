using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Sms
{
    public class SmsListViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public SmsSearchRequest SearchRequest { get; set; }
        public IEnumerable<SmsViewModel> Smses { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}