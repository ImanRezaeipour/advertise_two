using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Report
{
    public class ReportParameterViewModel : BaseViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}