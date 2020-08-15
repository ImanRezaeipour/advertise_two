using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     نشان دهنده انواع لایک
    /// </summary>
    public class ProductLike : BaseEntity
    {
        #region Properties

        /// <summary>
        ///  Like and Disliked
        /// </summary>
        public virtual bool? IsLike { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربری که لایک انجام داده
        /// </summary>
        public virtual User LikedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? LikedById { get; set; }

        /// <summary>
        ///     کد اختصاصی محصول
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion
    }
}