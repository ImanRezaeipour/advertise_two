using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.User
{
    public class UserChangePasswordViewModel
    {
        #region Public Properties

        [Required]
        public string ConfirmPassword { get; set; }

        public Guid Id { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string OldPassword { get; set; }

        #endregion Public Properties
    }
}