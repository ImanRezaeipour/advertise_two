using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Category
{
    public class CategoryListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        public CategorySearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}