using Advertise.Core.Models.Common;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Receipt
{

    public class ReceiptEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     تاریخ و زمان پرداخت نهایی فاکتور
        /// </summary>
        public DateTime ConfirmedOn { get; set; }

        /// <summary>
        ///     ایمیل خریدار
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     مبلغ پرداختی نهایی
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        ///     نام خریدار
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     شماره ثابت
        /// </summary>
        public string HomeNumber { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        ///     شماره فاکتور
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        ///     نام خانوادگی خریدار
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     کد ملی خریدار
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        public PaymentType Payment { get; set; }

        /// <summary>
        ///     شماره موبایل
        /// </summary>
        public string PhoneNumber { get; set; }

        public IEnumerable<ReceiptOptionCreateViewModel> ReceiptOptions { get; set; }

        /// <summary>
        ///     قیمت کل اجناس خریداری شده
        /// </summary>
        public decimal TotalProductsPrice { get; set; }

        /// <summary>
        ///     کد رهگیری
        /// </summary>
        public string TrackingCode { get; set; }

        /// <summary>
        ///     نام شخص تحویل‌گیرنده
        /// </summary>
        public string TransfereeName { get; set; }

        /// <summary>
        ///     هزینه ارسال و حمل و نقل
        /// </summary>
        public decimal TransportationCost { get; set; }

        #endregion Public Properties
    }
}