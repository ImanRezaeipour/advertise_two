using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CompanyHour
{

    public class CompanyHourSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}