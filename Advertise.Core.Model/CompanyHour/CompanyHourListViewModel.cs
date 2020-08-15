using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyHour
{
    public class CompanyHourListViewModel : BaseViewModel
    {
       public IEnumerable<CompanyHourViewModel> CompanyHours { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyHourSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }
    }
}