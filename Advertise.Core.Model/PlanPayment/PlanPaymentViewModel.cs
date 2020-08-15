using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.PlanPayment
{
    public class PlanPaymentViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// مبلغ ترکنش به تومان
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// شناسه مرجع
        /// </summary>
        public string AuthorityCode { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// توضيحات تراكنش
        /// </summary>
        public string Description { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        /// آیا تراکنش به اتمام رسیده است
        /// </summary>
        public bool? IsComplete { get; set; }

        /// <summary>
        /// آیا تراکنش با موفقیت انجام شده
        /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// كد درگاه پرداخت
        /// </summary>
        public string MerchantCode { get; set; }

        public Guid? PlanId { get; set; }

        public string PlanTitle { get; set; }

        /// <summary>
        /// شماره تراكنش خريد
        /// </summary>
        public long? ReferenceCode { get; set; }

        /// <summary>
        /// وضعيت
        /// </summary>
        public int? StatusCode { get; set; }

        #endregion Public Properties
    }
}