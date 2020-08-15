using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Bag
{

    public class BagMyInfoViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        /// <summary>
        /// استان مربوط به آدرس
        /// </summary>
        [Required]
        public IEnumerable<SelectListItem> AddressProvince { get; set; }

        public Guid CityId { get; set; }

        /// <summary>
        /// آیدی کاربر
        /// </summary>
        public Guid CreatedById { get; set; }

        /// <summary>
        ///    شماره موبایل
        /// </summary>
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string MobileNumber { get; set; }

        /// <summary>
        ///    نوع پرداخت
        /// </summary>
        [Required]
        public PaymentType Payment { get; set; }

        /// <summary>
        ///    شماره تلفن ثابت
        /// </summary>
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///    کد پستی
        /// </summary>
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string PostalCode { get; set; }

        [Required]
        public Guid ProvinceId { get; set; }

        /// <summary>
        ///    نام شخص تحویل‌گیرنده
        /// </summary>
        public string TransfereeName { get; set; }

        /// <summary>
        ///    نشانی کامل بدون نام شهر و استان و کدپستی
        /// </summary>
        [Required]
        public string UserAddress { get; set; }

        /// <summary>
        ///    نام
        /// </summary>
        [Required]
        public string UserFirstName { get; set; }

        /// <summary>
        ///    نام خانوادگی
        /// </summary>
        [Required]
        public string UserLastName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string UserNationalCode { get; set; }

        #endregion Public Properties
    }
}