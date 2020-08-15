using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Receipts
{
    /// <summary>
    /// جدول ترکنش های مالی
    /// </summary>
    public class ReceiptPayment : BaseEntity
    {
        #region Properties

        /// <summary>
        /// كد درگاه پرداخت
        /// </summary>
        public string MerchantCode { get; set; }

        /// <summary>
        /// شناسه مرجع
        /// </summary>
        public string AuthorityCode { get; set; }

        /// <summary>
        /// شماره تراكنش خريد
        /// </summary>
        public long? ReferenceCode { get; set; }

        /// <summary>
        /// وضعيت
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PayType Pay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BuyType Buy { get; set; }

        /// <summary>
        /// آیا تراکنش به اتمام رسیده است
        /// </summary>
        public bool? IsComplete { get; set; }

        /// <summary>
        /// آیا تراکنش با موفقیت انجام شده
        /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// مبلغ ترکنش به تومان
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// توضيحات تراكنش
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// شماره تماس خريدار
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// ايميل خريدار
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// خریدار
        /// </summary>
        public virtual User PayedBy { get; set; }

        /// <summary>
        /// کلید خارجی خریدار
        /// </summary>
        public virtual Guid? PayedById { get; set; }

        /// <summary>
        /// جدول رسید خرید
        /// </summary>
        public virtual Receipt Receipt { get; set; }

        /// <summary>
        /// کلید خارجی جدول رسید خرید
        /// </summary>
        public virtual Guid? ReceiptId { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}