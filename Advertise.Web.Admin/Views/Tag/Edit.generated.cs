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

namespace Advertise.Web.Views.Tag
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Tag/Edit.cshtml")]
    public partial class Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.Tag.TagEditViewModel>
    {
        public Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Tag\Edit.cshtml"
  
    Layout = MVC.Shared.Views.SiteLayout.Panel._PanelLayout;
    ViewBag.Title = Admin.EditTag;

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"dashboard-content\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h4>");

            
            #line 9 "..\..\Views\Tag\Edit.cshtml"
       Write(Admin.EditTag);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"form-box-item profile-form\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"editTag\"");

WriteAttribute("action", Tuple.Create(" action=\"", 406), Tuple.Create("\"", 442)
            
            #line 12 "..\..\Views\Tag\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 415), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Tag.Edit())
            
            #line default
            #line hidden
, 415), false)
);

WriteLiteral(" method=\"Post\"");

WriteLiteral("  data-on-load=\"validateTag\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Views\Tag\Edit.cshtml"
       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"Id\"");

WriteLiteral(" name=\"Id\"");

WriteAttribute("value", Tuple.Create(" value=\"", 576), Tuple.Create("\"", 593)
            
            #line 14 "..\..\Views\Tag\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 584), Tuple.Create<System.Object, System.Int32>(Model.Id
            
            #line default
            #line hidden
, 584), false)
);

WriteLiteral(" />\r\n\r\n            <div");

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

WriteLiteral(" for=\"Title\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Tag\Edit.cshtml"
                                                   Write(Admin.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Title\"");

WriteLiteral(" name=\"Title\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1304), Tuple.Create("\"", 1324)
            
            #line 30 "..\..\Views\Tag\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1312), Tuple.Create<System.Object, System.Int32>(Model.Title
            
            #line default
            #line hidden
, 1312), false)
);

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 1325), Tuple.Create("\"", 1351)
            
            #line 30 "..\..\Views\Tag\Edit.cshtml"
                 , Tuple.Create(Tuple.Create("", 1339), Tuple.Create<System.Object, System.Int32>(Admin.Title
            
            #line default
            #line hidden
, 1339), false)
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

WriteLiteral(" for=\"Color\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Tag\Edit.cshtml"
                                                   Write(Admin.Color);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <select");

WriteLiteral(" id=\"Color\"");

WriteLiteral(" name=\"Color\"");

WriteLiteral(">\r\n");

            
            #line 45 "..\..\Views\Tag\Edit.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\Tag\Edit.cshtml"
                         foreach (var color in Model.ColorTypeList)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 2115), Tuple.Create("\"", 2135)
            
            #line 47 "..\..\Views\Tag\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2123), Tuple.Create<System.Object, System.Int32>(color.Value
            
            #line default
            #line hidden
, 2123), false)
);

WriteLiteral(" ");

            
            #line 47 "..\..\Views\Tag\Edit.cshtml"
                                                          if (Model.Color.ToString() == color.Value){
            
            #line default
            #line hidden
WriteLiteral(" selected");

            
            #line 47 "..\..\Views\Tag\Edit.cshtml"
                                                                                                                           }
            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 47 "..\..\Views\Tag\Edit.cshtml"
                                                                                                                        Write(color.Text);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 48 "..\..\Views\Tag\Edit.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n                \r\n        " +
"        <div");

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

WriteLiteral(" for=\"Description\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 62 "..\..\Views\Tag\Edit.cshtml"
                                                         Write(Admin.Description);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" name=\"Description\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2945), Tuple.Create("\"", 2971)
            
            #line 63 "..\..\Views\Tag\Edit.cshtml"
  , Tuple.Create(Tuple.Create("", 2953), Tuple.Create<System.Object, System.Int32>(Model.Description
            
            #line default
            #line hidden
, 2953), false)
);

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 2972), Tuple.Create("\"", 3004)
            
            #line 63 "..\..\Views\Tag\Edit.cshtml"
                                   , Tuple.Create(Tuple.Create("", 2986), Tuple.Create<System.Object, System.Int32>(Admin.Description
            
            #line default
            #line hidden
, 2986), false)
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

