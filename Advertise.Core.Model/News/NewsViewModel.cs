using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.News
{
    public class NewsViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }
        public DateTime? ExpiredOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}