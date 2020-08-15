using Advertise.Core.Models.Common;
using System;
using Advertise.Core.Models.Address;

namespace Advertise.Core.Models.User
{

    public class UserDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// آدرس
        /// </summary>
        public AddressViewModel Address { get; set; }

        /// <summary>
        /// نام عکس کاربر
        /// </summary>
        public string AvatarFileName { get; set; }

        public string CompanyAlias { get; set; }

        /// <summary>
        /// شناسه کمپانی کاربر
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// نام کمپانی
        /// </summary>
        public string CompanyTitle { get; set; }

        public Guid CreatedById { get; set; }

        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// تعداد فالورها
        /// </summary>
        public string Followers { get; set; }

        /// <summary>
        /// نام کامل
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public string HomeNumber { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        #endregion Public Properties
    }
}