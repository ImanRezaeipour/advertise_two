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

namespace Advertise.Web.Views.Account
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
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/PhoneNumberConfirmed.cshtml")]
    public partial class PhoneNumberConfirmed : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<dynamic>
    {
        public PhoneNumberConfirmed()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Public._PublicLayout;
    ViewBag.Title = Admin.ConfirmActivation;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"mp-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"mp-container\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"mp-header mp-msg\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"fa fa-check-square\"");

WriteLiteral("></i>\r\n            <span");

WriteLiteral(" class=\"mp-msg\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
                            Write(Admin.ConfirmActivation);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </h1>\r\n        <h2");

WriteLiteral(" class=\"mp-paragraph\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"fa fa-exclamation-circle mp-icon\"");

WriteLiteral("></i>\r\n            <span>");

            
            #line 14 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
             Write(Admin.MessageAccountActivation);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 558), Tuple.Create("\"", 597)
            
            #line 15 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
, Tuple.Create(Tuple.Create("", 565), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Account.Login())
            
            #line default
            #line hidden
, 565), false)
);

WriteLiteral(" class=\"mp-link\"");

WriteLiteral(">\r\n                <span>");

            
            #line 16 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
                 Write(Admin.Here);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </a>\r\n            <span>");

            
            #line 18 "..\..\Views\Account\PhoneNumberConfirmed.cshtml"
             Write(Admin.Click);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </h2>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591