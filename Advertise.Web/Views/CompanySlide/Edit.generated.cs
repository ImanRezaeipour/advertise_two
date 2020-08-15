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

namespace Advertise.Web.Views.CompanySlide
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanySlide/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanySlide.CompanySlideEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\CompanySlide\Edit.cshtml"
  
    Layout = MVC.Shared.Views._ProfileLayout;
    ViewBag.Title = "ویرایش اسلاید کمپانی";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"profile-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\CompanySlide\Edit.cshtml"
       Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"editCompanySlide\"");

WriteLiteral(" data-on-load=\"validateCompanySlide\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\CompanySlide\Edit.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\CompanySlide\Edit.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"Id\"");

WriteLiteral(" name=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 620), Tuple.Create("\"", 637)
            
            #line 15 "..\..\Views\CompanySlide\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 628), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 628), false)
);

WriteLiteral("/>\r\n\r\n            <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 25 "..\..\Views\CompanySlide\Edit.cshtml"
                         Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Title\"");

WriteLiteral(" name=\"Title\"");

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1159), Tuple.Create("\"", 1179)
            
            #line 27 "..\..\Views\CompanySlide\Edit.cshtml"
          , Tuple.Create(Tuple.Create("", 1167), Tuple.Create<System.Object, System.Int32>(Model.Title
            
            #line default
            #line hidden
, 1167), false)
);

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"ImageFileName\"");

WriteLiteral(" class=\"rl-label tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1486), Tuple.Create("\"", 1515)
            
            #line 34 "..\..\Views\CompanySlide\Edit.cshtml"
   , Tuple.Create(Tuple.Create("", 1494), Tuple.Create<System.Object, System.Int32>(Admin.ItChoosesImage
            
            #line default
            #line hidden
, 1494), false)
);

WriteLiteral(">");

            
            #line 34 "..\..\Views\CompanySlide\Edit.cshtml"
                                                                                                     Write(Admin.UploadAdPhoto);

            
            #line default
            #line hidden
WriteLiteral(" :</label>\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Views\CompanySlide\Edit.cshtml"
               Write(Html.Partial(MVC.Shared.Views.FineUploaderTemplates._FineUploaderTemplate));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" name=\"ImageFileName\"");

WriteLiteral(" id=\"ImageFileName\"");

WriteLiteral(" data-on-load=\"uploaderCompanySlide\"");

WriteLiteral(" data-param=\"edit\"");

WriteLiteral("></div>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 44 "..\..\Views\CompanySlide\Edit.cshtml"
                         Write(Admin.ThisAdIsUsedFor);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <label");

WriteLiteral(" class=\"enabled-form-iradio-label\"");

WriteLiteral(" for=\"CompanyEntity\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"EntityName\"");

WriteLiteral(" value=\"CompanyEntity\"");

WriteLiteral(" id=\"CompanyEntity\"");

WriteLiteral(" data-on-change=\"disableEntity\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 2353), Tuple.Create("\"", 2391)
            
            #line 47 "..\..\Views\CompanySlide\Edit.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 2363), Tuple.Create<System.Object, System.Int32>(!Model.ProductId.HasValue
            
            #line default
            #line hidden
, 2363), false)
);

WriteLiteral(" />\r\n                        <span>کمپانی من</span>\r\n                    </label>" +
"\r\n                    <label");

WriteLiteral(" class=\"disabled-form-iradio-label\"");

WriteLiteral(" for=\"ProductEntity\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"EntityName\"");

WriteLiteral(" value=\"ProductEntity\"");

WriteLiteral(" id=\"ProductEntity\"");

WriteLiteral(" data-on-change=\"enableEntity\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 2691), Tuple.Create("\"", 2728)
            
            #line 51 "..\..\Views\CompanySlide\Edit.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 2701), Tuple.Create<System.Object, System.Int32>(Model.ProductId.HasValue
            
            #line default
            #line hidden
, 2701), false)
);

WriteLiteral("/>\r\n                        <span>محصولات</span>\r\n                    </label>\r\n " +
"               </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container hide-none\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height hide-none\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"ProductId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">محصولات</label>\r\n                    <select");

WriteLiteral(" name=\"ProductId\"");

WriteLiteral(" id=\"ProductId\"");

WriteLiteral(">\r\n                        <option selected disabled>-- ");

            
            #line 62 "..\..\Views\CompanySlide\Edit.cshtml"
                                                Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral(" --</option>\r\n");

            
            #line 63 "..\..\Views\CompanySlide\Edit.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\CompanySlide\Edit.cshtml"
                         foreach (var item in Model.EntityList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 3402), Tuple.Create("\"", 3421)
            
            #line 65 "..\..\Views\CompanySlide\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3410), Tuple.Create<System.Object, System.Int32>(item.Value
            
            #line default
            #line hidden
, 3410), false)
);

WriteAttribute("selected", Tuple.Create(" selected=\"", 3422), Tuple.Create("\"", 3476)
            
            #line 65 "..\..\Views\CompanySlide\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3433), Tuple.Create<System.Object, System.Int32>(Model.ProductId.ToString() == item.Value
            
            #line default
            #line hidden
, 3433), false)
);

WriteLiteral(">");

            
            #line 65 "..\..\Views\CompanySlide\Edit.cshtml"
                                                                                                          Write(item.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 66 "..\..\Views\CompanySlide\Edit.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" form=\"editCompanySlide\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 3877), Tuple.Create("\"", 3952)
, Tuple.Create(Tuple.Create("", 3887), Tuple.Create("javascript:", 3887), true)
, Tuple.Create(Tuple.Create(" ", 3898), Tuple.Create("form.action", 3899), true)
, Tuple.Create(Tuple.Create(" ", 3910), Tuple.Create("=", 3911), true)
, Tuple.Create(Tuple.Create(" ", 3912), Tuple.Create("\'", 3913), true)
            
            #line 74 "..\..\Views\CompanySlide\Edit.cshtml"
                                                                                                                    , Tuple.Create(Tuple.Create("", 3914), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanySlide.Edit())
            
            #line default
            #line hidden
, 3914), false)
, Tuple.Create(Tuple.Create("", 3950), Tuple.Create("\';", 3950), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>ذخیره</span>\r\n            </button>\r\n        </div>\r" +
"\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
