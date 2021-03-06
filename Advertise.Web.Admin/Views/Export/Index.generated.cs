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

namespace Advertise.Web.Views.Export
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Export/Index.cshtml")]
    public partial class Index : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.ExportImport.ExportIndexViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Export\Index.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = "برون ریزی";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>برون ریزی</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"getExport\"");

WriteLiteral(" method=\"Post\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\Export\Index.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\Export\Index.cshtml"
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

WriteLiteral("></i>\r\n                            <span>");

            
            #line 23 "..\..\Views\Export\Index.cshtml"
                             Write(Admin.ItShowsCompanyDomain);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">خروجی دسته ها بصورت اکسل</label>\r\n                    <button");

WriteLiteral(" form=\"getExport\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button ok-button round-corners-five\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1288), Tuple.Create("\"", 1366)
, Tuple.Create(Tuple.Create("", 1298), Tuple.Create("javascript:", 1298), true)
, Tuple.Create(Tuple.Create(" ", 1309), Tuple.Create("form.action", 1310), true)
, Tuple.Create(Tuple.Create(" ", 1321), Tuple.Create("=", 1322), true)
, Tuple.Create(Tuple.Create(" ", 1323), Tuple.Create("\'", 1324), true)
            
            #line 30 "..\..\Views\Export\Index.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 1325), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Export.CategoryExcel())
            
            #line default
            #line hidden
, 1325), false)
, Tuple.Create(Tuple.Create("", 1364), Tuple.Create("\';", 1364), true)
);

WriteLiteral(">برون ریزی</button>\r\n                </div>\r\n                \r\n                <d" +
"iv");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span>");

            
            #line 37 "..\..\Views\Export\Index.cshtml"
                             Write(Admin.ItShowsCompanyDomain);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">خروجی نمونه کاتالوگ بصورت اکسل</label>\r\n                    <select");

WriteLiteral(" id=\"categoryId\"");

WriteLiteral(" name=\"categoryId\"");

WriteLiteral(">\r\n");

            
            #line 45 "..\..\Views\Export\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\Export\Index.cshtml"
                         foreach (var category in Model.CategoryList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 2199), Tuple.Create("\"", 2222)
            
            #line 47 "..\..\Views\Export\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2207), Tuple.Create<System.Object, System.Int32>(category.Value
            
            #line default
            #line hidden
, 2207), false)
);

WriteLiteral(">");

            
            #line 47 "..\..\Views\Export\Index.cshtml"
                                                       Write(category.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 48 "..\..\Views\Export\Index.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                    <button");

WriteLiteral(" form=\"getExport\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button ok-button round-corners-five\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2414), Tuple.Create("\"", 2499)
, Tuple.Create(Tuple.Create("", 2424), Tuple.Create("javascript:", 2424), true)
, Tuple.Create(Tuple.Create(" ", 2435), Tuple.Create("form.action", 2436), true)
, Tuple.Create(Tuple.Create(" ", 2447), Tuple.Create("=", 2448), true)
, Tuple.Create(Tuple.Create(" ", 2449), Tuple.Create("\'", 2450), true)
            
            #line 50 "..\..\Views\Export\Index.cshtml"
                                                                , Tuple.Create(Tuple.Create("", 2451), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Export.CatalogTemplateExcel())
            
            #line default
            #line hidden
, 2451), false)
, Tuple.Create(Tuple.Create("", 2497), Tuple.Create("\';", 2497), true)
);

WriteLiteral(">برون ریزی</button>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
