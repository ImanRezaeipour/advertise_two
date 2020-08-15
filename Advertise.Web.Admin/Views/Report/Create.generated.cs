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

namespace ASP
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/Create.cshtml")]
    public partial class _Views_Report_Create_cshtml : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Report.ReportCreateViewModel>
    {
        public _Views_Report_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Report\Create.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = "افزودن گزارش";
    ViewBag.PageName = "ReportCreate";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>افزودن گزارش</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newReport\"");

WriteAttribute("action", Tuple.Create(" action=\"", 399), Tuple.Create("\"", 440)
            
            #line 12 "..\..\Views\Report\Create.cshtml"
, Tuple.Create(Tuple.Create("", 408), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Report.Create())
            
            #line default
            #line hidden
, 408), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(" enctype=\"multipart/form-data\"");

WriteLiteral(" data-on-load=\"validateReport\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\Report\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\Report\Create.cshtml"
       Write(Html.ValidationSummary());

            
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

WriteLiteral(" for=\"Name\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">نام گزارش</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Name\"");

WriteLiteral(" name=\"Name\"");

WriteLiteral(" placeholder=\"نام گزارش\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"نام گزارش\"");

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

WriteLiteral(" for=\"Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">عنوان گزارش</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Title\"");

WriteLiteral(" name=\"Title\"");

WriteLiteral(" placeholder=\"عنوان گزارش\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"عنوان گزارش\"");

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

WriteLiteral(" for=\"Description\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">توضیحات</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" name=\"Description\"");

WriteLiteral(" placeholder=\"توضیحات\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"توضیحات\"");

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

WriteLiteral(" for=\"contentFile\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">فایل گزارش</label>\r\n                    <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" id=\"contentFile\"");

WriteLiteral(" name=\"contentFile\"");

WriteLiteral(" placeholder=\"فایل گزارش\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"فایل گزارش\"");

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"newReport\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 82 "..\..\Views\Report\Create.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591