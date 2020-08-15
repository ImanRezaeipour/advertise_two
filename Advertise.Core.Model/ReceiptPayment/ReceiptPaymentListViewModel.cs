using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ReceiptPayment
{

    public class ReceiptPaymentListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ReceiptPaymentViewModel> ReceiptPayments { get; set; }
        public ReceiptPaymentSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}