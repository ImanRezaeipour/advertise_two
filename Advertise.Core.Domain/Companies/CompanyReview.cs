using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{

    public class CompanyReview : BaseReview
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
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

       
        /// <summary>
        ///     کاربری که نقد و بررسی را تائید کرده است
        /// </summary>
        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        #endregion
    }
}