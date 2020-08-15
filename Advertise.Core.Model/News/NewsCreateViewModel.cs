using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Advertise.Core.Models.News
{
    public class NewsCreateViewModel : BaseViewModel
    {
        #region Public Properties

        [AllowHtml]

        public string Body { get; set; }

        public DateTime? ExpiredOn { get; set; }
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}