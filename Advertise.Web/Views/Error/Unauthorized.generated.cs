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

namespace Advertise.Web.Views.Error
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
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Error/Unauthorized.cshtml")]
    public partial class Unauthorized : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Unauthorized()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Error\Unauthorized.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Public._PublicLayout;
    ViewBag.Title = Admin.NonMember;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"mp-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"mp-container\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"mp-header mp-msg\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"fa fa-sign-in\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" class=\"mp-msg\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Error\Unauthorized.cshtml"
                            Write(Admin.ErrorUnauthorized);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"mp-paragraph\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"fa fa-exclamation-circle mp-icon\"");

WriteLiteral("></i>\r\n            <span>");

            
            #line 14 "..\..\Views\Error\Unauthorized.cshtml"
             Write(Admin.ErrorUnauthorizedReason);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 544), Tuple.Create("\"", 583)
            
            #line 15 "..\..\Views\Error\Unauthorized.cshtml"
, Tuple.Create(Tuple.Create("", 551), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.Login())
            
            #line default
            #line hidden
, 551), false)
);

WriteLiteral(" class=\"mp-link\"");

WriteLiteral(">\r\n                <span>");

            
            #line 16 "..\..\Views\Error\Unauthorized.cshtml"
                 Write(Admin.Here);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </a>\r\n            <span>");

            
            #line 18 "..\..\Views\Error\Unauthorized.cshtml"
             Write(Admin.Click);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <br><br>\r\n            <span>");

            
            #line 20 "..\..\Views\Error\Unauthorized.cshtml"
             Write(Admin.NotRegisteredYet);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 788), Tuple.Create("\"", 835)
            
            #line 21 "..\..\Views\Error\Unauthorized.cshtml"
, Tuple.Create(Tuple.Create("", 795), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.EmailRegister())
            
            #line default
            #line hidden
, 795), false)
);

WriteLiteral(" class=\"mp-link\"");

WriteLiteral(">\r\n                <span>");

            
            #line 22 "..\..\Views\Error\Unauthorized.cshtml"
                 Write(Admin.Here);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </a>\r\n            <span>");

            
            #line 24 "..\..\Views\Error\Unauthorized.cshtml"
             Write(Admin.Click);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </h2>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
