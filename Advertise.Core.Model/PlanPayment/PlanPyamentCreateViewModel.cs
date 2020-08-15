using Advertise.Core.Models.Common;
using Advertise.Core.Models.Plan;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.PlanPayment
{
    public class PlanPyamentCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public decimal? Amount { get; set; }
        [Required]
        public string Code { get; set; }

        public string DiscountCode { get; set; }

        [Required]
        public PayType Pay { get; set; }
        public IEnumerable<PlanViewModel> Plans { get; set; }

        #endregion Public Properties
    }
}