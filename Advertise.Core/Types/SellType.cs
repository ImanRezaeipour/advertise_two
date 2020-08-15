using System.ComponentModel;
namespace Advertise.Core.Types
{
    public enum SellType
    {
        [Description("موجود")]
        Available = 0,

        [Description("ناموجود")]
        Unavailable = 1,

        [Description("بزودی")]
        Soon = 2,

        [Description("غیرقابل فروش")]
        Hidden = 3
    }
}