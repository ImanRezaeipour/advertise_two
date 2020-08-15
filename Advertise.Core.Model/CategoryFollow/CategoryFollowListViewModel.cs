using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CategoryFollow
{

    public class CategoryFollowListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public IEnumerable<CategoryFollowViewModel> CategoryFollows { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CategoryFollowSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}