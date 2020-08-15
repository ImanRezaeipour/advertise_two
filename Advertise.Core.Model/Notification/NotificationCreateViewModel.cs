using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Notification
{
    public class NotificationCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsRead { get; set; }
        public Guid TargetId { get; set; }

        public string TargetImage { get; set; }
        public string TargetTitle { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public NotificationType Type { get; set; }

        #endregion Public Properties
    }
}