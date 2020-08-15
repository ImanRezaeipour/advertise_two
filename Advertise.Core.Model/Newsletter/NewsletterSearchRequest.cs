using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Newsletter
{
    public class NewsletterSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? Email { get; set; }
        public MeetType? Meet { get; set; }

        #endregion Public Properties
    }
}