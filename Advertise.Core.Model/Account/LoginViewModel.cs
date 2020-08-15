using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Account
{

    public class LoginViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 6)]

        public string Password { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 6)]

        public string UserName { get; set; }

        #endregion Public Properties
    }
}