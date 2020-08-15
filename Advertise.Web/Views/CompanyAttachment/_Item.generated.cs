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

namespace Advertise.Web.Views.CompanyAttachment
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
    
    #line 2 "..\..\Views\CompanyAttachment\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\CompanyAttachment\_Item.cshtml"
    using Advertise.Service.Managers.File;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\CompanyAttachment\_Item.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanyAttachment/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanyAttachment.CompanyAttachmentViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteAttribute("class", Tuple.Create(" class=\"", 252), Tuple.Create("\"", 345)
, Tuple.Create(Tuple.Create("", 260), Tuple.Create("landing-items", 260), true)
            
            #line 6 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create(" ", 273), Tuple.Create<System.Object, System.Int32>(Model.IsMine != true ? "nov-item-height-031" : "nov-item-height-030"
            
            #line default
            #line hidden
, 274), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"product-item column landing-column\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"nov-item-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"action-section without-share\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\CompanyAttachment\_Item.cshtml"
                
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\CompanyAttachment\_Item.cshtml"
                 if (User.IsInRole(PermissionConst.CanCompanyAttachmentEdit) || (Model.IsMine && User.IsInRole(PermissionConst.CanCompanyAttachmentMyEdit)) || User.IsInRole(PermissionConst.CanCompanyAttachmentDeleteAjax) || (Model.IsMine && User.IsInRole(PermissionConst.CanCompanyAttachmentMyDeleteAjax)) || User.IsInRole(PermissionConst.CanCompanyAttachmentEditApprove))
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

            
            #line 15 "..\..\Views\CompanyAttachment\_Item.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CompanyAttachment\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyAttachmentEdit) || (Model.IsMine && User.IsInRole(PermissionConst.CanCompanyAttachmentMyEdit)))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1335), Tuple.Create("\"", 1461)
            
            #line 18 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1342), Tuple.Create<System.Object, System.Int32>(Model.IsMine ? Url.Action(MVC.CompanyAttachment.MyEdit(Model.Id)) : Url.Action(MVC.CompanyAttachment.Edit(Model.Id))
            
            #line default
            #line hidden
, 1342), false)
);

WriteLiteral(">\r\n                                        <span>");

            
            #line 19 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                         Write(Admin.Edit);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-pencil fa-flip-horizontal\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 23 "..\..\Views\CompanyAttachment\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 24 "..\..\Views\CompanyAttachment\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyAttachmentDeleteAjax) || (Model.IsMine && User.IsInRole(PermissionConst.CanCompanyAttachmentMyDeleteAjax)))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"removeConfirm\"");

WriteLiteral(" data-param=\"");

            
            #line 27 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                                                       Write(Model.IsMine ? Url.Action(MVC.CompanyAttachment.MyDeleteAjax(Model.Id)) : Url.Action(MVC.CompanyAttachment.DeleteAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 28 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                         Write(Admin.Delete);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 32 "..\..\Views\CompanyAttachment\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 33 "..\..\Views\CompanyAttachment\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyAttachmentEditApprove))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"ajaxSimple\"");

WriteLiteral(" data-param=\"");

            
            #line 36 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                                                   Write(Url.Action(MVC.CompanyAttachment.ApproveAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 37 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                         Write(Admin.Approve);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-check-circle\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 41 "..\..\Views\CompanyAttachment\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 42 "..\..\Views\CompanyAttachment\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanCompanyAttachmentEditApprove))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"ajaxSimple\"");

WriteLiteral(" data-param=\"");

            
            #line 45 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                                                   Write(Url.Action(MVC.CompanyAttachment.RejectAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 46 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                         Write(Admin.Ignore);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-times-circle\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 50 "..\..\Views\CompanyAttachment\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </div>\r\n");

            
            #line 53 "..\..\Views\CompanyAttachment\_Item.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n            <div");

WriteLiteral(" class=\"rectangle-section\"");

WriteLiteral(">\r\n                <span>\r\n                    <span>");

            
            #line 57 "..\..\Views\CompanyAttachment\_Item.cshtml"
                     Write(Model.AttachmentFiles.Count());

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\CompanyAttachment\_Item.cshtml"
               Write(Admin.File2);

            
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

WriteAttribute("href", Tuple.Create(" href=\"", 4194), Tuple.Create("\"", 4252)
            
            #line 66 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4201), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanyAttachment.Detail(Model.Id))
            
            #line default
            #line hidden
, 4201), false)
);

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"item-preview-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 4354), Tuple.Create("\"", 4381)
            
            #line 68 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4360), Tuple.Create<System.Object, System.Int32>(FileConst.Attachment
            
            #line default
            #line hidden
