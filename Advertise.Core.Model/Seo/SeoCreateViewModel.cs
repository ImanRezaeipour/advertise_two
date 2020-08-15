using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Seo
{
    public class SeoCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the record is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public LanguageType? Language { get; set; }

        /// <summary>
        /// Gets or sets the slug
        /// </summary>
        public string Slug { get; set; }

        #endregion Public Properties
    }
}