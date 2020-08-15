using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyBalance
{
    public class CompanyBalanceSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }

        #endregion Public Properties
    }
}