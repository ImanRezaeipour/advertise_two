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

namespace Advertise.Web.Views.CompanySocial
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanySocial/Create.cshtml")]
    public partial class Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanySocial.CompanySocialCreateViewModel>
    {
        public Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\CompanySocial\Create.cshtml"
  
    Layout = MVC.Shared.Views._ProfileLayout;
    ViewBag.Title = Admin.CreateSocialNetworks;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"profile-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\CompanySocial\Create.cshtml"
       Write(Admin.CreateSocialNetworks);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newCompanySocial\"");

WriteAttribute("action", Tuple.Create(" action=\"", 461), Tuple.Create("\"", 509)
            
            #line 12 "..\..\Views\CompanySocial\Create.cshtml"
, Tuple.Create(Tuple.Create("", 470), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanySocial.Create())
            
            #line default
            #line hidden
, 470), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\CompanySocial\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 14 "..\..\Views\CompanySocial\Create.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <div");

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

WriteLiteral(" for=\"FacebookLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\CompanySocial\Create.cshtml"
                                                          Write(Admin.Facebook);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"FacebookLink\"");

WriteLiteral(" name=\"FacebookLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 1333), Tuple.Create("\"", 1362)
            
            #line 30 "..\..\Views\CompanySocial\Create.cshtml"
          , Tuple.Create(Tuple.Create("", 1347), Tuple.Create<System.Object, System.Int32>(Admin.Facebook
            
            #line default
            #line hidden
, 1347), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1383), Tuple.Create("\"", 1413)
            
            #line 30 "..\..\Views\CompanySocial\Create.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 1391), Tuple.Create<System.Object, System.Int32>(Admin.FacebookAccount
            
            #line default
            #line hidden
, 1391), false)
);

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

WriteLiteral(" for=\"InstagramLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\CompanySocial\Create.cshtml"
                                                           Write(Admin.Instagram);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"InstagramLink\"");

WriteLiteral(" name=\"InstagramLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 2082), Tuple.Create("\"", 2112)
            
            #line 44 "..\..\Views\CompanySocial\Create.cshtml"
            , Tuple.Create(Tuple.Create("", 2096), Tuple.Create<System.Object, System.Int32>(Admin.Instagram
            
            #line default
            #line hidden
, 2096), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 2133), Tuple.Create("\"", 2164)
            
            #line 44 "..\..\Views\CompanySocial\Create.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 2141), Tuple.Create<System.Object, System.Int32>(Admin.InstagramAccount
            
            #line default
            #line hidden
, 2141), false)
);

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

WriteLiteral(" for=\"TelegramLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 57 "..\..\Views\CompanySocial\Create.cshtml"
                                                          Write(Admin.Telegram);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"TelegramLink\"");

WriteLiteral(" name=\"TelegramLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 2829), Tuple.Create("\"", 2858)
            
            #line 58 "..\..\Views\CompanySocial\Create.cshtml"
          , Tuple.Create(Tuple.Create("", 2843), Tuple.Create<System.Object, System.Int32>(Admin.Telegram
            
            #line default
            #line hidden
, 2843), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 2879), Tuple.Create("\"", 2909)
            
            #line 58 "..\..\Views\CompanySocial\Create.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 2887), Tuple.Create<System.Object, System.Int32>(Admin.TelegramAccount
            
            #line default
            #line hidden
, 2887), false)
);

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

WriteLiteral(" for=\"GooglePlusLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\CompanySocial\Create.cshtml"
                                                            Write(Admin.GooglePlus);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"GooglePlusLink\"");

WriteLiteral(" name=\"GooglePlusLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 3582), Tuple.Create("\"", 3613)
            
            #line 72 "..\..\Views\CompanySocial\Create.cshtml"
              , Tuple.Create(Tuple.Create("", 3596), Tuple.Create<System.Object, System.Int32>(Admin.GooglePlus
            
            #line default
            #line hidden
, 3596), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 3634), Tuple.Create("\"", 3666)
            
            #line 72 "..\..\Views\CompanySocial\Create.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 3642), Tuple.Create<System.Object, System.Int32>(Admin.GooglePlusAccount
            
            #line default
            #line hidden
, 3642), false)
);

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

WriteLiteral(" for=\"TwitterLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\CompanySocial\Create.cshtml"
                                                         Write(Admin.Twitter);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"TwitterLink\"");

WriteLiteral(" name=\"TwitterLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 4327), Tuple.Create("\"", 4355)
            
            #line 86 "..\..\Views\CompanySocial\Create.cshtml"
        , Tuple.Create(Tuple.Create("", 4341), Tuple.Create<System.Object, System.Int32>(Admin.Twitter
            
            #line default
            #line hidden
, 4341), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 4376), Tuple.Create("\"", 4405)
            
            #line 86 "..\..\Views\CompanySocial\Create.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 4384), Tuple.Create<System.Object, System.Int32>(Admin.TwitterAccount
            
            #line default
            #line hidden
, 4384), false)
);

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

WriteLiteral(" for=\"YoutubeLink\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 99 "..\..\Views\CompanySocial\Create.cshtml"
                                                         Write(Admin.YouTube);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"YoutubeLink\"");

WriteLiteral(" name=\"YoutubeLink\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 5066), Tuple.Create("\"", 5094)
            
            #line 100 "..\..\Views\CompanySocial\Create.cshtml"
        , Tuple.Create(Tuple.Create("", 5080), Tuple.Create<System.Object, System.Int32>(Admin.YouTube
            
            #line default
            #line hidden
, 5080), false)
);

WriteLiteral(" class=\"tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5115), Tuple.Create("\"", 5144)
            
            #line 100 "..\..\Views\CompanySocial\Create.cshtml"
                                                   , Tuple.Create(Tuple.Create("", 5123), Tuple.Create<System.Object, System.Int32>(Admin.YouTubeAccount
            
            #line default
            #line hidden
, 5123), false)
);

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"newCompanySocial\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteAttribute("onclick", Tuple.Create("  onclick=\"", 5479), Tuple.Create("\"", 5558)
, Tuple.Create(Tuple.Create("", 5490), Tuple.Create("javascript:", 5490), true)
, Tuple.Create(Tuple.Create(" ", 5501), Tuple.Create("form.action", 5502), true)
, Tuple.Create(Tuple.Create(" ", 5513), Tuple.Create("=", 5514), true)
, Tuple.Create(Tuple.Create(" ", 5515), Tuple.Create("\'", 5516), true)
            
            #line 108 "..\..\Views\CompanySocial\Create.cshtml"
                                                                                                                     , Tuple.Create(Tuple.Create("", 5517), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CompanySocial.Create())
            
            #line default
            #line hidden
, 5517), false)
, Tuple.Create(Tuple.Create("", 5556), Tuple.Create("\';", 5556), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 110 "..\..\Views\CompanySocial\Create.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
