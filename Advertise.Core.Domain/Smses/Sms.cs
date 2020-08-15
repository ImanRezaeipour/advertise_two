using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Smses
{

    public class Sms : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsSend { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual User SentBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? SentById { get; set; }

        /// <summary>
        /// </summary>
        public virtual User RecievedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? RecievedById { get; set; }

        #endregion
    }
}