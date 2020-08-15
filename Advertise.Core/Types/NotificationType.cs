using System.ComponentModel;

namespace Advertise.Core.Types
{

    public enum NotificationType
    {
        [Description("")]
        NewProduct = 1,

        [Description("")]
        NewCompany = 2,

        [Description("")]
        NewComment = 3,

        [Description("")]
        NewConversation = 4
    }
}