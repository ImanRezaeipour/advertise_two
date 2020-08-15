using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Report
{
    public class ReportViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid? Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ParentId { get; set; }

        public bool? HasChild { get; set; }

        #endregion Public Properties
    }
}