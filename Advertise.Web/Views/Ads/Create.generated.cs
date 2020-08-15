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

namespace Advertise.Web.Views.Ads
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
    
    #line 2 "..\..\Views\Ads\Create.cshtml"
    using Advertise.Core.Types;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Ads\Create.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Ads/Create.cshtml")]
    public partial class Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Ads.AdsCreateViewModel>
    {
        public Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Ads\Create.cshtml"
  
    Layout = MVC.Shared.Views._ProfileLayout;
    ViewBag.Title = Admin.AdOrder;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script>\r\n        var categoryListJson = ");

            
            #line 11 "..\..\Views\Ads\Create.cshtml"
                          Write(Html.Raw(Model.CategeoryListJson));

            
            #line default
            #line hidden
WriteLiteral(";\r\n    </script>\r\n");

});

WriteLiteral("<div");

WriteLiteral(" class=\"profile-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 16 "..\..\Views\Ads\Create.cshtml"
       Write(Admin.AdOrder);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"newBanner\"");

WriteLiteral(" data-on-load=\"validateAds\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 20 "..\..\Views\Ads\Create.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 21 "..\..\Views\Ads\Create.cshtml"
       Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <div");

WriteLiteral(" class=\"input-form\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"vertical-dashed\"");

WriteLiteral("></div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"AdsOptionId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">نوع آگهی</label>\r\n                    <select");

WriteLiteral(" name=\"AdsOptionId\"");

WriteLiteral(" id=\"AdsOptionId\"");

WriteLiteral(" data-on-load=\"dropdownAdsOption\"");

WriteLiteral(">\r\n                        <option selected disabled>-- ");

            
            #line 32 "..\..\Views\Ads\Create.cshtml"
                                                Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral(" --</option>\r\n");

            
            #line 33 "..\..\Views\Ads\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Ads\Create.cshtml"
                         foreach (var option in Model.AdsOptions)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("class", Tuple.Create(" class=\"", 1424), Tuple.Create("\"", 1514)
, Tuple.Create(Tuple.Create("", 1432), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                            if(option.PositionType == AdsPositionType.AdsCategory){
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "has-category");

            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                                                                                                            }
            
            #line default
            #line hidden
}), 1432), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1515), Tuple.Create("\"", 1533)
            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 1523), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 1523), false)
);

WriteLiteral(">");

            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                             Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                            Write(option.Price);

            
            #line default
            #line hidden
WriteLiteral(" تومان) (");

            
            #line 35 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                  Write(option.ReleaseTime);

            
            #line default
            #line hidden
WriteLiteral(")</option>\r\n");

            
            #line 36 "..\..\Views\Ads\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>  \r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container hide-none\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height hide-none\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"CategoryId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 45 "..\..\Views\Ads\Create.cshtml"
                         Write(Admin.CategorySelection);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <select");

WriteLiteral(" id=\"CategoryId\"");

WriteLiteral(" name=\"CategoryId\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2127), Tuple.Create("\"", 2152)
            
            #line 47 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2135), Tuple.Create<System.Object, System.Int32>(Model.CategoryId
            
            #line default
            #line hidden
, 2135), false)
);

WriteLiteral(" data-on-load=\"dropdownSimpleCategoryList\"");

WriteLiteral("></select>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 55 "..\..\Views\Ads\Create.cshtml"
                         Write(Admin.ThisAdIsUsedFor);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <label");

WriteLiteral(" class=\"enabled-form-iradio-label\"");

WriteLiteral(" for=\"CompanyEntity\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"EntityName\"");

WriteLiteral(" value=\"CompanyEntity\"");

WriteLiteral(" id=\"CompanyEntity\"");

WriteLiteral(" data-on-change=\"disableEntity\"");

WriteLiteral(" checked/>\r\n                        <span>کمپانی من</span>\r\n                    <" +
"/label>\r\n                    <label");

WriteLiteral(" class=\"disabled-form-iradio-label\"");

WriteLiteral(" for=\"ProductEntity\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"EntityName\"");

WriteLiteral(" value=\"ProductEntity\"");

WriteLiteral(" id=\"ProductEntity\"");

WriteLiteral(" data-on-change=\"enableEntity\"");

WriteLiteral(" />\r\n                        <span>محصولات</span>    \r\n                    </labe" +
"l>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container hide-none\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height hide-none\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"EntityId\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">محصولات</label>\r\n                    <select");

WriteLiteral(" name=\"EntityId\"");

WriteLiteral(" id=\"EntityId\"");

WriteLiteral(">\r\n                        <option selected disabled>-- ");

            
            #line 73 "..\..\Views\Ads\Create.cshtml"
                                                Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral(" --</option>\r\n");

            
            #line 74 "..\..\Views\Ads\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\Ads\Create.cshtml"
                         foreach (var item in Model.EntityList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 3768), Tuple.Create("\"", 3787)
            
            #line 76 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3776), Tuple.Create<System.Object, System.Int32>(item.Value
            
            #line default
            #line hidden
, 3776), false)
);

WriteAttribute("selected", Tuple.Create(" selected=\"", 3788), Tuple.Create("\"", 3841)
            
            #line 76 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3799), Tuple.Create<System.Object, System.Int32>(Model.EntityId.ToString() == item.Value
            
            #line default
            #line hidden
, 3799), false)
);

