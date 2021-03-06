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

namespace Advertise.Web.Views.UserViolation
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
    
    #line 2 "..\..\Views\UserViolation\_Item.cshtml"
    using Advertise.Core.Extensions;
    
    #line default
    #line hidden
    using Advertise.Core.Languages;
    
    #line 3 "..\..\Views\UserViolation\_Item.cshtml"
    using Advertise.Service.Managers.File;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\UserViolation\_Item.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/UserViolation/_Item.cshtml")]
    public partial class _Item : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.UserViolation.UserViolationViewModel>
    {
        public _Item()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"landing-items nov-item-height-031\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"product-item column landing-column\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"nov-item-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"action-section without-share\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\UserViolation\_Item.cshtml"
                
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\UserViolation\_Item.cshtml"
                 if (User.IsInRole(PermissionConst.CanUserViolationDeleteAjax))
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

            
            #line 15 "..\..\Views\UserViolation\_Item.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\UserViolation\_Item.cshtml"
                             if (User.IsInRole(PermissionConst.CanUserViolationDeleteAjax))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li>\r\n                                    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(" data-on-click=\"removeConfirm\"");

WriteLiteral(" data-param=\"");

            
            #line 18 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                      Write(Url.Action(MVC.UserViolation.DeleteAjax(Model.Id)));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                        <span>");

            
            #line 19 "..\..\Views\UserViolation\_Item.cshtml"
                                         Write(Admin.Delete);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                        <i");

WriteLiteral(" class=\"fa fa-trash\"");

WriteLiteral("></i>\r\n                                    </a>\r\n                                " +
"</li>\r\n");

            
            #line 23 "..\..\Views\UserViolation\_Item.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </div>\r\n");

            
            #line 26 "..\..\Views\UserViolation\_Item.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n            <div");

WriteLiteral(" class=\"rectangle-section\"");

WriteLiteral(">\r\n                <span>");

            
            #line 29 "..\..\Views\UserViolation\_Item.cshtml"
                 Write(Model.Type);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"nov-item-body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"image-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"product-preview-actions\"");

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"product-preview-image\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral("  data-on-click=\"openShadow\"");

WriteLiteral(" data-type=\"modal\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"item-preview-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1891), Tuple.Create("\"", 1914)
            
            #line 38 "..\..\Views\UserViolation\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1897), Tuple.Create<System.Object, System.Int32>(FileConst.Report
            
            #line default
            #line hidden
, 1897), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 1915), Tuple.Create("\"", 1934)
            
            #line 38 "..\..\Views\UserViolation\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 1921), Tuple.Create<System.Object, System.Int32>(Admin.Report
            
            #line default
            #line hidden
, 1921), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"caption-section\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"novinak-title-link\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral("  data-on-click=\"openShadow\"");

WriteLiteral(" data-type=\"modal\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"novinak-title text-header\"");

WriteLiteral(">");

            
            #line 46 "..\..\Views\UserViolation\_Item.cshtml"
                                                    Write(Model.Reason);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                </a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"info-section\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"top-part\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2462), Tuple.Create("\"", 2519)
            
            #line 51 "..\..\Views\UserViolation\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 2469), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.User.Detail(Model.TargetUserName))
            
            #line default
            #line hidden
, 2469), false)
);

WriteLiteral(">\r\n                        <p>");

            
            #line 52 "..\..\Views\UserViolation\_Item.cshtml"
                      Write(Admin.ReportedPerson.PlusWord(": ").PlusWord(Model.TargetFullName));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"middle-part\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"small-state\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-calendar-check-o\"");

WriteLiteral("></i> <span>");

            
            #line 56 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                   Write(Admin.InsertDate.PlusWord(":"));

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"bottom-part\"");

WriteLiteral(">\r\n                    <p>");

            
            #line 59 "..\..\Views\UserViolation\_Item.cshtml"
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

            
            #line 68 "..\..\Views\UserViolation\_Item.cshtml"
                            if (Model.UserAvatar != null) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" href=\"");

            
            #line 68 "..\..\Views\UserViolation\_Item.cshtml"
                                                                    Write(Url.Action(MVC.User.Detail(Model.UserUserName)));

            
            #line default
            #line hidden
WriteLiteral("\" ");

WriteLiteral(" ");

            
            #line 68 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                                                   }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"novinak-image\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3502), Tuple.Create("\"", 3648)
, Tuple.Create(Tuple.Create("", 3508), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                           if (Model.UserAvatar != null) {
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                         WriteTo(__razor_attribute_value_writer, FileConst.ImagesWebPath.PlusWord(Model.UserAvatar));

            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                                                          } else {
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                                 WriteTo(__razor_attribute_value_writer, FileConst.NoAvatarPth);

            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                                                                                                     }
            
            #line default
            #line hidden
}), 3508), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 3649), Tuple.Create("\"", 3709)
            
            #line 70 "..\..\Views\UserViolation\_Item.cshtml"
                                                                                                             , Tuple.Create(Tuple.Create("", 3655), Tuple.Create<System.Object, System.Int32>(Model.UserFullName.PlusWord(" ").PlusWord(Admin.User)
            
            #line default
            #line hidden
, 3655), false)
);

WriteLiteral(">\r\n                            </div>\r\n                        </a>\r\n            " +
"        </figure>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"caption-part\"");

WriteLiteral(">\r\n                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3900), Tuple.Create("\"", 3955)
            
            #line 76 "..\..\Views\UserViolation\_Item.cshtml"
, Tuple.Create(Tuple.Create("", 3907), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.User.Detail(Model.UserUserName))
            
            #line default
            #line hidden
, 3907), false)
);

WriteLiteral(">\r\n                        <p");

WriteLiteral(" class=\"text-header tiny\"");

WriteLiteral(">");

            
            #line 77 "..\..\Views\UserViolation\_Item.cshtml"
                                               Write(Model.UserFullName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n     " +
"   </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"bg-shadow\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" class=\"slider-shadow\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"slide-file-preview\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"inner-preview\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"modal-item-title\"");

WriteLiteral(">");

            
            #line 87 "..\..\Views\UserViolation\_Item.cshtml"
                                        Write(Model.Reason);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n                <h5");

WriteLiteral(" class=\"modal-item-content\"");

WriteLiteral(">");

            
            #line 88 "..\..\Views\UserViolation\_Item.cshtml"
                                          Write(Model.ReasonDescription);

            
            #line default
            #line hidden
WriteLiteral("</h5>\r\n                <div");

WriteLiteral(" class=\"slide-files-actions\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"slide-action-wrapper slide-file-close\"");

WriteLiteral("  data-on-click=\"closeShadow\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-times\"");

WriteLiteral("></i>\r\n                        <i");

WriteLiteral(" class=\"fa fa-times\"");

WriteLiteral("></i>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n  " +
"      </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"clearboth\"");

WriteLiteral("></div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
