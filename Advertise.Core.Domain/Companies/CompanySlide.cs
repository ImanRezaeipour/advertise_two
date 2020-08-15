using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    public class CompanySlide : BaseEntity
    {
        #region Properties

        public virtual string Title { get; set; }
        public virtual string ImageFileName { get; set; }
        public virtual string Description { get; set; }
        public virtual int Order { get; set; }
        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion
    }
}