using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductRate
{
    public class ProductRateCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid? ProductId { get; set; }
        public RateType? Rate { get; set; }

        #endregion Public Properties
    }
}