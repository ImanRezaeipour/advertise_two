using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    ///     نشان دهنده پیام خصوصی
    /// </summary>
    public class CompanyConversation : BaseEntity
    {
        #region Properties

    
        /// <summary>
        ///     متن پیام خصوصی
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///     آیا پیام توسط کاربر خوانده شده؟
        /// </summary>
        public virtual bool? IsRead { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsDeletedBySender { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsDeletedByReceiver { get; set; }

 
        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کاربر گیرنده
        /// </summary>
        public virtual User ReceivedBy { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ReceivedById { get; set; }

        /// <summary>
        ///     کد پیام پاسخ داده شده
        /// </summary>
        public virtual CompanyConversation Reply { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ReplyId { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyConversation> Childrens { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}