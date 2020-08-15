using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductSpecification
{
    public class ProductSpecificationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        public Guid? ProductId { get; set; }

        #endregion Public Properties
    }
}