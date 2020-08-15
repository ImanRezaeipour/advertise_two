using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Categories
{

    public class CategoryFollow : BaseFollow
    {
        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual User FollowedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? FollowedById { get; set; }


        /// <summary>
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CategoryId { get; set; }

        #endregion
    }
}