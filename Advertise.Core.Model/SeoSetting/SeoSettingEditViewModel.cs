using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.SeoSetting
{
    public class SeoSettingEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Default META description
        /// </summary>
        public string DefaultMetaDescription { get; set; }

        /// <summary>
        /// Default META keywords
        /// </summary>
        public string DefaultMetaKeywords { get; set; }

        /// <summary>
        /// Default title
        /// </summary>
        public string DefaultTitle { get; set; }

        /// <summary>
        /// A value indicating whether Open Graph META tags should be generated
        /// </summary>
        public bool HasOpenGraphMetaTags { get; set; }

        /// <summary>
        /// A value indicating whether Twitter META tags should be generated
        /// </summary>
        public bool HasTwitterMetaTags { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A value indicating whether canonical URL tags should be used
        /// </summary>
        public bool IsCanonicalUrlEnabled { get; set; }

        /// <summary>
        /// A value indicating whether CSS file bundling and minification is enabled
        /// </summary>
        public bool IsCssBundlingEnabled { get; set; }

        /// <summary>
        /// A value indicating whether JS file bundling and minification is enabled
        /// </summary>
        public bool IsJsBundlingEnabled { get; set; }

        /// <summary>
        /// Page title separator
        /// </summary>
        public string PageTitleSeparator { get; set; }

        /// <summary>
        /// WWW requires (with or without WWW)
        /// </summary>
        public WwwRequirementType WwwRequirement { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> WwwRequirementList { get; set; }

        #endregion Public Properties
    }
}