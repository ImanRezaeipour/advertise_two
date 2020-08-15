using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Notification
{
    public class NotificationListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<NotificationViewModel> Notifications { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public NotificationSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}