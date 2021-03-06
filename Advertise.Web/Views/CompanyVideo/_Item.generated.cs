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

namespace Advertise.Web.Views.CompanyVideo
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
    
    #line 2 "..\..\Views\CompanyVideo\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\CompanyVideo\_Item.cshtml"
    using Advertise.Service.Managers.File;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    
    #line 4 "..\..\Views\CompanyVideo\_Item.cshtml"
    using Auth = Advertise.Service.Services.Permissions.PermissionConst;
    
    #line default
    #line hidden
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyVideo/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanyVideo.CompanyVideoViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteAttribute("class", Tuple.Create(" class=\"", 266), Tuple.Create("\"", 359)
, Tuple.Create(Tuple.Create("", 274), Tuple.Create("landing-items", 274), true)
            
            #line 6 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create(" ", 287), Tuple.Create<System.Object, System.Int32>(Model.IsMine != true ? "nov-item-height-031" : "nov-item-height-030"
            
            #line default
            #line hidden
, 288), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"product-item column landing-column\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"nov-item-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"action-section without-share\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\CompanyVideo\_Item.cshtml"
                
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\CompanyVideo\_Item.cshtml"
                 if (User.IsInRole(Auth.CanCompanyVideoEdit) || User.IsInRole(Auth.CanCompanyVideoMyEdit) || User.IsInRole(Auth.CanCompanyVideoDeleteAjax) || User.IsInRole(Auth.CanCompanyVideoMyDeleteAjax) || User.IsInRole(Auth.CanCompanyVideoEditApprove) || User.IsInRole(Auth.CanCompanyVideoEditReject))
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

            
            #line 15 "..\..\Views\CompanyVideo\_Item.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CompanyVideo\_Item.cshtml"
                             if (User.IsInRole(Auth.CanCompanyVideoMyEdit) || User.IsInRole(Auth.CanCompanyVideoEdit))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1232), Tuple.Create("\"", 1348)
            
            #line 18 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1239), Tuple.Create<System.Object, System.Int32>(Model.IsMine ? Url.Action(MVC.CompanyVideo.MyEdit(Model.Id)) : Url.Action(MVC.CompanyVideo.Edit(Model.Id))
            
            #line default
            #line hidden
, 1239), false)
);

WriteLiteral(">\r\n                                        <span>");

            
            #line 19 "..\..\Views\CompanyVideo\_Item.cshtml"
                                         Write(Admin.Edit);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-pencil fa-flip-horizontal\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 23 "..\..\Views\CompanyVideo\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 24 "..\..\Views\CompanyVideo\_Item.cshtml"
                             if (User.IsInRole(Auth.CanCompanyVideoDeleteAjax) || User.IsInRole(Auth.CanCompanyVideoMyDeleteAjax))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"removeConfirm\"");

WriteLiteral(" data-param=\"");

            
            #line 27 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                       Write(Model.IsMine ? Url.Action(MVC.CompanyVideo.MyDeleteAjax(Model.Id)) : Url.Action(MVC.CompanyVideo.DeleteAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 28 "..\..\Views\CompanyVideo\_Item.cshtml"
                                         Write(Admin.Delete);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 32 "..\..\Views\CompanyVideo\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 33 "..\..\Views\CompanyVideo\_Item.cshtml"
                             if (User.IsInRole(Auth.CanCompanyVideoEditApprove))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"ajaxSimple\"");

WriteLiteral(" data-param=\"");

            
            #line 36 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                   Write(Url.Action(MVC.CompanyVideo.ApproveAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 37 "..\..\Views\CompanyVideo\_Item.cshtml"
                                         Write(Admin.Approve);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-check-circle\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 41 "..\..\Views\CompanyVideo\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 42 "..\..\Views\CompanyVideo\_Item.cshtml"
                             if (User.IsInRole(Auth.CanCompanyVideoEditReject))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"ajaxSimple\"");

WriteLiteral(" data-param=\"");

            
            #line 45 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                   Write(Url.Action(MVC.CompanyVideo.RejectAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 46 "..\..\Views\CompanyVideo\_Item.cshtml"
                                         Write(Admin.Ignore);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-times-circle\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 50 "..\..\Views\CompanyVideo\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </div>\r\n");

            
            #line 53 "..\..\Views\CompanyVideo\_Item.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n            <div");

WriteLiteral(" class=\"rectangle-section\"");

WriteLiteral(">\r\n                <span>\r\n                    <span>");

            
            #line 57 "..\..\Views\CompanyVideo\_Item.cshtml"
                     Write(Model.VideoFiles.Count);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\CompanyVideo\_Item.cshtml"
               Write(Admin.Video2);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </span>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"image-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"product-preview-actions\"");

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"product-preview-image\"");

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3972), Tuple.Create("\"", 4054)
            
            #line 66 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 3979), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanyVideo.Detail(Model.Id,Model.Title.Replace(" ","-")))
            
            #line default
            #line hidden
