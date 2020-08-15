using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.AdsOption
{
    public class AdsOptionListViewModel : BaseViewModel
    {
        public IEnumerable<AdsOptionViewModel> AdsOptions { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public AdsOptionSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }
    }
}