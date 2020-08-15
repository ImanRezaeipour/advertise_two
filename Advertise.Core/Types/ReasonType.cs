using System.ComponentModel;

namespace Advertise.Core.Types
{

    public enum ReasonType
    {
        [Description("توهین")]
        Insult = 1,

        [Description("بیهوده")]
        Spam = 2,

        [Description("تبلیغات")]
        Advertising = 3,

        [Description("سایر")]
        Abuse = 4
    }
}