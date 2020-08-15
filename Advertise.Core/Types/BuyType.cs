using System.ComponentModel;

namespace Advertise.Core.Types
{
    public enum BuyType
    {
        [Description("خرید محصول")]
        Product = 1,

        [Description("خرید تگ")]
        Tag = 2,

        [Description("خرید سرویس")]
        Service = 3
    }
}