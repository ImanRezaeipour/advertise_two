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

namespace Advertise.Web.Views.CompanyQuestion
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
    
    #line 2 "..\..\Views\CompanyQuestion\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\CompanyQuestion\_Item.cshtml"
    using Advertise.Service.Managers.File;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\CompanyQuestion\_Item.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyQuestion/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanyQuestion.CompanyQuestionViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"landing-items nov-item-height-032\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"product-item column landing-column\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"nov-item-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"action-section without-share\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\CompanyQuestion\_Item.cshtml"
                
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\CompanyQuestion\_Item.cshtml"
                 if (User.IsInRole(PermissionConst.CanCompanyQustionEdit) || User.IsInRole(PermissionConst.CanCompanyQustionDeleteAjax)  || User.IsInRole(PermissionConst.CanUserViolationCreate))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"item-edit-wrapper\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-pencil-square\"");

WriteLiteral("></i>\r\n                        <ul");

WriteLiteral(" class=\"item-edit-list\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CompanyQuestion\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyQustionEdit))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1019), Tuple.Create("\"", 1073)
            
            #line 18 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1026), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanyQuestion.Edit(Model.Id))
            
            #line default
            #line hidden
, 1026), false)
);

WriteLiteral(">\r\n                                        <span>");

            
            #line 19 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                         Write(Admin.Edit);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-pencil fa-flip-horizontal\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 23 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 24 "..\..\Views\CompanyQuestion\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyQustionDeleteAjax))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"removeConfirm\"");

WriteLiteral(" data-param=\"");

            
            #line 27 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                      Write(Url.Action(MVC.CompanyQuestion.DeleteAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 28 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                         Write(Admin.Delete);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 32 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 33 "..\..\Views\CompanyQuestion\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanUserViolationCreate))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 37 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                         Write(Admin.Report);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-file-text-o\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 41 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </div>\r\n");

            
            #line 44 "..\..\Views\CompanyQuestion\_Item.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"image-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"product-preview-actions\"");

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"product-preview-image\"");

WriteLiteral(">\r\n                        <a ");

            
            #line 51 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            if (Model.CompanyImageFileName != null) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"");

            
            #line 51 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                              Write(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.Replace(" ","-"))));

            
            #line default
            #line hidden
WriteLiteral("\" ");

WriteLiteral(" ");

            
            #line 51 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                                                                     }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"item-preview-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 2990), Tuple.Create("\"", 3154)
, Tuple.Create(Tuple.Create("", 2996), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                           if (Model.CompanyImageFileName != null) {
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                   WriteTo(__razor_attribute_value_writer, FileConst.ImagesWebPath.PlusWord(Model.CompanyImageFileName));

            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                                              } else {
            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                     WriteTo(__razor_attribute_value_writer, FileConst.NoPreview);

            
            #line default
            #line hidden
            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                                                                                       }
            
            #line default
            #line hidden
}), 2996), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 3155), Tuple.Create("\"", 3180)
            
            #line 53 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                               , Tuple.Create(Tuple.Create("", 3161), Tuple.Create<System.Object, System.Int32>(Model.CompanyTitle
            
            #line default
            #line hidden
, 3161), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"caption-section\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"novinak-title-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3413), Tuple.Create("\"", 3504)
            
            #line 60 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 3420), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.CastToSlug()))
            
            #line default
            #line hidden
, 3420), false)
);

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"novinak-title text-header\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                    Write(Model.Body);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"info-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"top-part\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3726), Tuple.Create("\"", 3817)
            
            #line 66 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 3733), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.CastToSlug()))
            
            #line default
            #line hidden
, 3733), false)
);

WriteLiteral(">\r\n                        <p>");

            
            #line 67 "..\..\Views\CompanyQuestion\_Item.cshtml"
                      Write(Model.CompanyTitle);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"middle-part\"");

WriteLiteral(">\r\n                    <p>\r\n                        <i");

WriteLiteral(" class=\"fa fa-calendar-check-o\"");

WriteLiteral("></i> \r\n                        <span>");

            
            #line 73 "..\..\Views\CompanyQuestion\_Item.cshtml"
                         Write(Admin.InsertDate.PlusWord(":"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"bottom-part\"");

WriteLiteral(">\r\n                    <p>");

            
            #line 77 "..\..\Views\CompanyQuestion\_Item.cshtml"
                  Write(Model.CreatedOn.CastToRegularDate());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-footer\"");

