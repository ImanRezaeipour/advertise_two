using System.ComponentModel;

namespace Advertise.Core.Types
{
    public enum DayType
    {
        [Description("شنبه")]
        Saturday = 0,

        [Description("یکشنبه")]
        Sunday = 1,

        [Description("دوشنبه")]
        Monday = 2,

        [Description("سه شنبه")]
        Tuesday = 3,

        [Description("چهارشنبه")]
        Wednesday = 4,

        [Description("پنجشنبه")]
        Thursday = 5,

        [Description("جمعه")]
        Friday = 6
    }
}