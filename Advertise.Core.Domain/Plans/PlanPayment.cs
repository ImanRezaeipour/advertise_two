using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Plans
{
    public class PlanPayment : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// مبلغ ترکنش به تومان
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// شناسه مرجع
        /// </summary>
        public string AuthorityCode { get; set; }

        /// <summary>
        /// توضيحات تراكنش
        /// </summary>
        public string Description { get; set; }

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

        /// <summary>
        /// شماره تراكنش خريد
        /// </summary>
        public long? ReferenceCode { get; set; }

        /// <summary>
        /// وضعيت
        /// </summary>
        public int? StatusCode { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Guid? PlanId { get; set; }

        public virtual PlanDiscount PlanDiscount { get; set; }
        public virtual Guid? PlanDiscountId { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}