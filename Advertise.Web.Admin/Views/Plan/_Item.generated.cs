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

namespace Advertise.Web.Views.Plan
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
    
    #line 2 "..\..\Views\Plan\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\Plan\_Item.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Plan/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Plan.PlanViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div>\r\n");

WriteLiteral("    ");

            
            #line 6 "..\..\Views\Plan\_Item.cshtml"
Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Plan\_Item.cshtml"
Write(Model.Price);

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\Plan\_Item.cshtml"
Write(Model.CreatedOn.CastToRegularDate());

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

            
            #line 14 "..\..\Views\Plan\_Item.cshtml"
 if (User.IsInRole(PermissionConst.CanPlanDeleteAjax))
{

            
            #line default
            #line hidden
WriteLiteral("    <li>\r\n        <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"removeConfirm\"");

WriteLiteral(" data-param=\"");

            
            #line 17 "..\..\Views\Plan\_Item.cshtml"
                                                                          Write(Url.Action(MVC.Plan.DeleteAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n            <span>");

            
            #line 18 "..\..\Views\Plan\_Item.cshtml"
             Write(Admin.Delete);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i>\r\n        </a>\r\n    </li>\r\n");

            
            #line 22 "..\..\Views\Plan\_Item.cshtml"
}

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Plan\_Item.cshtml"
 if (User.IsInRole(PermissionConst.CanPlanEdit))
{

            
            #line default
            #line hidden
WriteLiteral("    <li>\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 681), Tuple.Create("\"", 724)
            
            #line 26 "..\..\Views\Plan\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 688), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Plan.Edit(Model.Id))
            
            #line default
            #line hidden
, 688), false)
);

WriteLiteral(">\r\n            <span>");

            
            #line 27 "..\..\Views\Plan\_Item.cshtml"
             Write(Admin.Edit);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <i");

WriteLiteral(" class=\"fa fa-pencil fa-flip-horizontal\"");

WriteLiteral("></i>\r\n        </a>\r\n    </li>\r\n");

            
            #line 31 "..\..\Views\Plan\_Item.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
