using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     مشخصات عکس ها
    /// </summary>
    public class ProductImage : BaseImage
    {
        #region Properties

        /// <summary>
        ///     ترتیب عکس
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsWatermark { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کداختصاصی محصول
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}