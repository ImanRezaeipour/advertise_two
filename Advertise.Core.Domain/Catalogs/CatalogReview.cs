using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Catalogs
{

    public class CatalogReview : BaseReview
    {
        #region NavigationProperties

        /// <summary>
        ///     کد اختصاصی کمپانی
        /// </summary>
        public virtual Catalog Catalog { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CatalogId { get; set; }

        #endregion
    }
}