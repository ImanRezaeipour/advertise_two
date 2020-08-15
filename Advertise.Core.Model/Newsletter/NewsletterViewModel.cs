using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Newsletter
{
    public class NewsletterViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }
        public Guid Id { get; set; }
        public MeetType Meet { get; set; }

        #endregion Public Properties
    }
}