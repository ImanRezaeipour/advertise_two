using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.AdsPayment
{

    public class AdsPaymentCallbackViewModel : BaseViewModel
    {
        #region Public Properties

        public string Authority { get; set; }
        public string Request { get; set; }

        public string Status { get; set; }

        #endregion Public Properties
    }
}