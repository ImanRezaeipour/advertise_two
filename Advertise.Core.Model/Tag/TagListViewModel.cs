using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Tag
{
    public class TagListViewModel :BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public TagSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

        #endregion Public Properties
    }
}