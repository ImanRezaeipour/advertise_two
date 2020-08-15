using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Tags;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{

    public class CompanyTag : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual DateTime? StartedOn { get; set; }

        /// <summary>
        /// </summary>
        public virtual DateTime? ExpiredOn { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Tag Tag { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? TagId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}