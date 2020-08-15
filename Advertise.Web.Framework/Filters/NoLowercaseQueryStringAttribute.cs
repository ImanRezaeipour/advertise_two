using System;
using System.Web.Mvc;

namespace Advertise.Web.Framework.Filters
{
    /// <summary>
    /// Ensures that a HTTP request URL can contain query string parameters with both upper-case and lower-case
    /// characters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class NoLowercaseQueryStringAttribute : FilterAttribute
    {
    }
}
