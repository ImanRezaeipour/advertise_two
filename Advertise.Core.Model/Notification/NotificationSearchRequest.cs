using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Notification
{
    public class NotificationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public virtual Guid? CreatedById { get; set; }
        public virtual string Title { get; set; }

        #endregion Public Properties
    }
}