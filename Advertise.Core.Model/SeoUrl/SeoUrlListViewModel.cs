using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.SeoUrl
{
    public class SeoUrlListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public SeoUrlSearchRequest SearchRequest { get; set; }
        public IEnumerable<SeoUrlViewModel> SeoUrls { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}