using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Newsletter
{
    public class NewsletterCreateViewModel : BaseViewModel
    {
        #region Public Properties
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public MeetType Meet { get; set; }
        public IEnumerable<SelectListItem> MeetList { get; set; }

        #endregion Public Properties
    }
}