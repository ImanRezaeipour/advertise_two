using System.ComponentModel;

namespace Advertise.Core.Types

{
    /// <summary>
    /// لیست انواع خریدار و فروشنده
    /// </summary>
    public enum ReceiptOptionListType
    {
        [Description("خرید")]
        Buy = 0,

        [Description("فروش")]
        Sale = 1
    }
}