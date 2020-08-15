using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductFeature
{
    public class ProductFeatureSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ProductId { get; set; }

        #endregion Public Properties
    }
}