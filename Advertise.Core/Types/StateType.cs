using System.ComponentModel;

namespace Advertise.Core.Types
{

    public enum StateType
    {
        [Description("تأیید شده")]
        Approved = 1,

        [Description("در انتظار بررسی")]
        Pending = 2,

        [Description("عدم تائید")]
        Rejected = 3,

        [Description("همه")]
        All = -1
    }
}