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

namespace Advertise.Web.Views.CategoryFollow
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CategoryFollow/MyFollowList.cshtml")]
    public partial class MyFollowList : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CategoryFollow.CategoryFollowListViewModel>
    {
        public MyFollowList()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
  
    Layout = MVC.Shared.Views._ProfileLayout;
    ViewBag.Title = Admin.FollowCategories;
    ViewBag.PageName = "myFollowCategories";
    ViewBag.HasSearchbar = true;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 327), Tuple.Create("\"", 430)
, Tuple.Create(Tuple.Create("", 335), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 9 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
             if (Model.IsMine != true) {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "dashboard-content");

            
            #line 9 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                                                      } else {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "profile-content");

            
            #line 9 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                                                                                          }
            
            #line default
            #line hidden
}), 335), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"search\"");

WriteLiteral(" class=\"list-searchbar\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 11 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
   Write(SearchItem.Term(Model.SearchRequest.Term));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 12 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
   Write(SearchItem.GridView());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h1>");

            
            #line 16 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
             if (Model.IsMine != true){
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                        Write(Admin.ListMyFollowsCategory);

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                                                                }else{
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                                                                       Write(Admin.ListMyFollowsCategory);

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
                                                                                                                               }
            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"landing-grids-wrapper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"product-list grid\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"landing-column-wrapper\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
           Write(Html.Partial(MVC.CategoryFollow.Views._FollowListMore, Model.CategoryFollows));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"pager\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 28 "..\..\Views\CategoryFollow\MyFollowList.cshtml"
   Write(Html.Partial(MVC.Shared.Views.SiteLayout._Paging, Model.SearchRequest));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
