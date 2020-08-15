using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.News
{
    public class NewsDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public DateTime? ExpiredOn { get; set; }
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public string Message { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}