using System.ComponentModel;

namespace Advertise.Core.Types
{
    public enum CategoryType
    {
        [Description("...")]
        None = -1,

        [Description("خدماتی")]
        Service = 0,

        [Description("فروشگاهی")]
        Salable = 1,
    }
}