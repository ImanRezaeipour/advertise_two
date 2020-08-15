using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.PlanDiscount
{

    public class PlanDiscountViewModel : BaseViewModel
    {
        #region Public Properties

        public string Code { get; set; }
        public int? Count { get; set; }
        public DateTime? Expire { get; set; }
        public Guid Id { get; set; }
        public int? Max { get; set; }
        public int? Percent { get; set; }

        #endregion Public Properties
    }
}