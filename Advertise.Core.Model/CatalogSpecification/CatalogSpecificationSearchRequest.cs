using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CatalogSpecification
{
    public class CatalogSpecificationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CatalogId { get; set; }
        public DateTime? CreatedOn { get; set; }

        #endregion Public Properties
    }
}