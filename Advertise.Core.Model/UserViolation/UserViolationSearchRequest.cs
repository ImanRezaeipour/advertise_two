using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.UserViolation
{

    public class UserViolationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public bool? IsRead { get; set; }
        public ReasonType? ReasonType { get; set; }

        public ReportType? ReportType { get; set; }

        #endregion Public Properties
    }
}