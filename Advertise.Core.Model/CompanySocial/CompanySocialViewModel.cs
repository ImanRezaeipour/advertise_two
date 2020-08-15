using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanySocial
{

    public class CompanySocialViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// نام کمپانی
        /// </summary>
        public string CompanyTitle { get; set; }

        /// <summary>
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// </summary>
        public string GooglePlusLink { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public string InstagramLink { get; set; }

        public string TelegramLink { get; set; }

        /// <summary>
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        /// </summary>
        public string YoutubeLink { get; set; }

        #endregion Public Properties
    }
}