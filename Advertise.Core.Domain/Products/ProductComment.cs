using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     نشان دهنده سیستم کامنت گذاری
    /// </summary>
    public class ProductComment : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     متن کامنت
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public virtual StateType? State { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public virtual string RejectDescription { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کاربری که کامنت گذاشته
        /// </summary>
        public virtual User CommentedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CommentedById { get; set; }

        /// <summary>
        ///     کاربری (اپراتور)که کامنت را تائید کرده است
        /// </summary>
        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        /// <summary>
        ///     کداختصاصی محصول
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion
    }
}