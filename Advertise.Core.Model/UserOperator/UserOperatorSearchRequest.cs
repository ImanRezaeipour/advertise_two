using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.UserOperator
{

    public class UserOperatorSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBan { get; set; }
        public bool? IsVerify { get; set; }
        public Guid? RoleId { get; set; }

        #endregion Public Properties
    }
}