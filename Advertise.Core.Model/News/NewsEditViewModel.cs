using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.News
{
    public class NewsEditViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }

        public DateTime? ExpiredOn { get; set; }
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        ///     مشخص کننده‌ی نوع اطلاع رسانی
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}