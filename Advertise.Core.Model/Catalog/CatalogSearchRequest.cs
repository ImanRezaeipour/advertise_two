using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Catalog
{
    public class CatalogSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}