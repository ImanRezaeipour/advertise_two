using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Roles;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Plans
{
    public class Plan : BaseEntity
    {
        #region Public Properties

        public virtual string Code { get; set; }

        public virtual int? DurationDay { get; set; }

        public virtual decimal? Price { get; set; }

        public virtual Role Role { get; set; }

        public virtual Guid? RoleId { get; set; }

        public virtual string Title { get; set; }
        public virtual decimal? PreviousePrice { get; set; }
        public virtual ColorType? Color { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual PlanDurationType? PlanDuration { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual Guid? CreatedById { get; set; }



        #endregion Public Properties
    }
}