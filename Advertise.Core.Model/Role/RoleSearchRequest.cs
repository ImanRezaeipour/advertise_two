using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Role
{
    public class RoleSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}