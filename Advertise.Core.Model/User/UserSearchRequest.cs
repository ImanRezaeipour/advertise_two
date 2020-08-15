using Advertise.Core.Models.Common;
using System;
using System.Linq.Expressions;

namespace Advertise.Core.Models.User
{

    public class UserSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBan { get; set; }
        public bool? IsVerify { get; set; }
        public Guid? RoleId { get; set; }

       // public Expression<Func<Domains.Users.User, string>> GroupBy { get; set; }

        #endregion Public Properties
    }
}