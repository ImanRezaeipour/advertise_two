using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Receipt
{
    public class ReceiptListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public IEnumerable<ReceiptViewModel> Receipts { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public ReceiptSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}