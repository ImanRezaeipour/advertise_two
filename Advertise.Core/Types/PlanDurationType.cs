using System.ComponentModel;

namespace Advertise.Core.Types
{
    public enum PlanDurationType
    {
        [Description("سه ماهه")]
        ThreeMonth = 90,

        [Description("شش ماهه")]
        SixMonth = 180,

        [Description("یکساله")]
        TwelveMonth = 365
    }
}