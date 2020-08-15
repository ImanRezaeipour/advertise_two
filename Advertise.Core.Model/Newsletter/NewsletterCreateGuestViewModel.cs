using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Newsletter
{
    public class NewsletterCreateGuestViewModel : BaseViewModel
    {
        #region Public Properties

        [Required]
        public string Email { get; set; }

        #endregion Public Properties
    }
}