using Advertise.Core.Domains.Common;
using System;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    public class CompanyRate : BaseRate
    {
        #region Public Properties

        public virtual Company Company { get; set; }

        public virtual Guid? CompanyId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }


        #endregion Public Properties
    }
}