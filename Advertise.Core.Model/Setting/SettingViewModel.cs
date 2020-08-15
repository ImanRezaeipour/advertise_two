using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Setting
{
    public class SettingViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string FacebookPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GooglePlusPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string InstagramPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsAllowViewingProfiles { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsDefaultAvatarEnabled { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LinkedinPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SiteDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SiteEmail { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SiteShortTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SiteTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SiteVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TelegramPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoMaximumSizeBytes { get; set; }

        #endregion Public Properties
    }
}