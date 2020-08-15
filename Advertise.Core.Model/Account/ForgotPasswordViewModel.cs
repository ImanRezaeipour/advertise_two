using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Account
{

    public class ForgotPasswordViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        #endregion Public Properties
    }
}