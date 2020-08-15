using System;
using System.Collections.Generic;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Receipt
{
    public class ReceiptCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        public IEnumerable<SelectListItem> AddressProvince { get; set; }

        public Guid CityId { get; set; }

        public Guid CreatedById { get; set; }

        /// <summary>
        ///     ایمیل خریدار
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     مبلغ پرداختی نهایی
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        ///     شماره فاکتور
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        ///     شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///     روش پرداخت
        /// </summary>
        public PaymentType Payment { get; set; }
        /// <summary>
        ///     شماره ثابت
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///    کد پستی
        /// </summary>
        public string PostalCode { get; set; }

        public Guid ProvinceId { get; set; }

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

        public string UserAddress { get; set; }

        /// <summary>
        ///     نام خریدار
        /// </summary>
        public string UserFirstName { get; set; }
        /// <summary>
        ///     نام خانوادگی خریدار
        /// </summary>
        public string UserLastName { get; set; }
        /// <summary>
        ///     کد ملی خریدار
        /// </summary>
        public string UserNationalCode { get; set; }

        #endregion Public Properties
    }
}