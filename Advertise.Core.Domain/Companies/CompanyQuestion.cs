using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    ///     نشان دهنده پرسش و پاسخ بین کاربر و کمپانی
    /// </summary>
    public class CompanyQuestion : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     عنوان پرسش و پاسخ
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     متن پرسش و پاسخ
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
        ///     کد اختصاصی پاسخ
        /// </summary>
        public virtual CompanyQuestion Reply { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ReplyId { get; set; }

        /// <summary>
        ///     کد اختصاصی کمپانی
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual User QuestionedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? QuestionedById { get; set; }

        /// <summary>
        ///     کاربری که نقد و بررسی را تائید کرده است
        /// </summary>
        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyQuestion> Childrens { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyQuestionLike> Likes { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        public virtual User ModifiedBy { get; set; }
        public virtual Guid? ModifiedById { get; set; }

        #endregion
    }
}