WriteLiteral(" for=\"CostValue\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 76 "..\..\Views\Tag\Edit.cshtml"
                                                       Write(Admin.Price);

            
            #line default
            #line hidden
WriteLiteral(" <span>(");

            
            #line 76 "..\..\Views\Tag\Edit.cshtml"
                                                                           Write(Admin.Toman);

            
            #line default
            #line hidden
WriteLiteral(")</span></label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"CostValue\"");

WriteLiteral(" name=\"CostValue\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3685), Tuple.Create("\"", 3709)
            
            #line 77 "..\..\Views\Tag\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3693), Tuple.Create<System.Object, System.Int32>(Model.CostValue
            
            #line default
            #line hidden
, 3693), false)
);

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 3710), Tuple.Create("\"", 3736)
            
            #line 77 "..\..\Views\Tag\Edit.cshtml"
                             , Tuple.Create(Tuple.Create("", 3724), Tuple.Create<System.Object, System.Int32>(Admin.Price
            
            #line default
            #line hidden
, 3724), false)
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

WriteLiteral(" for=\"DurationDay\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\Tag\Edit.cshtml"
                                                         Write(Admin.DurationOfUse);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"DurationDay\"");

WriteLiteral(" name=\"DurationDay\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4403), Tuple.Create("\"", 4429)
            
            #line 91 "..\..\Views\Tag\Edit.cshtml"
  , Tuple.Create(Tuple.Create("", 4411), Tuple.Create<System.Object, System.Int32>(Model.DurationDay
            
            #line default
            #line hidden
, 4411), false)
);

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 4430), Tuple.Create("\"", 4464)
            
            #line 91 "..\..\Views\Tag\Edit.cshtml"
                                   , Tuple.Create(Tuple.Create("", 4444), Tuple.Create<System.Object, System.Int32>(Admin.DurationOfUse
            
            #line default
            #line hidden
, 4444), false)
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

WriteLiteral(" for=\"file\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 104 "..\..\Views\Tag\Edit.cshtml"
                                                  Write(Admin.UploadImage);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                    ");

            
            #line 105 "..\..\Views\Tag\Edit.cshtml"
               Write(Html.Partial(MVC.Shared.Views.FineUploaderTemplates._FineUploaderTemplate));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" name=\"file\"");

WriteLiteral(" id=\"file\"");

WriteLiteral(" data-on-load=\"uploaderTag\"");

WriteLiteral(" data-param=\"edit\"");

WriteLiteral("></div>\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"msg-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"msg-box regular round-corners-five\"");

WriteLiteral(">\r\n                        <p>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-right\"");

WriteLiteral("></i>\r\n                            <span></span>\r\n                            <i");

WriteLiteral(" class=\"fa fa-quote-left\"");

WriteLiteral("></i>\r\n                        </p>\r\n                    </div>\r\n                " +
"</div>\r\n                <div");

WriteLiteral(" clas=\"input-container fixed-height\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" for=\"IsActive\"");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 119 "..\..\Views\Tag\Edit.cshtml"
                                                      Write(Admin.Status);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" id=\"IsActive\"");

WriteLiteral(" name=\"IsActive\"");

WriteLiteral(" value=\"true\"");

WriteAttribute("checked", Tuple.Create(" checked=\"", 5907), Tuple.Create("\"", 5932)
            
            #line 120 "..\..\Views\Tag\Edit.cshtml"
               , Tuple.Create(Tuple.Create("", 5917), Tuple.Create<System.Object, System.Int32>(Model.IsActive
            
            #line default
            #line hidden
, 5917), false)
);

WriteLiteral("/>\r\n                    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"IsActive\"");

WriteLiteral(" value=\"false\"");

WriteLiteral("/>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral("></div>\r\n            </div>\r\n        </form>\r\n        \r\n        <div");

WriteLiteral(" class=\"form-button-container\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" form=\"editTag\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"form-button right-form-btn ok-button round-corners-five disabled-btn-link" +
"\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(" >\r\n                <i");

WriteLiteral(" class=\"fa fa-save\"");

WriteLiteral("></i>\r\n                <span>");

            
            #line 131 "..\..\Views\Tag\Edit.cshtml"
                 Write(Admin.Save);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
