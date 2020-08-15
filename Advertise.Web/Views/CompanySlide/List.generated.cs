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

namespace Advertise.Web.Views.CompanySlide
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
    
    #line 2 "..\..\Views\CompanySlide\List.cshtml"
    using Advertise.Service.Services.Permissions;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CompanySlide/List.cshtml")]
    public partial class List : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<Advertise.Core.Models.CompanySlide.CompanySlideListViewModel>
    {
        public List()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\CompanySlide\List.cshtml"
  
    Layout = MVC.Shared.Views._ProfileLayout;
    ViewBag.Title = Model.IsMine != true ? "لیست اسلایدهای کمپانی" : "لیست اسلایدها";
    ViewBag.PageName = "CompanySlides";
    ViewBag.HasSearchbar = true;

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 407), Tuple.Create("\"", 510)
, Tuple.Create(Tuple.Create("", 415), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 10 "..\..\Views\CompanySlide\List.cshtml"
             if (Model.IsMine != true) {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "dashboard-content");

            
            #line 10 "..\..\Views\CompanySlide\List.cshtml"
                                                                      } else {
            
            #line default
            #line hidden
WriteLiteralTo(__razor_attribute_value_writer, "profile-content");

            
            #line 10 "..\..\Views\CompanySlide\List.cshtml"
                                                                                                          }
            
            #line default
            #line hidden
}), 415), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"search\"");

WriteLiteral(" class=\"list-searchbar\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 12 "..\..\Views\CompanySlide\List.cshtml"
   Write(SearchItem.Term(Model.SearchRequest.Term));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 13 "..\..\Views\CompanySlide\List.cshtml"
   Write(SearchItem.SortDirection(Model.SortDirectionList, Model.SearchRequest.SortDirection));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 14 "..\..\Views\CompanySlide\List.cshtml"
   Write(SearchItem.PageSize(Model.PageSizeList, Model.SearchRequest.PageSize));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 15 "..\..\Views\CompanySlide\List.cshtml"
   Write(SearchItem.GridView());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"headline buttons primary\"");

WriteLiteral(">\r\n        <h1>");

            
            #line 19 "..\..\Views\CompanySlide\List.cshtml"
             if (Model.IsMine != true){
            
            #line default
            #line hidden
WriteLiteral("لیست اسلایدهای کمپانی ها");

            
            #line 19 "..\..\Views\CompanySlide\List.cshtml"
                                                                            }else{
            
            #line default
            #line hidden
WriteLiteral("لیست اسلایدها");

            
            #line 19 "..\..\Views\CompanySlide\List.cshtml"
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

            
            #line 25 "..\..\Views\CompanySlide\List.cshtml"
                
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\CompanySlide\List.cshtml"
                 if (User.IsInRole(PermissionConst.CanCompanyVideoCreate))
                {
                    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\CompanySlide\List.cshtml"
               Write(Html.Partial(MVC.CompanySlide.Views._AddItem));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\CompanySlide\List.cshtml"
                                                                  
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 29 "..\..\Views\CompanySlide\List.cshtml"
           Write(Html.Partial(MVC.CompanySlide.Views._ListMore, Model.CompanySlides));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"pager\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 35 "..\..\Views\CompanySlide\List.cshtml"
   Write(Html.Partial(MVC.Shared.Views.SiteLayout._Paging, Model.SearchRequest));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
