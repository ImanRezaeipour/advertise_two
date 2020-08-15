using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ReceiptPayment
{

    public class ReceiptPaymentViewModel : BaseViewModel
    {
        #region Public Properties

        public int? Amount { get; set; }

        public BuyType Buy { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsSuccess { get; set; }

        public string MobileNumber { get; set; }

        public PayType Pay { get; set; }

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