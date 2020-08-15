using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Tags;

namespace Advertise.Core.Domains.Products
{

    public class ProductTag : BaseEntity
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
        public virtual Product Product { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion
    }
}