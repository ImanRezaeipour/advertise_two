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

namespace Advertise.Web.Views.ProductReview
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ProductReview/Create.cshtml")]
    public partial class Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.ProductReview.ProductReviewCreateViewModel>
    {
        public Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\ProductReview\Create.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = Admin.CreateReview;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\ProductReview\Create.cshtml"
       Write(Admin.CreateReview);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newProductReview\"");

WriteAttribute("action", Tuple.Create(" action=\"", 443), Tuple.Create("\"", 491)
            
            #line 12 "..\..\Views\ProductReview\Create.cshtml"
, Tuple.Create(Tuple.Create("", 452), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.ProductReview.Create())
            
            #line default
            #line hidden
, 452), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(" data-on-load=\"validateProductReview\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\ProductReview\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\ProductReview\Create.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n\r\n                <div");

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

WriteLiteral(" for=\"ProductId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\ProductReview\Create.cshtml"
                                                       Write(Admin.BrandName);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <select");

WriteLiteral(" name=\"ProductId\"");

WriteLiteral(" id=\"ProductId\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\ProductReview\Create.cshtml"
                                               Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 32 "..\..\Views\ProductReview\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\ProductReview\Create.cshtml"
                         foreach (var productlist in Model.ProductList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1530), Tuple.Create("\"", 1556)
            
            #line 34 "..\..\Views\ProductReview\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1538), Tuple.Create<System.Object, System.Int32>(productlist.Value
            
            #line default
            #line hidden
, 1538), false)
);

WriteLiteral(">");

            
            #line 34 "..\..\Views\ProductReview\Create.cshtml"
                                                          Write(productlist.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 35 "..\..\Views\ProductReview\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n\r\n                <div");

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

WriteLiteral(" class=\"rl-label tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 2190), Tuple.Create("\"", 2222)
            
            #line 49 "..\..\Views\ProductReview\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2198), Tuple.Create<System.Object, System.Int32>(Admin.ItShowsReviewText
            
            #line default
            #line hidden
, 2198), false)
);

WriteLiteral(">");

            
            #line 49 "..\..\Views\ProductReview\Create.cshtml"
                                                                                               Write(Admin.FullExplanation);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <textarea");

WriteLiteral(" id=\"Body\"");

WriteLiteral(" name=\"Body\"");

WriteLiteral(" data-on-load=\"editorProductReview\"");

WriteLiteral("></textarea>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n\r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"newProductReview\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 60 "..\..\Views\ProductReview\Create.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
