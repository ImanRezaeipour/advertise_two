using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Notifications
{
    /// <summary>
    ///     نشان دهنده هشدار
    /// </summary>
    public class Notification : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     یک اطلاع رسانی خوانده شده است یا خیر
        /// </summary>
        public virtual bool? IsRead { get; set; }

        /// <summary>
        ///     کاربر با کلیک بر روی آن به صفحه‌ی خاصی هدایت شود
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// </summary>
        public virtual DateTime? ReadOn { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public virtual NotificationType Type { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? TargetId { get; set; }
        public virtual Product Target { get; set; }
        public virtual Guid? OwnedById { get; set; }

        /// <summary>
        /// </summary>
        public virtual string TargetTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string TargetImage { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion


    }
}