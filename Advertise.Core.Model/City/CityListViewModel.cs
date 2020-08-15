using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.City
{
    public class CityListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CityViewModel> Cities { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CitySearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}