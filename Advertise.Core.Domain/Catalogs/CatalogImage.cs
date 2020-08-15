using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Catalogs
{
    /// <summary>
    ///     
    /// </summary>
    public class CatalogImage : BaseImage
    {
        #region Properties

        /// <summary>
        ///     
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsWatermark { get; set; }

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