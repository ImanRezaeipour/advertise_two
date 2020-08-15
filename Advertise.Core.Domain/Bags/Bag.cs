using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Bags
{
    /// <summary>
    /// 
    /// </summary>
    public class Bag:BaseEntity
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual int? ProductCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool? IsOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool? IsCancel { get; set; }

        #endregion

        #region NavigationProperties

   

        /// <summary>
        /// 
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? ProductId { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}
