using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyHour
{
    public class CompanyHourCreateViewModel : BaseViewModel
    {
        public  DayType? DayOfWeek { get; set; }
        public  TimeSpan? EndTimeFirst { get; set; }
        public  TimeSpan? StartTimeFirst { get; set; }
        public  TimeSpan? EndTimeSecond { get; set; }
        public  TimeSpan? StartTimeSecond { get; set; }
        public  Guid? CompanyId { get; set; }
        
    }
}