, 3979), false)
);

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"item-preview-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4156), Tuple.Create("\"", 4178)
            
            #line 68 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4162), Tuple.Create<System.Object, System.Int32>(FileConst.Video
            
            #line default
            #line hidden
, 4162), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 4179), Tuple.Create("\"", 4241)
            
            #line 68 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4185), Tuple.Create<System.Object, System.Int32>(Model.Title.PlusWord(" ").PlusWord(Admin.GalleryVideos)
            
            #line default
            #line hidden
, 4185), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"caption-section\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"novinak-title-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4474), Tuple.Create("\"", 4556)
            
            #line 75 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4481), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanyVideo.Detail(Model.Id,Model.Title.Replace(" ","-")))
            
            #line default
            #line hidden
, 4481), false)
);

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"novinak-title text-header\"");

WriteLiteral(">");

            
            #line 76 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                    Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"info-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"top-part\"");

WriteLiteral(">\r\n                    <a>\r\n                        <p>");

            
            #line 82 "..\..\Views\CompanyVideo\_Item.cshtml"
                      Write(Admin.Priority.PlusWord(": ").PlusWord(Model.Order.ToString()));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"middle-part\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"small-state\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-calendar-check-o\"");

WriteLiteral("></i> \r\n                        <span>");

            
            #line 87 "..\..\Views\CompanyVideo\_Item.cshtml"
                         Write(Admin.InsertDate.PlusWord(":"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"bottom-part\"");

WriteLiteral(">\r\n                    <p>");

            
            #line 91 "..\..\Views\CompanyVideo\_Item.cshtml"
                  Write(Model.CreatedOn.CastToRegularDate());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-footer\"");

WriteLiteral(">\r\n");

            
            #line 96 "..\..\Views\CompanyVideo\_Item.cshtml"
            
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\CompanyVideo\_Item.cshtml"
             if (Model.IsMine != true)
            {

            
            #line default
            #line hidden
WriteLiteral("                <hr");

WriteLiteral(" class=\"line-separator item-footer\"");

WriteLiteral(">\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\"overview-section\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"image-part\"");

WriteLiteral(">\r\n                        <figure");

WriteLiteral(" class=\"user-avatar small\"");

WriteLiteral(">\r\n                            <a ");

            
            #line 102 "..\..\Views\CompanyVideo\_Item.cshtml"
                                if (Model.CompanyLogoFileName != null) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"");

            
            #line 102 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                 Write(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.Replace(" ","-"))));

            
            #line default
            #line hidden
WriteLiteral("\" ");

WriteLiteral("  ");

            
            #line 102 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                                                                                                         }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"novinak-image\"");

WriteLiteral(">\r\n                                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 5938), Tuple.Create("\"", 6097)
, Tuple.Create(Tuple.Create("", 5944), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                               if (Model.CompanyLogoFileName != null) {
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                      WriteTo(__razor_attribute_value_writer, FileConst.ImagesWebPath.PlusWord(Model.CompanyLogoFileName));

            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                                                                                } else {
            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                                                       WriteTo(__razor_attribute_value_writer, FileConst.NoLogo);

            
            #line default
            #line hidden
            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                                                                                                                      }
            
            #line default
            #line hidden
}), 5944), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 6098), Tuple.Create("\"", 6159)
            
            #line 104 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                                                                              , Tuple.Create(Tuple.Create("", 6104), Tuple.Create<System.Object, System.Int32>(Model.Title.PlusWord(" ").PlusWord(Model.CompanyTitle)
            
            #line default
            #line hidden
, 6104), false)
);

WriteLiteral(">\r\n                                </div>\r\n                            </a>\r\n    " +
"                    </figure>\r\n                    </div>\r\n                    <" +
"div");

WriteLiteral(" class=\"caption-part\"");

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6374), Tuple.Create("\"", 6469)
            
            #line 110 "..\..\Views\CompanyVideo\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 6381), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.Replace(" ","-")))
            
            #line default
            #line hidden
, 6381), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 6490), Tuple.Create("\"", 6517)
            
            #line 110 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 6498), Tuple.Create<System.Object, System.Int32>(Model.CompanyTitle
            
            #line default
            #line hidden
, 6498), false)
);

WriteLiteral(">\r\n                            <p");

WriteLiteral(" class=\"text-header tiny\"");

WriteLiteral(">");

            
            #line 111 "..\..\Views\CompanyVideo\_Item.cshtml"
                                                   Write(Model.CompanyTitle);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </a>\r\n                    </div>\r\n                <" +
"/div>\r\n");

            
            #line 115 "..\..\Views\CompanyVideo\_Item.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"clearboth\"");

WriteLiteral("></div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
