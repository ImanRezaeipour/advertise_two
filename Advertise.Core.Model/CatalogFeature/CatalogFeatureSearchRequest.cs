using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CatalogFeature
{
    public class CatalogFeatureSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CatalogId { get; set; }
        public DateTime? CreatedOn { get; set; }

        #endregion Public Properties
    }
}