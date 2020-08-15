using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Catalogs
{
    /// <summary>
    ///     
    /// </summary>
    public class CatalogFeature : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     
        /// </summary>
        public virtual string Title { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     
        /// </summary>
        public virtual Catalog Catalog { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CatalogId { get; set; }

        #endregion

    }
}