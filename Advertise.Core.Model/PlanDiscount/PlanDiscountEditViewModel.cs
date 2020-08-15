using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.PlanDiscount
{

    public class PlanDiscountEditViewModel : BaseViewModel
    {
        #region Public Properties

      public Guid Id { get; set; }
        public string Code { get; set; }

        public int? Count { get; set; }

        public DateTime? Expire { get; set; }

        public int? Max { get; set; }

        public int? Percent { get; set; }
        #endregion Public Properties
    }
}