using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductRate
{
    public class ProductRateViewModel : BaseViewModel
    {
        #region Public Properties

        public bool? IsApprove { get; set; }
        public Guid? ProductId { get; set; }
        public RateType? Rate { get; set; }

        #endregion Public Properties
    }
}