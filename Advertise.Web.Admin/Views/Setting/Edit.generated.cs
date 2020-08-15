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

namespace Advertise.Web.Views.Setting
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Setting/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Setting.SettingEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Setting\Edit.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = "تنظیمات سایت";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>تنظیمات سایت</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"editSetting\"");

WriteAttribute("action", Tuple.Create(" action=\"", 413), Tuple.Create("\"", 453)
            
            #line 12 "..\..\Views\Setting\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 422), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Setting.Edit())
            
            #line default
            #line hidden
, 422), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\Setting\Edit.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"Id\"");

WriteLiteral(" name=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 559), Tuple.Create("\"", 576)
            
            #line 14 "..\..\Views\Setting\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 567), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 567), false)
);

WriteLiteral("/>\r\n            \r\n            <div");

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

WriteLiteral(" for=\"SiteTitle\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">عنوان سایت</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteTitle\"");

WriteLiteral(" name=\"SiteTitle\"");

WriteLiteral(" placeholder=\"عنوان سایت\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1333), Tuple.Create("\"", 1357)
            
            #line 30 "..\..\Views\Setting\Edit.cshtml"
                       , Tuple.Create(Tuple.Create("", 1341), Tuple.Create<System.Object, System.Int32>(Model.SiteTitle
            
            #line default
            #line hidden
, 1341), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"عنوان سایت\"");

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

WriteLiteral(" for=\"SiteShortTitle\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">عنوان مختصر سایت</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteShortTitle\"");

WriteLiteral(" name=\"SiteShortTitle\"");

WriteLiteral(" placeholder=\"عنوان مختصر سایت\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2099), Tuple.Create("\"", 2128)
            
            #line 44 "..\..\Views\Setting\Edit.cshtml"
                                       , Tuple.Create(Tuple.Create("", 2107), Tuple.Create<System.Object, System.Int32>(Model.SiteShortTitle
            
            #line default
            #line hidden
, 2107), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"عنوان مختصر سایت\"");

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

WriteLiteral(" for=\"SiteVersion\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">نسخه سایت</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteVersion\"");

WriteLiteral(" name=\"SiteVersion\"");

WriteLiteral(" placeholder=\"نسخه سایت\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2853), Tuple.Create("\"", 2879)
            
            #line 58 "..\..\Views\Setting\Edit.cshtml"
                          , Tuple.Create(Tuple.Create("", 2861), Tuple.Create<System.Object, System.Int32>(Model.SiteVersion
            
            #line default
            #line hidden
, 2861), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"نسخه سایت\"");

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

WriteLiteral(" for=\"SiteDescription\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">توضیحات سایت</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteDescription\"");

WriteLiteral(" name=\"SiteDescription\"");

WriteLiteral(" placeholder=\"توضیحات سایت\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3615), Tuple.Create("\"", 3645)
            
            #line 72 "..\..\Views\Setting\Edit.cshtml"
                                     , Tuple.Create(Tuple.Create("", 3623), Tuple.Create<System.Object, System.Int32>(Model.SiteDescription
            
            #line default
            #line hidden
, 3623), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"توضیحات سایت\"");

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

WriteLiteral(" for=\"IsDefaultAvatarEnabled\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آیا آواتار پیشفرض فعال است</label>\r\n                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"IsDefaultAvatarEnabled\"");

WriteLiteral(" name=\"IsDefaultAvatarEnabled\"");

WriteLiteral(" ");

            
            #line 86 "..\..\Views\Setting\Edit.cshtml"
                                                                                                      if (Model.IsDefaultAvatarEnabled){
            
            #line default
            #line hidden
WriteLiteral(" checked");

            
            #line 86 "..\..\Views\Setting\Edit.cshtml"
                                                                                                                                                             }
            
            #line default
            #line hidden
WriteLiteral(" placeholder=\"آیا آواتار پیشفرض فعال است\" class=\"tooltipster\" title=\"آیا آواتار پ" +
"یشفرض فعال است\"/>\r\n                </div>\r\n                \r\n                <di" +
"v");

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

WriteLiteral(" for=\"IsAllowViewingProfiles\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آیا پروفایل ها قابل مشاهده باشد</label>\r\n                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"IsAllowViewingProfiles\"");

WriteLiteral(" name=\"IsAllowViewingProfiles\"");

