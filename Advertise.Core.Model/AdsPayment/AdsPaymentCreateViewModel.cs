using System;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.AdsPayment
{

    public class AdsPaymentCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     مبلغ پرداختی
        /// </summary>
        public decimal? Amount { get; set; }

        public string Callbak { get; set; }

        public Guid? AdsId { get; set; }

        public PayType Pay { get; set; }


        /// <summary>
        ///     کد پیگیری پرداخت
        /// </summary>
        public string ReferenceCode { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        public PaymentType? Type { get; set; }

        #endregion Public Properties
    }
}