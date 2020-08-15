using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Bag
{

    public class BagUpdateMyInfoViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        /// <summary>
        ///    شهر مربوط به آدرس
        /// </summary>
        public string AddressCity { get; set; }

        /// <summary>
        ///    استان مربوط به آدرس
        /// </summary>
        public string AddressProvince { get; set; }

        public Guid CityId { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid CreatedById { get; set; }

        /// <summary>
        ///    نشانی ایمیل
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        ///    شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///    نوع پرداخت
        /// </summary>
        public PaymentType Payment { get; set; }

        /// <summary>
        ///    شماره تلفن ثابت
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///    کد پستی
        /// </summary>
        public string PostalCode { get; set; }

        public Guid ProvinceId { get; set; }

        /// <summary>
        /// آیدی سبد خرید
        /// </summary>
        public Guid ReceiptId { get; set; }

        /// <summary>
        ///    نام شخص تحویل‌گیرنده
        /// </summary>
        public string TransfereeName { get; set; }

        /// <summary>
        ///    نشانی کامل بدون نام شهر و استان و کدپستی
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        ///    نام
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        ///    نام خانوادگی
        /// </summary>
        public string UserLastName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserNationalCode { get; set; }

        #endregion Public Properties
    }
}