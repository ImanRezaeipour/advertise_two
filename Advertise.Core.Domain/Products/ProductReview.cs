using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Products
{

    public class ProductReview : BaseReview
    {
        #region Properties

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
        ///     کد اختصاصی کمپانی
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}