WriteLiteral(">\r\n            <hr");

WriteLiteral(" class=\"line-separator item-footer\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"overview-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"image-part\"");

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"user-avatar small\"");

WriteLiteral(">\r\n                        <a ");

            
            #line 86 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            if (Model.UserAvatar != null) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"");

            
            #line 86 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                    Write(Url.Action(MVC.User.Detail(Model.UserUserName)));

            
            #line default
            #line hidden
WriteLiteral("\" ");

WriteLiteral("   ");

            
            #line 86 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                     }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"novinak-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4808), Tuple.Create("\"", 4954)
, Tuple.Create(Tuple.Create("", 4814), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                           if (Model.UserAvatar != null) {
            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                         WriteTo(__razor_attribute_value_writer, FileConst.ImagesWebPath.PlusWord(Model.UserAvatar));

            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                          } else {
            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                 WriteTo(__razor_attribute_value_writer, FileConst.NoAvatarPth);

            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                                                                     }
            
            #line default
            #line hidden
}), 4814), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 4955), Tuple.Create("\"", 4983)
            
            #line 88 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                             , Tuple.Create(Tuple.Create("", 4961), Tuple.Create<System.Object, System.Int32>(Model.UserDisplayName
            
            #line default
            #line hidden
, 4961), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"caption-part\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 5174), Tuple.Create("\"", 5229)
            
            #line 94 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 5181), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.User.Detail(Model.UserUserName))
            
            #line default
            #line hidden
, 5181), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5250), Tuple.Create("\"", 5280)
            
            #line 94 "..\..\Views\CompanyQuestion\_Item.cshtml"
                          , Tuple.Create(Tuple.Create("", 5258), Tuple.Create<System.Object, System.Int32>(Model.UserDisplayName
            
            #line default
            #line hidden
, 5258), false)
);

WriteLiteral(">\r\n                        <p");

WriteLiteral(" class=\"text-header tiny\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                               Write(Model.UserFullName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n     " +
"       <div");

WriteLiteral(" class=\"toggle-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"likes-wrapper\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5558), Tuple.Create("\"", 5575)
            
            #line 101 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 5566), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 5566), false)
);

WriteLiteral(" name=\"commentId\"");

WriteLiteral(" id=\"commentId\"");

WriteLiteral(" />\r\n                    <p");

WriteLiteral(" class=\"product-detail-eh detail-heart tooltip\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5682), Tuple.Create("\"", 5702)
            
            #line 102 "..\..\Views\CompanyQuestion\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 5690), Tuple.Create<System.Object, System.Int32>(Admin.Likes
            
            #line default
            #line hidden
, 5690), false)
);

WriteLiteral(">\r\n                        <a ");

            
            #line 103 "..\..\Views\CompanyQuestion\_Item.cshtml"
                            if (User.Identity.IsAuthenticated) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"javascript:void(0)\"  ");

WriteLiteral("   ");

            
            #line 103 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                             } else {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"");

            
            #line 103 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                              Write(Url.Action(MVC.Account.EmailRegister()));

            
            #line default
            #line hidden
WriteLiteral("\" ");

WriteLiteral("   ");

            
            #line 103 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                                                                                       }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                            <i");

WriteAttribute("class", Tuple.Create(" class=\"", 5923), Tuple.Create("\"", 6009)
, Tuple.Create(Tuple.Create("", 5931), Tuple.Create("fa", 5931), true)
, Tuple.Create(Tuple.Create(" ", 5933), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 104 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                          if (Model.InitLike) {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "fa-heart");

            
            #line 104 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                    } else {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "fa-heart-o");

            
            #line 104 "..\..\Views\CompanyQuestion\_Item.cshtml"
                                                                                                                   }
            
            #line default
            #line hidden
}), 5934), false)
);

WriteLiteral("></i>\r\n                            <span>");

            
            #line 105 "..\..\Views\CompanyQuestion\_Item.cshtml"
                             Write(Model.LikeCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </a>\r\n                    </p>\r\n                " +
"    <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral("></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div" +
"");

WriteLiteral(" class=\"clearboth\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
