using Advertise.Service.Managers.File;

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

namespace ASP
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
    
    #line 1 "..\..\Views\CategoryReview\_AddItem.cshtml"
#line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CategoryReview/_AddItem.cshtml")]
    public partial class _Views_CategoryReview__AddItem_cshtml : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<dynamic>
    {
        public _Views_CategoryReview__AddItem_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"landing-grids-wrapper\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"product-list grid\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"landing-column-wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"landing-items nov-item-height-021\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"product-item column landing-column\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"nov-item-body\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"image-section\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"product-preview-actions\"");

WriteLiteral(">\r\n                                <figure");

WriteLiteral(" class=\"product-preview-image\"");

WriteLiteral(">\r\n                                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 566), Tuple.Create("\"", 613)
            
            #line 11 "..\..\Views\CategoryReview\_AddItem.cshtml"
, Tuple.Create(Tuple.Create("", 573), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CategoryReview.Create())
            
            #line default
            #line hidden
, 573), false)
);

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"item-preview-image\"");

WriteLiteral(">\r\n                                            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 739), Tuple.Create("\"", 763)
            
            #line 13 "..\..\Views\CategoryReview\_AddItem.cshtml"
, Tuple.Create(Tuple.Create("", 745), Tuple.Create<System.Object, System.Int32>(FileConst.NewItem
            
            #line default
            #line hidden
, 745), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 764), Tuple.Create("\"", 797)
            
            #line 13 "..\..\Views\CategoryReview\_AddItem.cshtml"
, Tuple.Create(Tuple.Create("", 770), Tuple.Create<System.Object, System.Int32>(Admin.CreateCategoryReview
            
            #line default
            #line hidden
, 770), false)
);

WriteLiteral(">\r\n                                        </div>\r\n                              " +
"      </a>\r\n                                </figure>\r\n                         " +
"   </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"info-section\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"middle-part\"");

WriteLiteral(">\r\n                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1143), Tuple.Create("\"", 1190)
            
            #line 21 "..\..\Views\CategoryReview\_AddItem.cshtml"
, Tuple.Create(Tuple.Create("", 1150), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.CategoryReview.Create())
            
            #line default
            #line hidden
, 1150), false)
);

WriteLiteral(" class=\"middle-part-link\"");

WriteLiteral(">\r\n                                    <p");

WriteLiteral(" class=\"new-item-add\"");

WriteLiteral(">\r\n                                        <i");

WriteLiteral(" class=\"fa fa-plus-square\"");

WriteLiteral("></i>\r\n                                        <span>");

            
            #line 24 "..\..\Views\CategoryReview\_AddItem.cshtml"
                                         Write(Admin.CreateCategoryReview);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                    </p>\r\n                              " +
"  </a>\r\n                            </div>\r\n                        </div>\r\n    " +
"                </div>\r\n                    <div");

WriteLiteral(" class=\"clearboth\"");

WriteLiteral("></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n" +
"</div>");

        }
    }
}
#pragma warning restore 1591
