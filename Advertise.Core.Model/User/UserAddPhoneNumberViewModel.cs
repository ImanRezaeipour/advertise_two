using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.User
{
    public class UserAddPhoneNumberViewModel
    {
        #region Public Properties

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string Number { get; set; }

        #endregion Public Properties
    }
}