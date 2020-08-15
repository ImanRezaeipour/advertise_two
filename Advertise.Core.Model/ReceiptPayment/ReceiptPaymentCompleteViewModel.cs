using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.ReceiptPayment
{
    public class ReceiptPaymentCompleteViewModel : BaseViewModel
    {
        #region Public Properties

        public string Color { get; set; }
        public string InvoiceNumber { get; set; }
        public string Message { get; set; }

        #endregion Public Properties
    }
}