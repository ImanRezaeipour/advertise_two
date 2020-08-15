using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.PlanPayment
{
    public class PlanPaymentCallbackViewModel : BaseViewModel
    {
        #region Public Properties

        public string Authority { get; set; }
        public PayType Pay { get; set; }

        public string Status { get; set; }

        #endregion Public Properties
    }
}