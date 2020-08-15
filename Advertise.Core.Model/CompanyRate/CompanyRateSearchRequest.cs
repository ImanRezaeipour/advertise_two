using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyRate
{
    public class CompanyRateSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}