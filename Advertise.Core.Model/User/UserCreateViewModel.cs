using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.User
{

    public class UserCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CreatedById { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     نام کاربر
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     نام خانوادگی کاربر
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     کلمه عبور
        /// </summary>
        public string Password { get; set; }

        #endregion Public Properties
    }
}