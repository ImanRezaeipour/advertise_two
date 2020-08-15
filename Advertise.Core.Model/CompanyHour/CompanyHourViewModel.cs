using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyHour
{
    public class CompanyHourViewModel : BaseViewModel
    {
        public  DayType? DayOfWeek { get; set; }
        public TimeSpan? EndedOn { get; set; }
        public TimeSpan? StartedOn { get; set; }
    }
}