using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Users
{

    public class UserViolation : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual ReportType? Type { get; set; }

        /// <summary>
        /// </summary>
        public virtual ReasonType? Reason { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string ReasonDescription { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsRead { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? TargetId { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual User ReportedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ReportedById { get; set; }

        #endregion
    }
}