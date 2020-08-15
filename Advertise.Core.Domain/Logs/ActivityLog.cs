using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Logs
{

    public class ActivityLog : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     gets or sets the comment of this activity
        /// </summary>
        public virtual string Comment { get; set; }

        /// <summary>
        ///     gets or sets the date that this activity was done
        /// </summary>
        public virtual DateTime? OperatedOn { get; set; }

        /// <summary>
        ///     gets or sets the page url .
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        ///     gets or sets the title of page if Url is Not null
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     gets or sets user agent information
        /// </summary>
        public virtual string Agent { get; set; }

        /// <summary>
        ///     gets or sets user's ip address
        /// </summary>
        public virtual string OperantIp { get; set; }

        /// <summary>
        ///     gets or sets the type of this activity
        /// </summary>
        public virtual ActivityType? Type { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     gets or sets User that done this activity
        /// </summary>
        public virtual User OperantedBy { get; set; }

        /// <summary>
        ///     gets or sets Id of User that done this activity
        /// </summary>
        public virtual Guid? OperantedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}