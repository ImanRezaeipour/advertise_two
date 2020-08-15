using System;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Common
{
    public class BaseSlidePayment : BaseEntity
    {
        /// <summary>
        ///     کد پیگیری پرداخت
        /// </summary>
        public virtual long? ReferenceCode { get; set; }

        /// <summary>
        ///     مبلغ پرداختی
        /// </summary>
        public virtual decimal? Amount { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        public virtual PaymentType? Type { get; set; }

        /// <summary>
        /// شناسه مرجع
        /// </summary>
        public virtual string AuthorityCode { get; set; }

        /// <summary>
        /// توضيحات تراكنش
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// آیا تراکنش به اتمام رسیده است
        /// </summary>
        public virtual bool? IsComplete { get; set; }

        /// <summary>
        /// آیا تراکنش با موفقیت انجام شده
        /// </summary>
        public virtual bool? IsSuccess { get; set; }

        /// <summary>
        /// كد درگاه پرداخت
        /// </summary>
        public virtual string MerchantCode { get; set; }

        /// <summary>
        /// وضعيت
        /// </summary>
        public virtual int? StatusCode { get; set; }


    }
}
