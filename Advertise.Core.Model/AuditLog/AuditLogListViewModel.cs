using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.AuditLog
{
    public class AuditLogListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<AuditLogViewModel> AuditLogs { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public AuditLogSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}