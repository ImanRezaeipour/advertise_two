using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.ReceiptPayment
{

    public class ReceiptPaymentCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     کدرهگیری که بانک میدهد
        /// </summary>
        public string ReferenceCode { get; set; }

        /// <summary>
        /// </summary>
        public long Value { get; set; }

        #endregion Public Properties
    }
}