using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ActivityLog
{
    public class ActivityLogSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }

        #endregion Public Properties
    }
}