using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.ReceiptPayment
{

    public class ReceiptPaymentCallbackViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        ///     کدرهگیری که بانک میدهد
        /// </summary>
        public string Status { get; set; }

        #endregion Public Properties
    }
}