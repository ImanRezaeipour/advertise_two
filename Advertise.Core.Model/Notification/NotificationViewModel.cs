using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Notification
{
    public class NotificationViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid TargetId { get; set; }

        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TargetImage { get; set; }

        /// <summary>
        /// </summary>
        public string TargetTitle { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public NotificationType Type { get; set; }

        /// <summary>
        ///     کاربر با کلیک بر روی آن به صفحه‌ی خاصی هدایت شود
        /// </summary>
        public string Url { get; set; }

        #endregion Public Properties
    }
}