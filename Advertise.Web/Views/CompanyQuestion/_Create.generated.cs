#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Advertise.Web.Views.CompanyQuestion
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Advertise;
    using Advertise.Core.Languages;
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyQuestion/_Create.cshtml")]
    public partial class _Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<dynamic>
    {
        public _Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n    <label");

WriteLiteral(" for=\"Question\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n        <span>سوال خود را مطرح نمایید:</span>\r\n    </label>\r\n    <textarea");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Question\"");

WriteLiteral(" name=\"Question\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 257), Tuple.Create("\"", 290)
            
            #line 6 "..\..\Views\CompanyQuestion\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 271), Tuple.Create<System.Object, System.Int32>(Admin.QuestionText
            
            #line default
            #line hidden
, 271), false)
);

WriteLiteral("></textarea>\r\n</div>\r\n<div");

WriteLiteral(" class=\"input-container half\"");

WriteLiteral(">\r\n    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"button primary\"");

WriteLiteral(" data-on-click=\"ajaxSendQuestion\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\CompanyQuestion\_Create.cshtml"
                                                                             Write(Admin.Send);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
