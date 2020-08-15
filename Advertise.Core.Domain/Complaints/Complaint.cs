using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Complaints
{
    public class Complaint : BaseEntity
    {
        #region Public Properties

        public virtual string Body { get; set; }
        public virtual string Title { get; set; }

        #endregion Public Properties


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }
    }
}