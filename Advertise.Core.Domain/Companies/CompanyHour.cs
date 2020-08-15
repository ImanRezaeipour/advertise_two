using Advertise.Core.Domains.Common;
using Advertise.Core.Types;
using System;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    public class CompanyHour : BaseEntity
    {
        #region Public Properties

        public virtual DayType? DayOfWeek { get; set; }
        public virtual TimeSpan? EndedOn { get; set; }
        public virtual TimeSpan? StartedOn { get; set; }
        public virtual bool? IsActive { get; set; }
     
        #endregion Public Properties


        #region NavigationProperties
        public virtual Company Company { get; set; }
        public virtual Guid? CompanyId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion NavigationProperties


    }
}