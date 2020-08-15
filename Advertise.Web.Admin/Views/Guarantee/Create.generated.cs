﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Advertise.Web.Views.Guarantee
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Guarantee/Create.cshtml")]
    public partial class Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Guarantee.GuaranteeCreateViewModel>
    {
        public Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Guarantee\Create.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = "ایجاد گارانتی";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"profile-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>ایجاد گارانتی</h4>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newGuarantee\"");

WriteAttribute("action", Tuple.Create(" action=\"", 422), Tuple.Create("\"", 466)
            
            #line 13 "..\..\Views\Guarantee\Create.cshtml"
, Tuple.Create(Tuple.Create("", 431), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Guarantee.Create())
            
            #line default
            #line hidden
, 431), false)
);

WriteLiteral(" method=\"post\"");

WriteLiteral(" data-on-load=\"validateGuarantee\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\Guarantee\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Views\Guarantee\Create.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n            \r\n            <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 25 "..\..\Views\Guarantee\Create.cshtml"
                         Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Title\"");

WriteLiteral(" name=\"Title\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Description\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 35 "..\..\Views\Guarantee\Create.cshtml"
                         Write(Admin.Description);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" name=\"Description\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Email\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 45 "..\..\Views\Guarantee\Create.cshtml"
                         Write(Admin.Email);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Email\"");

WriteLiteral(" name=\"Email\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"MobileNumber\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 55 "..\..\Views\Guarantee\Create.cshtml"
                         Write(Admin.Mobile);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"MobileNumber\"");

WriteLiteral(" name=\"MobileNumber\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"PhoneNumber\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 65 "..\..\Views\Guarantee\Create.cshtml"
                         Write(Admin.Phone);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"PhoneNumber\"");

WriteLiteral(" name=\"PhoneNumber\"");

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" form=\"newGuarantee\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 77 "..\..\Views\Guarantee\Create.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
