using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     نشان دهنده دیده شدن محصول
    /// </summary>
    public class ProductVisit : BaseVisit
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        public virtual bool? IpAddress { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual User VisitedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? VisitedById { get; set; }

        /// <summary>
        ///     کد اختصاصی شرکت
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }


        #endregion
    }
}