using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Newsletters
{
   public class Newsletter :BaseEntity
    {
        public virtual string Email { get; set; }

        public virtual MeetType? Meet { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

    }
}
