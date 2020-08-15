using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Receipt
{

    public class ReceiptPreviewViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        public Guid CreatedById { get; set; }

        public string CurrentDate { get; set; }

        /// <summary>
        ///     میزان تخفیف حاصل از اعمال کد تخفیف
        /// </summary>
        public decimal DiscountCodePrice { get; set; }

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
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        ///     شماره ثابت
        /// </summary>
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        [Required]
        public string HomeNumber { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     شماره فاکتور
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        ///     نام خانوادگی خریدار
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        ///     کد ملی خریدار
        /// </summary>
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        [Required]
        public string NationalCode { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        [Required]
        public PaymentType Payment { get; set; }

        /// <summary>
        ///     شماره موبایل
        /// </summary>
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        [Required]
        public string PhoneNumber { get; set; }

        public string ProvinceName { get; set; }
        public IEnumerable<ReceiptOptionViewModel> ReceiptOptions { get; set; }

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