, 4360), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 4382), Tuple.Create("\"", 4444)
            
            #line 68 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4388), Tuple.Create<System.Object, System.Int32>(Model.Title.PlusWord(" ").PlusWord(Admin.ListAttachmnt)
            
            #line default
            #line hidden
, 4388), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"caption-section\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"novinak-title-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4677), Tuple.Create("\"", 4735)
            
            #line 75 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 4684), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanyAttachment.Detail(Model.Id))
            
            #line default
            #line hidden
, 4684), false)
);

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"novinak-title text-header\"");

WriteLiteral(">");

            
            #line 76 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                    Write(Model.Title);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"info-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"top-part\"");

WriteLiteral(">\r\n                    <a>\r\n                        <p>");

            
            #line 82 "..\..\Views\CompanyAttachment\_Item.cshtml"
                      Write(Admin.Priority.PlusWord(": ").PlusWord(Model.Order.ToString()));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"middle-part\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"small-state\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-calendar-check-o\"");

WriteLiteral("></i> \r\n                        <span>");

            
            #line 88 "..\..\Views\CompanyAttachment\_Item.cshtml"
                         Write(Admin.InsertDate.PlusWord(":"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"bottom-part\"");

WriteLiteral(">\r\n                    <p>");

            
            #line 92 "..\..\Views\CompanyAttachment\_Item.cshtml"
                  Write(Model.CreatedOn.CastToRegularDate());

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-footer\"");

WriteLiteral(">\r\n");

            
            #line 97 "..\..\Views\CompanyAttachment\_Item.cshtml"
            
            
            #line default
            #line hidden
            
            #line 97 "..\..\Views\CompanyAttachment\_Item.cshtml"
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

WriteLiteral(">\r\n                            <a");

WriteAttribute("href", Tuple.Create("  href=\"", 5883), Tuple.Create("\"", 6006)
, Tuple.Create(Tuple.Create("", 5891), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 103 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                       if (Model.CompanyLogoFileName != null) {
            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                         WriteTo(__razor_attribute_value_writer, Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle)));

            
            #line default
            #line hidden
            
            #line 103 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                                                                                                        }
            
            #line default
            #line hidden
}), 5891), false)
);

WriteLiteral("}>\r\n                                <div");

WriteLiteral(" class=\"novinak-image\"");

WriteLiteral(">\r\n                                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 6112), Tuple.Create("\"", 6235)
            
            #line 105 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 6118), Tuple.Create<System.Object, System.Int32>(Model.CompanyLogoFileName != null ? FileConst.ImagesWebPath.PlusWord(Model.CompanyLogoFileName) : FileConst.NoLogo
            
            #line default
            #line hidden
, 6118), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 6236), Tuple.Create("\"", 6297)
            
            #line 105 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                                          , Tuple.Create(Tuple.Create("", 6242), Tuple.Create<System.Object, System.Int32>(Model.Title.PlusWord(" ").PlusWord(Model.CompanyTitle)
            
            #line default
            #line hidden
, 6242), false)
);

WriteLiteral(">\r\n                                </div>\r\n                            </a>\r\n    " +
"                    </figure>\r\n                    </div>\r\n                    <" +
"div");

WriteLiteral(" class=\"caption-part\"");

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 6512), Tuple.Create("\"", 6603)
            
            #line 111 "..\..\Views\CompanyAttachment\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 6519), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Company.Detail(Model.CompanyAlias, Model.CompanyTitle.CastToSlug()))
            
            #line default
            #line hidden
, 6519), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 6624), Tuple.Create("\"", 6651)
            
            #line 111 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                                  , Tuple.Create(Tuple.Create("", 6632), Tuple.Create<System.Object, System.Int32>(Model.CompanyTitle
            
            #line default
            #line hidden
, 6632), false)
);

WriteLiteral(">\r\n                            <p");

WriteLiteral(" class=\"text-header tiny\"");

WriteLiteral(">");

            
            #line 112 "..\..\Views\CompanyAttachment\_Item.cshtml"
                                                   Write(Model.CompanyTitle);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                        </a>\r\n                    </div>\r\n                <" +
"/div>\r\n");

            
            #line 116 "..\..\Views\CompanyAttachment\_Item.cshtml"
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