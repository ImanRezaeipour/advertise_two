using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.User
{

    public class UserViewModel : BaseViewModel
    {
        #region Public Properties

        public string AvatarFileName { get; set; }

        public string CompanyAlias { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string CompanyTitle { get; set; }

        /// <summary>
        ///     نام /نام خانوادگی
        /// </summary>
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        /// <summary>
        ///     آی دی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     قفل شده؟
        /// </summary>
        public bool? IsBan { get; set; }

        public bool? IsSetUserName { get; set; }

        /// <summary>
        ///     اکانت سیستمی است؟
        /// </summary>
        public bool? IsSystemAccount { get; set; }

        public string Role { get; set; }

        /// <summary>
        ///     نام کاربری
        /// </summary>
        public string UserName { get; set; }

        #endregion Public Properties
    }
}