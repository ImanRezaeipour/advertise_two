using System.ComponentModel;

namespace Advertise.Core.Types
{

    public enum RedirectionType
    {
        [Description("Multiple Choices")]
        MultipleChoices = 300,

        [Description("Moved Permanently")]
        MovedPermanently = 301,

        [Description("Found")]
        Found = 302,

        [Description("See Other")]
        SeeOther = 303,

        [Description("Not Modified")]
        NotModified = 304,

        [Description("Use Proxy")]
        UseProxy = 305,

        [Description("Temporary Redirect")]
        TemporaryRedirect = 307,

        [Description("Permanent Redirect")]
        PermanentRedirect = 308
    }
}