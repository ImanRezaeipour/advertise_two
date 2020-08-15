using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    ///     نشان دهنده علاقه مندی ها
    /// </summary>
    public class CompanyFollow : BaseFollow
    {
        #region NavigationProperties


        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual User FollowedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? FollowedById { get; set; }

        /// <summary>
        ///     کد اختصاصی شرکت
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        #endregion
    }
}