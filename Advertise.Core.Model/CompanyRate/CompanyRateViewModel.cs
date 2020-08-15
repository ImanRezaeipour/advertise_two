using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyRate
{
    public class CompanyRateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public bool? IsApprove { get; set; }
        public RateType? Rate { get; set; }

        #endregion Public Properties
    }
}