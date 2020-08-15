﻿using Advertise.Service.Managers.File;

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

namespace Advertise.Web.Views.CompanyFollow
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
    
    #line 2 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
#line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyFollow/_FollowerItem.cshtml")]
    public partial class _FollowerItem : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanyFollow.CompanyFollowViewModel>
    {
        public _FollowerItem()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"follow-list-item\"");

WriteLiteral(">\r\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 231), Tuple.Create("\"", 282)
            
            #line 6 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
, Tuple.Create(Tuple.Create("", 238), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.User.Detail(Model.UserName))
            
            #line default
            #line hidden
, 238), false)
);

WriteLiteral(">\r\n        <p");

WriteLiteral(" class=\"text-header\"");

WriteLiteral(">");

            
            #line 7 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
                          Write(Model.UserName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        <figure");

WriteLiteral(" class=\"user-avatar medium liquid\"");

WriteLiteral(">\r\n");

            
            #line 9 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
            
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
             if (Model.AvatarFileName != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <img");

WriteLiteral(" class=\"banner-image\"");

WriteAttribute("src", Tuple.Create(" src=\"", 494), Tuple.Create("\"", 555)
            
            #line 11 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
, Tuple.Create(Tuple.Create("", 500), Tuple.Create<System.Object, System.Int32>(FileConst.ImagesWebPath.PlusWord(Model.AvatarFileName)
            
            #line default
            #line hidden
, 500), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("/>\r\n");

            
            #line 12 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <img");

WriteLiteral(" class=\"banner-image\"");

WriteAttribute("src", Tuple.Create(" src=\"", 656), Tuple.Create("\"", 682)
            
            #line 15 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
, Tuple.Create(Tuple.Create("", 662), Tuple.Create<System.Object, System.Int32>(FileConst.NoPreview
            
            #line default
            #line hidden
, 662), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("/>\r\n");

            
            #line 16 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </figure>\r\n    </a>\r\n    <div");

WriteLiteral(" class=\"fl-item-info fl-description\"");

WriteLiteral(">\r\n        <p");

WriteLiteral(" class=\"text-header\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
                          Write(Model.FullName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        <p>");

            
            #line 21 "..\..\Views\CompanyFollow\_FollowerItem.cshtml"
      Write(Model.PhoneNumber);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
