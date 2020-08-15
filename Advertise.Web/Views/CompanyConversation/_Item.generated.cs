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

namespace Advertise.Web.Views.CompanyConversation
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
    
    #line 2 "..\..\Views\CompanyConversation\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\CompanyConversation\_Item.cshtml"
#line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    
    #line 4 "..\..\Views\CompanyConversation\_Item.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyConversation/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanyConversation.CompanyConversationViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\CompanyConversation\_Item.cshtml"
  
    var currentUserId = Guid.Empty;
    if (HttpContext.Current.User.Identity.GetUserId().HasValue())
    {
        currentUserId = Guid.Parse(HttpContext.Current.User.Identity.GetUserId());
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 452), Tuple.Create("\"", 558)
, Tuple.Create(Tuple.Create("", 460), Tuple.Create("post-item", 460), true)
, Tuple.Create(Tuple.Create(" ", 469), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 13 "..\..\Views\CompanyConversation\_Item.cshtml"
                       if(currentUserId == Model.CreatedBy.Id) {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "receive");

            
            #line 13 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                    } else {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "send");

            
            #line 13 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                                             }
            
            #line default
            #line hidden
}), 470), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"inverse-rounded-wrapper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"inverse-rounded\"");

WriteLiteral("></div>\r\n    </div>\r\n    <figure");

WriteLiteral(" class=\"post-avatar\"");

WriteLiteral(">\r\n        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 708), Tuple.Create("\"", 861)
, Tuple.Create(Tuple.Create("", 714), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                   if(Model.AvatarFileName != null) {
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                    WriteTo(__razor_attribute_value_writer, FileConst.ImagesWebPath.PlusWord(Model.AvatarFileName));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                                                         } else {
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                                WriteTo(__razor_attribute_value_writer, FileConst.NoAvatarPth);

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                                                                                                    }
            
            #line default
            #line hidden
}), 714), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 862), Tuple.Create("\"", 893)
            
            #line 18 "..\..\Views\CompanyConversation\_Item.cshtml"
                                                                                             , Tuple.Create(Tuple.Create("", 868), Tuple.Create<System.Object, System.Int32>(Model.CreatedBy.UserName
            
            #line default
            #line hidden
, 868), false)
);

WriteLiteral(" />\r\n    </figure>\r\n    <div");

WriteLiteral(" class=\"post-container\"");

WriteLiteral(">\r\n");

            
            #line 21 "..\..\Views\CompanyConversation\_Item.cshtml"
        
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\CompanyConversation\_Item.cshtml"
         if (currentUserId != Model.CreatedBy.Id)
            {

            
            #line default
            #line hidden
WriteLiteral("            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1028), Tuple.Create("\"", 1089)
            
            #line 23 "..\..\Views\CompanyConversation\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1035), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.User.Detail(Model.CreatedBy.UserName))
            
            #line default
            #line hidden
, 1035), false)
);

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"post-owner\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\CompanyConversation\_Item.cshtml"
                                  Write($"{Model.CreatedBy.UserName} :");

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </a>\r\n");

            
            #line 26 "..\..\Views\CompanyConversation\_Item.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"post-text\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\CompanyConversation\_Item.cshtml"
                        Write(Model.Body);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        <p");

WriteLiteral(" class=\"post-date\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\CompanyConversation\_Item.cshtml"
                        Write(Model.CreatedOn.CastToRegularDate());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591