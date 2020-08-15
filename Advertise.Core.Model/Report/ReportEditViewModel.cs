using System;
using System.Web;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Report
{
    public class ReportEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }
        public HttpPostedFileBase ContentFile { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}