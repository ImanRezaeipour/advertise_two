using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    ///     نشان دهنده دیده شدن کمپانی
    /// </summary>
    public class CompanyVisit : BaseVisit
    {
        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual User VisitedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? VisitedById { get; set; }

        /// <summary>
        ///     کد اختصاصی شرکت
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}