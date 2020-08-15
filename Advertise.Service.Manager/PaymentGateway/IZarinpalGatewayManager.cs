using Advertise.Service.Manager.ZarinpalServiceReference;

namespace Advertise.Service.Managers.PaymentGateway
{
    public interface IZarinpalGatewayManager
    {
        PaymentGatewayImplementationServicePortTypeClient ZarinpalGateway();
    }
}