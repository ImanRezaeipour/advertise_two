using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     لایک کردن کامنت ها
    /// </summary>
    public class ProductCommentLike : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual bool? IsLike { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربر فرستنده
        /// </summary>
        public virtual User LikedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? LikedById { get; set; }

        /// <summary>
        ///     کد اختصاصی کاربر گیرنده
        /// </summary>
        public virtual ProductComment Comment { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CommentId { get; set; }

        #endregion
    }
}