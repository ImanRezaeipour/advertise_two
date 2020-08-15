using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyHour
{
    public class CompanyHourEditViewModel : BaseViewModel
    {
       public IEnumerable<CompanyHourViewModel> CompanyHours { get; set; }
       public IEnumerable<SelectListItem> DayList { get; set; }
    }
}