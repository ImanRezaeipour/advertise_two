using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Users
{
    public class UserOnline : BaseEntity
    {
        #region Public Properties

        public virtual string SessionId { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}