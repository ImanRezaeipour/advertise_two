using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Tags
{

    public class Tag : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     عنوان سریس
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     توضیح سرویس
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string LogoFileName { get; set; }

        /// <summary>
        /// </summary>
        public virtual string CostValue { get; set; }

        /// <summary>
        /// </summary>
        public virtual string DurationDay { get; set; }

        public virtual ColorType Color { get; set; }

        /// <summary>
        ///     آیا سرویس فعال است؟
        /// </summary>
        public virtual bool? IsActive { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<ProductTag> Products { get; set; }

        #endregion
    }
}