using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Settings
{

    public class Setting : BaseEntity
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public virtual bool IsAllowViewingProfiles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDefaultAvatarEnabled { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string FacebookPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string GooglePlusPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string InstagramPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string LinkedinPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string SiteDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string SiteEmail { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string SiteShortTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string SiteTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string SiteVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string TelegramPageUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string VideoMaximumSizeBytes { get; set; }

        #endregion Public Properties
    }
}