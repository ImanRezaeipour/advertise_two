using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductFeature
{
    public class ProductFeatureListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ProductFeatureViewModel> ProductFeatures { get; set; }
        public ProductFeatureSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}