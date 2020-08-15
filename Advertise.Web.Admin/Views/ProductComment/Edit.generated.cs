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

namespace Advertise.Web.Views.ProductComment
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ProductComment/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.ProductComment.ProductCommentEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\ProductComment\Edit.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = Admin.CommentEdit;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\ProductComment\Edit.cshtml"
       Write(Admin.CommentEdit);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"editProductComment\"");

WriteLiteral(" action=\"\"");

WriteLiteral(" method=\"Post\"");

WriteLiteral(" data-on-load=\"validateProductComment\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\ProductComment\Edit.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\ProductComment\Edit.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"Id\"");

WriteLiteral(" name=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 635), Tuple.Create("\"", 652)
            
            #line 15 "..\..\Views\ProductComment\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 643), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 643), false)
);

WriteLiteral(" />\r\n\r\n            <div");

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

WriteLiteral(" for=\"Body\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\ProductComment\Edit.cshtml"
                                                  Write(Admin.CommentText);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <textarea");

WriteLiteral(" id=\"Body\"");

WriteLiteral(" name=\"Body\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\ProductComment\Edit.cshtml"
                                               Write(Model.Body);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"editProductComment\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1694), Tuple.Create("\"", 1771)
, Tuple.Create(Tuple.Create("", 1704), Tuple.Create("javascript:", 1704), true)
, Tuple.Create(Tuple.Create(" ", 1715), Tuple.Create("form.action", 1716), true)
, Tuple.Create(Tuple.Create(" ", 1727), Tuple.Create("=", 1728), true)
, Tuple.Create(Tuple.Create(" ", 1729), Tuple.Create("\'", 1730), true)
            
            #line 39 "..\..\Views\ProductComment\Edit.cshtml"
                                                                                                  , Tuple.Create(Tuple.Create("", 1731), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.ProductComment.Edit())
            
            #line default
            #line hidden
, 1731), false)
, Tuple.Create(Tuple.Create("", 1769), Tuple.Create("\';", 1769), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 41 "..\..\Views\ProductComment\Edit.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n            <button");

WriteLiteral(" form=\"editProductComment\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2025), Tuple.Create("\"", 2109)
, Tuple.Create(Tuple.Create("", 2035), Tuple.Create("javascript:", 2035), true)
, Tuple.Create(Tuple.Create(" ", 2046), Tuple.Create("form.action", 2047), true)
, Tuple.Create(Tuple.Create(" ", 2058), Tuple.Create("=", 2059), true)
, Tuple.Create(Tuple.Create(" ", 2060), Tuple.Create("\'", 2061), true)
            
            #line 43 "..\..\Views\ProductComment\Edit.cshtml"
                                                                                                  , Tuple.Create(Tuple.Create("", 2062), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.ProductComment.EditApprove())
            
            #line default
            #line hidden
, 2062), false)
, Tuple.Create(Tuple.Create("", 2107), Tuple.Create("\';", 2107), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 45 "..\..\Views\ProductComment\Edit.cshtml"
                 Write(Admin.ConfirmAndSave);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n            <button");

WriteLiteral(" form=\"editProductComment\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2373), Tuple.Create("\"", 2456)
, Tuple.Create(Tuple.Create("", 2383), Tuple.Create("javascript:", 2383), true)
, Tuple.Create(Tuple.Create(" ", 2394), Tuple.Create("form.action", 2395), true)
, Tuple.Create(Tuple.Create(" ", 2406), Tuple.Create("=", 2407), true)
, Tuple.Create(Tuple.Create(" ", 2408), Tuple.Create("\'", 2409), true)
            
            #line 47 "..\..\Views\ProductComment\Edit.cshtml"
                                                                                                  , Tuple.Create(Tuple.Create("", 2410), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.ProductComment.EditReject())
            
            #line default
            #line hidden
, 2410), false)
, Tuple.Create(Tuple.Create("", 2454), Tuple.Create("\';", 2454), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 49 "..\..\Views\ProductComment\Edit.cshtml"
                 Write(Admin.RejectAndSave);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591