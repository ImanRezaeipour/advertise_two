using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.UserOnline
{
    public class UserOnlineSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        public bool? IsActive { get; set; }

        #endregion Public Properties
    }
}