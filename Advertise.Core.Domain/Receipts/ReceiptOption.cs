using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Receipts
{
    /// <summary>
    ///     نشان جزئیات هر یک از کالاهای خریداری شده
    /// </summary>
    public class ReceiptOption : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     عنوان محصول
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     کد محصول
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     قیمت واحد هر کالا
        /// </summary>
        public virtual decimal? Price { get; set; }

        /// <summary>
        ///     تعداد هر کالا
        /// </summary>
        public virtual decimal? Count { get; set; }

        /// <summary>
        ///     قیمت کل به ازای هر کالا
        /// </summary>
        public virtual decimal? TotalPrice { get; set; }

        /// <summary>
        ///     قیمت واحد هرکالا پیش از خرید
        /// </summary>
        public virtual decimal? PreviousPrice { get; set; }

        /// <summary>
        ///     میزان درصد تخفیف به ازای هر کالا
        /// </summary>
        public virtual decimal? DiscountPercent { get; set; }

        /// <summary>
        ///     عنوان فروشگاه
        /// </summary>
        public virtual string CompanyTitle { get; set; }

        /// <summary>
        ///     کد فروشگاه
        /// </summary>
        public virtual string CompanyCode { get; set; }

        /// <summary>
        ///     عنوان دسته‌بندی کالا
        /// </summary>
        public virtual string CategoryTitle { get; set; }

        /// <summary>
        ///     کد دسته‌بندی کالا
        /// </summary>
        public virtual string CategoryCode { get; set; }

        public virtual Guid? SaledById { get; set; }
        
        #endregion

        #region NavigationProperties

        /// <summary>
        ///     
        /// </summary>
        public virtual Receipt Receipt { get; set; }

        /// <summary>
        ///     آیدی فاکتور خرید
        /// </summary>
        public virtual Guid? ReceiptId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}