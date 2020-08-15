using System;

namespace Advertise.Core.Models.Account
{

    public class ResetPasswordViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        ///// <summary>
        /////
        ///// </summary>
        public string Email { get; set; }

        ///// <summary>
        /////
        ///// </summary>
        public string Password { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}