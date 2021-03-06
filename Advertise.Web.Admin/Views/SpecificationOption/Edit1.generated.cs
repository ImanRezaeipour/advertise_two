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

namespace Advertise.Web.Views.SpecificationOption
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/SpecificationOption/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.SpecificationOption.SpecificationOptionEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\SpecificationOption\Edit.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = Admin.EditSpecificationsOption;

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n            <h4>");

            
            #line 9 "..\..\Views\SpecificationOption\Edit.cshtml"
           Write(Admin.EditSpecificationsOption);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n            <form");

WriteLiteral(" id=\"editSpecificationOption\"");

WriteAttribute("action", Tuple.Create(" action=\"", 508), Tuple.Create("\"", 560)
            
            #line 12 "..\..\Views\SpecificationOption\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 517), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.SpecificationOption.Edit())
            
            #line default
            #line hidden
, 517), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(" data-on-load =\"validateSpecificationOption\">\r\n");

WriteLiteral("                ");

            
            #line 13 "..\..\Views\SpecificationOption\Edit.cshtml"
           Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 14 "..\..\Views\SpecificationOption\Edit.cshtml"
           Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n                    \r\n                    <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                            <p>\r\n                                <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                                <span></span>\r\n                           " +
"     <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                            </p>\r\n                        </div>\r\n        " +
"            </div>\r\n                    <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"CategoryId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                            Write(Admin.Category);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <div");

WriteLiteral(" id=\"CategoryTree\"");

WriteLiteral(" style=\"direction: rtl\"");

WriteLiteral(" class=\"tree\"");

WriteLiteral(" data-on-load=\"TreeCategoryReview\"");

WriteLiteral("></div> <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"CategoryId\"");

WriteLiteral(" id=\"CategoryId\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1592), Tuple.Create("\"", 1617)
            
            #line 30 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                                                          , Tuple.Create(Tuple.Create("", 1600), Tuple.Create<System.Object, System.Int32>(Model.CategoryId
            
            #line default
            #line hidden
, 1600), false)
);

WriteLiteral("/>\r\n                    </div>\r\n                    \r\n                    <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                            <p>\r\n                                <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                                <span></span>\r\n                           " +
"     <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                            </p>\r\n                        </div>\r\n        " +
"            </div>\r\n                    <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"SpecificationId\"");

WriteLiteral(" id=\"SpecificationId\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2254), Tuple.Create("\"", 2284)
            
            #line 43 "..\..\Views\SpecificationOption\Edit.cshtml"
                , Tuple.Create(Tuple.Create("", 2262), Tuple.Create<System.Object, System.Int32>(Model.SpecificationId
            
            #line default
            #line hidden
, 2262), false)
);

WriteLiteral(" data-val=\"true\"");

WriteLiteral(" data-val-required=\"");

            
            #line 43 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                                                                                                      Write(Admin.RequiredSpecification);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("/>\r\n                        <label");

WriteLiteral(" for=\"SpecificationId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 44 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                 Write(Admin.Specification);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <select");

WriteLiteral(" id=\"specificationContainer\"");

WriteLiteral(" onchange=\"changeEvent(this)\"");

WriteLiteral(" data-hidden=\"Model.SpecificationId\"");

WriteLiteral(" data-val=\"true\"");

WriteLiteral(" data-val-regex=\"");

            
            #line 45 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                                                                                                        Write(Admin.RegularSpecification);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-val-regex-pattern=\"^(\\{){0,1}[0-9a-fA-F]{8}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{4}" +
"\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{12}(\\}){0,1}$\"");

WriteLiteral(">\r\n                            <option");

WriteLiteral(" value=\"\"");

WriteLiteral(" selected>");

            
            #line 46 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                 Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n                        </select>\r\n                    </div>\r\n       " +
"             \r\n                    <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                            <p>\r\n                                <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                                <span></span>\r\n                           " +
"     <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                            </p>\r\n                        </div>\r\n        " +
"            </div>\r\n                    <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"addSpecOption(event, this)\"");

WriteLiteral(" data-items=\"#items\"");

WriteLiteral(" data-item=\"#items #item\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-plus-square\"");

WriteLiteral("></i>\r\n                            <span>");

            
            #line 62 "..\..\Views\SpecificationOption\Edit.cshtml"
                             Write(Admin.Add);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </button>\r\n                    </div>\r\n         " +
"           \r\n                    <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                            <p>\r\n                                <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                                <span></span>\r\n                           " +
"     <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                            </p>\r\n                        </div>\r\n        " +
"            </div>\r\n                    <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"Options.Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 76 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                               Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <div");

WriteLiteral(" id=\"items\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" id=\"item\"");

WriteLiteral(" data-index=\"0\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Options.Title\"");

WriteLiteral(" name=\"Options.Title\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 4622), Tuple.Create("\"", 4648)
            
            #line 80 "..\..\Views\SpecificationOption\Edit.cshtml"
                            , Tuple.Create(Tuple.Create("", 4636), Tuple.Create<System.Object, System.Int32>(Admin.Title
            
            #line default
            #line hidden
, 4636), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 4669), Tuple.Create("\"", 4715)
            
            #line 80 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                     , Tuple.Create(Tuple.Create("", 4677), Tuple.Create<System.Object, System.Int32>(Admin.ItShowsSpecificationOptionTitle
            
            #line default
            #line hidden
, 4677), false)
);

WriteLiteral(" data-val=\"true\"");

WriteLiteral(" data-val-required=\"");

            
            #line 80 "..\..\Views\SpecificationOption\Edit.cshtml"
                                                                                                                                                                                                                           Write(Admin.RequiredTitle2);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("/>\r\n                                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-danger fa fa-trash\"");

WriteLiteral(" onclick=\"deleteTag(event, 0, \'#items #item\')\"");

WriteLiteral("></button>\r\n                                </div>\r\n                            <" +
"/div>\r\n                        </div>\r\n                    </div>\r\n\r\n           " +
"         <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n                </div>\r\n            </form>\r\n            \r\n            <" +
"div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" form=\"editSpecificationOption\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(" >\r\n                    <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                    <span>");

            
            #line 94 "..\..\Views\SpecificationOption\Edit.cshtml"
                     Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div" +
">");

        }
    }
}
#pragma warning restore 1591
