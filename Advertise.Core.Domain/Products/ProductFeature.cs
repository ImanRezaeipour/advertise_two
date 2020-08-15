using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     ویژگی های محصول
    /// </summary>
    public class ProductFeature : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     ویژگی
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     محصول
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion

    }
}