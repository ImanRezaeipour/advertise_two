using System.Collections.Generic;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Catalog
{
    public class CatalogListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CatalogViewModel> Catalogs { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CatalogSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}