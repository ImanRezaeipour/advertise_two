using System;

namespace Advertise.Core.Models.User
{
    public class UserVerifyPhoneNumberViewModel
    {
        #region Public Properties

        public string Code { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}