WriteLiteral(" ");

            
            #line 100 "..\..\Views\Setting\Edit.cshtml"
                                                                                                      if (Model.IsAllowViewingProfiles){
            
            #line default
            #line hidden
WriteLiteral(" checked");

            
            #line 100 "..\..\Views\Setting\Edit.cshtml"
                                                                                                                                                             }
            
            #line default
            #line hidden
WriteLiteral(" placeholder=\"آیا پروفایل ها قابل مشاهده باشد\" class=\"tooltipster\" title=\"آیا پرو" +
"فایل ها قابل مشاهده باشد\"/>\r\n                </div>\r\n                \r\n         " +
"       <div");

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

WriteLiteral(" for=\"FacebookPageUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس فیسبوک</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"FacebookPageUrl\"");

WriteLiteral(" name=\"FacebookPageUrl\"");

WriteLiteral(" placeholder=\"آدرس فیسبوک\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6123), Tuple.Create("\"", 6153)
            
            #line 114 "..\..\Views\Setting\Edit.cshtml"
                                    , Tuple.Create(Tuple.Create("", 6131), Tuple.Create<System.Object, System.Int32>(Model.FacebookPageUrl
            
            #line default
            #line hidden
, 6131), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس فیسبوک\"");

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

WriteLiteral(" for=\"GooglePlusPageUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس گوگل پلاس</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"GooglePlusPageUrl\"");

WriteLiteral(" name=\"GooglePlusPageUrl\"");

WriteLiteral(" placeholder=\"آدرس گوگل پلاس\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6901), Tuple.Create("\"", 6933)
            
            #line 128 "..\..\Views\Setting\Edit.cshtml"
                                           , Tuple.Create(Tuple.Create("", 6909), Tuple.Create<System.Object, System.Int32>(Model.GooglePlusPageUrl
            
            #line default
            #line hidden
, 6909), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس گوگل پلاس\"");

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

WriteLiteral(" for=\"InstagramPageUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس اینستاگرام</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"InstagramPageUrl\"");

WriteLiteral(" name=\"InstagramPageUrl\"");

WriteLiteral(" placeholder=\"آدرس اینستاگرام\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7683), Tuple.Create("\"", 7714)
            
            #line 142 "..\..\Views\Setting\Edit.cshtml"
                                          , Tuple.Create(Tuple.Create("", 7691), Tuple.Create<System.Object, System.Int32>(Model.InstagramPageUrl
            
            #line default
            #line hidden
, 7691), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس اینستاگرام\"");

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

WriteLiteral(" for=\"LinkedinPageUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس لینکداین</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"LinkedinPageUrl\"");

WriteLiteral(" name=\"LinkedinPageUrl\"");

WriteLiteral(" placeholder=\"آدرس لینکداین\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8458), Tuple.Create("\"", 8488)
            
            #line 156 "..\..\Views\Setting\Edit.cshtml"
                                      , Tuple.Create(Tuple.Create("", 8466), Tuple.Create<System.Object, System.Int32>(Model.LinkedinPageUrl
            
            #line default
            #line hidden
, 8466), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس لینکداین\"");

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

WriteLiteral(" for=\"TelegramPageUrl\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس تلگرام</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"TelegramPageUrl\"");

WriteLiteral(" name=\"TelegramPageUrl\"");

WriteLiteral(" placeholder=\"آدرس تلگرام\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9226), Tuple.Create("\"", 9256)
            
            #line 170 "..\..\Views\Setting\Edit.cshtml"
                                    , Tuple.Create(Tuple.Create("", 9234), Tuple.Create<System.Object, System.Int32>(Model.TelegramPageUrl
            
            #line default
            #line hidden
, 9234), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس تلگرام\"");

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

WriteLiteral(" for=\"SiteEmail\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">آدرس ایمیل</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SiteEmail\"");

WriteLiteral(" name=\"SiteEmail\"");

WriteLiteral(" placeholder=\"آدرس ایمیل\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9972), Tuple.Create("\"", 9996)
            
            #line 184 "..\..\Views\Setting\Edit.cshtml"
                       , Tuple.Create(Tuple.Create("", 9980), Tuple.Create<System.Object, System.Int32>(Model.SiteEmail
            
            #line default
            #line hidden
, 9980), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" title=\"آدرس ایمیل\"");

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"editSetting\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 195 "..\..\Views\Setting\Edit.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
