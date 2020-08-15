using System.ComponentModel;

namespace Advertise.Core.Types
{
    public enum DurationType
    {
        [Description("یک روز")]
        OneDay = 1,

        [Description("دو روز")]
        TwoDays = 2,

        [Description("سه روز")]
        ThreeDays = 3,

        [Description("یک هفته")]
        OneWeek = 7,

        [Description("دو هفته")]
        TwoWeeks = 14,

        [Description("یک ماه")]
        OneMonth = 30,
    }
}