using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Report
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
       
        #endregion Public Properties
    }
}