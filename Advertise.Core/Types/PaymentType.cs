using System.ComponentModel;

namespace Advertise.Core.Types
{
    /// <summary>
    /// نشان دهنده انواع علمیاتی است که میتواند انجام شود
    /// </summary>
    public enum PaymentType
    {
        [Description("پرداخت اینترنتی")]
        OnlinePayment = 1,

        [Description("پرداخت در محل")]
        PayInPerson = 2,

        [Description("پرداخت کارت به کارت")]
        PaymentViaATM = 3
    }
}