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

namespace Advertise.Web.Views.CatalogSpecification
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
    
    #line 2 "..\..\Views\CatalogSpecification\_Create.cshtml"
    using Advertise.Core.Types;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using Advertise.Web.Views.Shared.SiteLayout;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogSpecification/_Create.cshtml")]
    public partial class _Create : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<IEnumerable<Advertise.Core.Models.ProductSpecification.ProductSpecificationCreateViewModel>>
    {
        public _Create()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\CatalogSpecification\_Create.cshtml"
  
    var indexItem = 0;
    foreach (var productSpecification in Model)
    {
        switch (productSpecification.Type)
        {
            case SpecificationType.Droplist:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <select");

WriteAttribute("name", Tuple.Create(" name=\"", 521), Tuple.Create("\"", 580)
, Tuple.Create(Tuple.Create("", 528), Tuple.Create("Specifications[", 528), true)
            
            #line 13 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 543), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 543), false)
, Tuple.Create(Tuple.Create("", 553), Tuple.Create("].SpecificationOptionIdList", 553), true)
);

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\CatalogSpecification\_Create.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\CatalogSpecification\_Create.cshtml"
                         foreach (var option in productSpecification.Options)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 725), Tuple.Create("\"", 743)
            
            #line 16 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 733), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 733), false)
);

WriteLiteral(">");

            
            #line 16 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                                  Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 17 "..\..\Views\CatalogSpecification\_Create.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n");

            
            #line 20 "..\..\Views\CatalogSpecification\_Create.cshtml"
                break;

            case SpecificationType.String:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1087), Tuple.Create("\"", 1126)
, Tuple.Create(Tuple.Create("", 1094), Tuple.Create("Specifications[", 1094), true)
            
            #line 25 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 1109), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 1109), false)
, Tuple.Create(Tuple.Create("", 1119), Tuple.Create("].Value", 1119), true)
);

WriteLiteral(" />\r\n                </div>\r\n");

            
            #line 27 "..\..\Views\CatalogSpecification\_Create.cshtml"
                break;

            case SpecificationType.Checkbox:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 32 "..\..\Views\CatalogSpecification\_Create.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\CatalogSpecification\_Create.cshtml"
                      
                        var indexRadioList = 0;
                        foreach (var option in productSpecification.Options)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1707), Tuple.Create("\"", 1772)
, Tuple.Create(Tuple.Create("", 1714), Tuple.Create("Specifications[", 1714), true)
            
            #line 38 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 1729), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 1729), false)
, Tuple.Create(Tuple.Create("", 1739), Tuple.Create("].SpecificationOptionIdList.Index", 1739), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1773), Tuple.Create("\"", 1796)
            
            #line 38 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 1781), Tuple.Create<System.Object, System.Int32>(indexRadioList
            
            #line default
            #line hidden
, 1781), false)
);

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1858), Tuple.Create("\"", 1934)
, Tuple.Create(Tuple.Create("", 1865), Tuple.Create("Specifications[", 1865), true)
            
            #line 39 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 1880), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 1880), false)
, Tuple.Create(Tuple.Create("", 1890), Tuple.Create("].SpecificationOptionIdList[", 1890), true)
            
            #line 39 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                      , Tuple.Create(Tuple.Create("", 1918), Tuple.Create<System.Object, System.Int32>(indexRadioList
            
            #line default
            #line hidden
, 1918), false)
, Tuple.Create(Tuple.Create("", 1933), Tuple.Create("]", 1933), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1935), Tuple.Create("\"", 1953)
            
            #line 39 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                                               , Tuple.Create(Tuple.Create("", 1943), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 1943), false)
);

WriteLiteral(" />\r\n                                    <span>");

            
            #line 40 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                     Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </label>\r\n                            </" +
"div>\r\n");

            
            #line 43 "..\..\Views\CatalogSpecification\_Create.cshtml"
                            indexRadioList = indexRadioList + 1;
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 47 "..\..\Views\CatalogSpecification\_Create.cshtml"
                break;

            case SpecificationType.Color:
                break;

            case SpecificationType.Radiobox:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 54 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 55 "..\..\Views\CatalogSpecification\_Create.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\CatalogSpecification\_Create.cshtml"
                      
                        var indexCheckbox = 0;
                        foreach (var option in productSpecification.Options)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"checkbox-inline\"");

WriteLiteral(">\r\n                                <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"radio\"");

WriteAttribute("name", Tuple.Create(" name=\"", 2859), Tuple.Create("\"", 2918)
, Tuple.Create(Tuple.Create("", 2866), Tuple.Create("Specifications[", 2866), true)
            
            #line 61 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 2881), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 2881), false)
, Tuple.Create(Tuple.Create("", 2891), Tuple.Create("].SpecificationOptionIdList", 2891), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 2919), Tuple.Create("\"", 2937)
            
            #line 61 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                           , Tuple.Create(Tuple.Create("", 2927), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 2927), false)
);

WriteLiteral(" />\r\n                                    <span>");

            
            #line 62 "..\..\Views\CatalogSpecification\_Create.cshtml"
                                     Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </label>\r\n                            </" +
"div>\r\n");

            
            #line 65 "..\..\Views\CatalogSpecification\_Create.cshtml"
                        }
                        indexCheckbox = indexCheckbox + 1;
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 69 "..\..\Views\CatalogSpecification\_Create.cshtml"
                break;

            case SpecificationType.Currency:
                break;
        }

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("name", Tuple.Create(" name=\"", 3354), Tuple.Create("\"", 3390)
, Tuple.Create(Tuple.Create("", 3361), Tuple.Create("Specifications[", 3361), true)
            
            #line 74 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 3376), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 3376), false)
, Tuple.Create(Tuple.Create("", 3386), Tuple.Create("].Id", 3386), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 3391), Tuple.Create("\"", 3423)
            
            #line 74 "..\..\Views\CatalogSpecification\_Create.cshtml"
, Tuple.Create(Tuple.Create("", 3399), Tuple.Create<System.Object, System.Int32>(productSpecification.Id
            
            #line default
            #line hidden
, 3399), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("        <hr");

WriteLiteral(" class=\"line-separator\"");

WriteLiteral(" />\r\n");

            
            #line 76 "..\..\Views\CatalogSpecification\_Create.cshtml"
        indexItem = indexItem + 1;
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
