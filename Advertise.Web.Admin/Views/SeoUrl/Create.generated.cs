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

namespace Advertise.Web.Views.SeoUrl
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/SeoUrl/Create.cshtml")]
    public partial class Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.SeoUrl.SeoUrlCreateViewModel>
    {
        public Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\SeoUrl\Create.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = "ایجاد آدرس انتقالی";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>ایجاد آدرس انتقالی</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newSeoUrl\"");

WriteAttribute("action", Tuple.Create(" action=\"", 423), Tuple.Create("\"", 464)
            
            #line 12 "..\..\Views\SeoUrl\Create.cshtml"
, Tuple.Create(Tuple.Create("", 432), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.SeoUrl.Create())
            
            #line default
            #line hidden
, 432), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(" data-on-load=\"validateSeoUrl\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\SeoUrl\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span></span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"AbsoulateUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس قبلی</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"AbsoulateUrl\"");

WriteLiteral(" name=\"AbsoulateUrl\"");

WriteLiteral(" placeholder=\"آدرس قبلی\"");

WriteLiteral(" class=\"tooltipster ltr-left-text\"");

WriteLiteral(" title=\"آدرس قبلی\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span></span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"CurrentUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس جدید</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"CurrentUrl\"");

WriteLiteral(" name=\"CurrentUrl\"");

WriteLiteral(" placeholder=\"آدرس جدید\"");

WriteLiteral(" class=\"tooltipster ltr-left-text\"");

WriteLiteral(" title=\"آدرس جدید\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span></span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"IsActive\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">فعال</label>\r\n                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"IsActive\"");

WriteLiteral(" name=\"IsActive\"");

WriteLiteral(" value=\"true\"");

WriteLiteral(" placeholder=\"فعال\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"فعال\"");

WriteLiteral(" checked=\"checked\"");

WriteLiteral("/>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span></span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Redirection\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>نوع انتقال</span>\r\n                        <i");

WriteLiteral(" class=\"fa fa-question-circle tooltipster\"");

WriteLiteral(" title=\"نوع انتقال\"");

WriteLiteral("></i>\r\n                    </label>\r\n                    <select");

WriteLiteral(" id=\"Redirection\"");

WriteLiteral(" name=\"Redirection\"");

WriteLiteral(">\r\n                        <option>--- ");

            
            #line 75 "..\..\Views\SeoUrl\Create.cshtml"
                               Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral(" ---</option>\r\n");

            
            #line 76 "..\..\Views\SeoUrl\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\SeoUrl\Create.cshtml"
                         foreach (var redirectionType in Model.RedirectionTypeList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 3819), Tuple.Create("\"", 3849)
            
            #line 78 "..\..\Views\SeoUrl\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3827), Tuple.Create<System.Object, System.Int32>(redirectionType.Value
            
            #line default
            #line hidden
, 3827), false)
);

WriteLiteral(">");

            
            #line 78 "..\..\Views\SeoUrl\Create.cshtml"
                                                              Write(redirectionType.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 79 "..\..\Views\SeoUrl\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"newSeoUrl\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 90 "..\..\Views\SeoUrl\Create.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
