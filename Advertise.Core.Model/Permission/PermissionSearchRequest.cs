using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Permission
{
    public class PermissionSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public bool? IsCallback { get; set; }

        #endregion Public Properties
    }
}