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

namespace Advertise.Web.Views.Role
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Role/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Role.RoleEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Role\Edit.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = Admin.EditRole;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\Role\Edit.cshtml"
       Write(Admin.EditRole);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"editRole\"");

WriteAttribute("action", Tuple.Create(" action=\"", 407), Tuple.Create("\"", 444)
            
            #line 12 "..\..\Views\Role\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 416), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Role.Edit())
            
            #line default
            #line hidden
, 416), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral("  data-on-load=\"validateRole\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"Id\"");

WriteLiteral(" name=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 541), Tuple.Create("\"", 558)
            
            #line 13 "..\..\Views\Role\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 549), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 549), false)
);

WriteLiteral("/>\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\Role\Edit.cshtml"
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

WriteLiteral(" for=\"name\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Role\Edit.cshtml"
                                                  Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"name\"");

WriteLiteral(" name=\"name\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1303), Tuple.Create("\"", 1322)
            
            #line 30 "..\..\Views\Role\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1311), Tuple.Create<System.Object, System.Int32>(Model.Name
            
            #line default
            #line hidden
, 1311), false)
);

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 1323), Tuple.Create("\"", 1349)
            
            #line 30 "..\..\Views\Role\Edit.cshtml"
              , Tuple.Create(Tuple.Create("", 1337), Tuple.Create<System.Object, System.Int32>(Admin.Title
            
            #line default
            #line hidden
, 1337), false)
);

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

WriteLiteral(" for=\"permissionTree\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Role\Edit.cshtml"
                                                            Write(Admin.Accesss);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <div");

WriteLiteral(" id=\"permissionTree\"");

WriteLiteral(" style=\"direction: rtl\"");

WriteLiteral(" class=\"tree\"");

WriteLiteral(" data-on-load=\"treeRole\"");

WriteLiteral(" data-param=\"edit\"");

WriteLiteral("></div>\r\n                    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"permissions\"");

WriteLiteral(" name=\"permissions\"");

WriteLiteral(" value=\"\"");

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"editRole\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(" >\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 55 "..\..\Views\Role\Edit.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
