using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Receipts
{
    /// <summary>
    ///     نشان دهنده پیش فاکتور و فاکتور خرید
    /// </summary>
    public class Receipt : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     در صورت درست بودن به معنای خریداری کالا می‌باشد و در عیر اینصورت در حد پیش فاکتور باقی می‌ماند.
        /// </summary>
        public virtual bool? IsBuy { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        public virtual PaymentType? Payment { get; set; }

        /// <summary>
        ///     نام خریدار
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        ///     نام خانوادگی خریدار
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        ///     کد ملی خریدار
        /// </summary>
        public virtual string NationalCode { get; set; }

        /// <summary>
        ///     نام شخص تحویل‌گیرنده
        /// </summary>
        public virtual string TransfereeName { get; set; }

        /// <summary>
        ///     شماره موبایل
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        ///     شماره ثابت
        /// </summary>
        public virtual string HomeNumber { get; set; }

        /// <summary>
        ///     ایمیل خریدار
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///     قیمت کل اجناس خریداری شده
        /// </summary>
        public virtual decimal? TotalProductsPrice { get; set; }

        /// <summary>
        ///     هزینه ارسال و حمل و نقل
        /// </summary>
        public virtual decimal? TransportationCost { get; set; }

        /// <summary>
        ///     مبلغ پرداختی نهایی
        /// </summary>
        public virtual decimal? FinalPrice { get; set; }


        /// <summary>
        ///     تاریخ و زمان پرداخت نهایی فاکتور
        /// </summary>
        public virtual DateTime? ConfirmedOn { get; set; }

        /// <summary>
        ///     کد رهگیری
        /// </summary>
        public virtual string TrackingCode { get; set; }

        /// <summary>
        ///     شماره فاکتور
        /// </summary>
        public virtual string InvoiceNumber { get; set; }

        #endregion

        #region NavigationProperties

  /// <summary>
        ///     آدرس خریدار
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? AddressId { get; set; }

        /// <summary>
        ///     جزئیات کالا(ها)ی خریداری شده
        /// </summary>
        public virtual ICollection<ReceiptOption> Options { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}