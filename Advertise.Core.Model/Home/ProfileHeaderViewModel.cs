using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Home
{
    public class ProfileHeaderViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// نام عکس کاربر
        /// </summary>
        public string AvatarFileName { get; set; }

        /// <summary>
        /// کد کمپانی کاربر
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// نام کمپانی
        /// </summary>
        public string CompanyTitle { get; set; }

        public Guid CreatedById { get; set; }

        /// <summary>
        /// نام نمایشی کاربر
        /// </summary>
        public string DisplayName { get; set; }

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
        /// آیدی کاربر
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// کد کاربر
        /// </summary>
        public string UserCode { get; set; }

        #endregion Public Properties
    }
}