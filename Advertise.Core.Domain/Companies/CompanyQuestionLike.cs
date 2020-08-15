using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{

    public class CompanyQuestionLike : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual bool? IsLike { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual User LikedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? LikedById { get; set; }

        /// <summary>
        ///     کد اختصاصی پرسش و پاسخ
        ///
        /// </summary>
        public virtual CompanyQuestion Question { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? QuestionId { get; set; }

        #endregion
    }
}