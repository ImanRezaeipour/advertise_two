using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Company
{

    public class CompanyAboutViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     نام شرکت
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        ///     کد کمپانی
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     توضیحات مربوط به شرکت
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     آدرس ایمیل شرکت
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        public long EmployeeCount { get; set; }

        /// <summary>
        ///     سال تاسیس
        /// </summary>
        public DateTime EstablishedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     لوگوی شرکت
        /// </summary>
        public string LogoFileName { get; set; }

        /// <summary>
        ///     شماره همراه
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///     شماره تلفن(های) شرکت
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     آدرس وب سایت شرکت
        /// </summary>
        public string WebSite { get; set; }

        #endregion Public Properties
    }
}