using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using System.Collections.Generic;
using Advertise.Core.Models.Specification;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Product
{
    public class ProductSearchViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<SpecificationViewModel> Specifications { get; set; }

        public IEnumerable<CategoryViewModel> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }

        public IEnumerable<SelectListItem> PageSizeFilterList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public IEnumerable<SelectListItem> Colors { get; set; }
        public ColorType Color { get; set; }


        /// <summary>
        /// </summary>
        public ProductSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionFilterList { get; set; }
        public IEnumerable<SelectListItem> SortMemberFilterList { get; set; }

        public IEnumerable<SelectListItem> RequestValues { get; set; }

        #endregion Public Properties
    }
}