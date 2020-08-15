using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanySlide
{

    public class CompanySlideListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanySlideViewModel> CompanySlides { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanySlideSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}