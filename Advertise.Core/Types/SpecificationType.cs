using System.ComponentModel;

namespace Advertise.Core.Types
{

    public enum SpecificationType
    {
        [Description("چند انتخابی")]
        Checkbox = 1,

        [Description("رنگ")]
        Color = 2,

        [Description("تک انتخابی")]
        Radiobox = 3,

        [Description("لیست کشویی")]
        Droplist = 4,

        [Description("مبلغ")]
        Currency = 5,

        [Description("رشته")]
        String = 6
    }
}