using Advertise.Service.Manager.ZarinpalServiceReference;

namespace Advertise.Service.Managers.PaymentGateway
{
    /// <summary>
    /// 
    /// </summary>
    public class ZarinpalGatewayManager : IZarinpalGatewayManager
    {
        #region Public Methods


        public PaymentGatewayImplementationServicePortTypeClient ZarinpalGateway()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            var zarinpal = new PaymentGatewayImplementationServicePortTypeClient();

            return zarinpal;
        }

        #endregion Public Methods
    }
}