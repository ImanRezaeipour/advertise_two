using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanySocial
{

    public class CompanySocialEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// </summary>
        public string GooglePlusLink { get; set; }

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