WriteLiteral(">");

            
            #line 76 "..\..\Views\Ads\Create.cshtml"
                                                                                                         Write(item.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 77 "..\..\Views\Ads\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n                \r\n        " +
"        <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"DurationType\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\Ads\Create.cshtml"
                                                          Write(Admin.TheDurationOfTheAdDisplaying);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <select");

WriteLiteral(" name=\"DurationType\"");

WriteLiteral(" id=\"DurationType\"");

WriteLiteral(">\r\n                        <option selected disabled>-- ");

            
            #line 87 "..\..\Views\Ads\Create.cshtml"
                                                Write(Admin.Choose);

            
            #line default
            #line hidden
WriteLiteral(" --</option>\r\n");

            
            #line 88 "..\..\Views\Ads\Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\Ads\Create.cshtml"
                         foreach (var item in Model.DurationList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 4550), Tuple.Create("\"", 4569)
            
            #line 90 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 4558), Tuple.Create<System.Object, System.Int32>(item.Value
            
            #line default
            #line hidden
, 4558), false)
);

WriteAttribute("selected", Tuple.Create(" selected=\"", 4570), Tuple.Create("\"", 4627)
            
            #line 90 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 4581), Tuple.Create<System.Object, System.Int32>(Model.DurationType.ToString() == item.Value
            
            #line default
            #line hidden
, 4581), false)
);

WriteLiteral(">");

            
            #line 90 "..\..\Views\Ads\Create.cshtml"
                                                                                                             Write(item.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 91 "..\..\Views\Ads\Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                    <span");

WriteLiteral(" id=\"Price\"");

WriteLiteral(" class=\"form-item-dynamic-info\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 94 "..\..\Views\Ads\Create.cshtml"
                   Write(Admin.TheCostOfBuyingThisAd);

            
            #line default
            #line hidden
WriteLiteral(" :\r\n                        <span");

WriteLiteral(" id=\"AdPrice\"");

WriteLiteral(">0</span> \r\n                        <span>");

            
            #line 96 "..\..\Views\Ads\Create.cshtml"
                         Write(Admin.Toman);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </span>\r\n                </div>\r\n\r\n                <" +
"div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(" id=\"Title1\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                        <span>");

            
            #line 105 "..\..\Views\Ads\Create.cshtml"
                         Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Title\"");

WriteLiteral(" name=\"Title\"");

WriteLiteral(" class=\"tooltipster\"");

WriteLiteral(" />\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <p");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral("></p>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"input-container fixed-height\"");

WriteLiteral(" id=\"Image1\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"files\"");

WriteLiteral(" class=\"rl-label tooltipster\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5739), Tuple.Create("\"", 5768)
            
            #line 114 "..\..\Views\Ads\Create.cshtml"
, Tuple.Create(Tuple.Create("", 5747), Tuple.Create<System.Object, System.Int32>(Admin.ItChoosesImage
            
            #line default
            #line hidden
, 5747), false)
);

WriteLiteral(">");

            
            #line 114 "..\..\Views\Ads\Create.cshtml"
                                                                                             Write(Admin.UploadAdPhoto);

            
            #line default
            #line hidden
WriteLiteral(" :</label>\r\n");

WriteLiteral("                    ");

            
            #line 115 "..\..\Views\Ads\Create.cshtml"
               Write(Html.Partial(MVC.Shared.Views.FineUploaderTemplates._FineUploaderTemplate));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" name=\"files\"");

WriteLiteral(" id=\"files\"");

WriteLiteral(" data-on-load=\"uploaderBanner\"");

WriteLiteral("></div>\r\n                </div>\r\n\r\n                ");

WriteLiteral("\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" form=\"newBanner\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 7099), Tuple.Create("\"", 7303)
, Tuple.Create(Tuple.Create("", 7109), Tuple.Create("javascript:", 7109), true)
, Tuple.Create(Tuple.Create(" ", 7120), Tuple.Create("form.action", 7121), true)
, Tuple.Create(Tuple.Create(" ", 7132), Tuple.Create("=", 7133), true)
, Tuple.Create(Tuple.Create(" ", 7134), Tuple.Create("\'", 7135), true)
, Tuple.Create(Tuple.Create("", 7136), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 135 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                              if(User.IsInRole(PermissionConst.CanAdsCreateByAdmin) != true) {
            
            #line default
            #line hidden
            
            #line 135 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                                                             WriteTo(__razor_attribute_value_writer, Url.Action(MVC.Ads.Create()));

            
            #line default
            #line hidden
            
            #line 135 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                                                                                                                                        } else {
            
            #line default
            #line hidden
            
            #line 135 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                                                                                                               WriteTo(__razor_attribute_value_writer, Url.Action(MVC.Ads.CreateByAdmin()));

            
            #line default
            #line hidden
            
            #line 135 "..\..\Views\Ads\Create.cshtml"
                                                                                                                                                                                                                                                                                                                                                                 }
            
            #line default
            #line hidden
}), 7136), false)
, Tuple.Create(Tuple.Create("", 7301), Tuple.Create("\';", 7301), true)
);

WriteLiteral(">\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 137 "..\..\Views\Ads\Create.cshtml"
                 Write(Admin.SaveAndPay);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
