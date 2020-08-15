using Advertise.Core.Domains.Common;
using Advertise.Core.Types;
using System.Collections.Generic;

namespace Advertise.Core.Domains.Seos
{
    /// <summary>
    /// SEO settings
    /// </summary>
    public class SeoSetting : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// A value indicating whether unicode chars are allowed
        /// </summary>
        public virtual bool IsAllowUnicodeChars { get; set; }

        /// <summary>
        /// A value indicating whether canonical URL tags should be used
        /// </summary>
        public virtual bool IsCanonicalUrlEnabled { get; set; }

        /// <summary>
        /// A value indicating whether we should conver non-wetern chars to western ones
        /// </summary>
        public virtual bool HasConvertNonWesternChars { get; set; }

        /// <summary>
        /// Custom tags in the <![CDATA[<head></head>]]> section
        /// </summary>
        public virtual string CustomHeadTags { get; set; }

        /// <summary>
        /// Default META description
        /// </summary>
        public virtual string DefaultMetaDescription { get; set; }

        /// <summary>
        /// Default META keywords
        /// </summary>
        public virtual string DefaultMetaKeywords { get; set; }

        /// <summary>
        /// Default title
        /// </summary>
        public virtual string DefaultTitle { get; set; }

        /// <summary>
        /// A value indicating whether CSS file bundling and minification is enabled
        /// </summary>
        public virtual bool IsCssBundlingEnabled { get; set; }

        /// <summary>
        /// A value indicating whether JS file bundling and minification is enabled
        /// </summary>
        public virtual bool IsJsBundlingEnabled { get; set; }

        /// <summary>
        /// A value indicating whether product META descriptions will be generated automatically (if not entered)
        /// </summary>
        public virtual string GenerateMetaDescription { get; set; }

        /// <summary>
        /// A value indicating whether Open Graph META tags should be generated
        /// </summary>
        public virtual bool HasOpenGraphMetaTags { get; set; }

        /// <summary>
        /// Page title separator
        /// </summary>
        public virtual string PageTitleSeparator { get; set; }

        ///// <summary>
        ///// Slugs (sename) reserved for some other needs
        ///// </summary>
        //public List<string> ReservedUrlRecordSlugs { get; set; }

        /// <summary>
        /// A value indicating whether Twitter META tags should be generated
        /// </summary>
        public virtual bool HasTwitterMetaTags { get; set; }

        /// <summary>
        /// WWW requires (with or without WWW)
        /// </summary>
        public virtual WwwRequirementType WwwRequirement { get; set; }

        #endregion Public Properties
    }
}