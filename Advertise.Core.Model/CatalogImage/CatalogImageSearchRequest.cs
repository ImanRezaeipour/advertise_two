using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CatalogImage
{
    public class CatalogImageSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }

        public Guid? CatalogId { get; set; }

        #endregion Public Properties
    }
}