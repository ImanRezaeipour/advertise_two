using System.Web;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Report
{
    public class ReportCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public HttpPostedFileBase ContentFile { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}