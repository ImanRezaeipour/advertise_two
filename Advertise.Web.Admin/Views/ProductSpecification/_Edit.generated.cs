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

namespace Advertise.Web.Views.ProductSpecification
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
    
    #line 2 "..\..\Views\ProductSpecification\_Edit.cshtml"
    using Advertise.Core.Types;
    
    #line default
    #line hidden
    using Advertise.Web;
    using Advertise.Web.Framework.ViewEngines.Razor;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ProductSpecification/_Edit.cshtml")]
    public partial class _Edit : Advertise.Web.Framework.ViewEngines.Razor.WebViewPage<IEnumerable<Advertise.Core.Models.ProductSpecification.ProductSpecificationEditViewModel>>
    {
        public _Edit()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\ProductSpecification\_Edit.cshtml"
  
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

            
            #line 12 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <select");

WriteAttribute("name", Tuple.Create(" name=\"", 519), Tuple.Create("\"", 578)
, Tuple.Create(Tuple.Create("", 526), Tuple.Create("Specifications[", 526), true)
            
            #line 13 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 541), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 541), false)
, Tuple.Create(Tuple.Create("", 551), Tuple.Create("].SpecificationOptionIdList", 551), true)
);

WriteLiteral(">\r\n");

            
            #line 14 "..\..\Views\ProductSpecification\_Edit.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\ProductSpecification\_Edit.cshtml"
                         foreach (var option in productSpecification.Options)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 723), Tuple.Create("\"", 741)
            
            #line 16 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 731), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 731), false)
);

WriteLiteral(" ");

            
            #line 16 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                        if (productSpecification.SpecificationOptionIdList.Contains(option.Id)) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" selected");

            
            #line 16 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                                        }
            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 16 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                                     Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 17 "..\..\Views\ProductSpecification\_Edit.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </select>\r\n                </div>\r\n");

            
            #line 20 "..\..\Views\ProductSpecification\_Edit.cshtml"
                break;

            case SpecificationType.String:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    <input");

WriteLiteral(" type=\"text\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1184), Tuple.Create("\"", 1223)
, Tuple.Create(Tuple.Create("", 1191), Tuple.Create("Specifications[", 1191), true)
            
            #line 25 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1206), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 1206), false)
, Tuple.Create(Tuple.Create("", 1216), Tuple.Create("].Value", 1216), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1224), Tuple.Create("\"", 1259)
            
            #line 25 "..\..\Views\ProductSpecification\_Edit.cshtml"
      , Tuple.Create(Tuple.Create("", 1232), Tuple.Create<System.Object, System.Int32>(productSpecification.Value
            
            #line default
            #line hidden
, 1232), false)
);

WriteLiteral(" />\r\n                </div>\r\n");

            
            #line 27 "..\..\Views\ProductSpecification\_Edit.cshtml"
                break;

            case SpecificationType.Checkbox:

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"input-container\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"rl-label\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 32 "..\..\Views\ProductSpecification\_Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\ProductSpecification\_Edit.cshtml"
                      
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

WriteLiteral(" type=\"hidden\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1839), Tuple.Create("\"", 1904)
, Tuple.Create(Tuple.Create("", 1846), Tuple.Create("Specifications[", 1846), true)
            
            #line 38 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1861), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 1861), false)
, Tuple.Create(Tuple.Create("", 1871), Tuple.Create("].SpecificationOptionIdList.Index", 1871), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1905), Tuple.Create("\"", 1927)
            
            #line 38 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                  , Tuple.Create(Tuple.Create("", 1913), Tuple.Create<System.Object, System.Int32>(indexCheckbox
            
            #line default
            #line hidden
, 1913), false)
);

WriteLiteral(">\r\n                                    <input");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1989), Tuple.Create("\"", 2057)
, Tuple.Create(Tuple.Create("", 1996), Tuple.Create("Specifications[", 1996), true)
            
            #line 39 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2011), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 2011), false)
, Tuple.Create(Tuple.Create("", 2021), Tuple.Create("].SpecificationOptionIdList[", 2021), true)
            
            #line 39 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                      , Tuple.Create(Tuple.Create("", 2049), Tuple.Create<System.Object, System.Int32>(option
            
            #line default
            #line hidden
, 2049), false)
, Tuple.Create(Tuple.Create("", 2056), Tuple.Create("]", 2056), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 2058), Tuple.Create("\"", 2076)
            
            #line 39 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                       , Tuple.Create(Tuple.Create("", 2066), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 2066), false)
);

WriteLiteral(" ");

            
            #line 39 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                                    if (productSpecification.SpecificationOptionIdList.Contains(option.Id)) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" checked");

            
            #line 39 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                                                                                                                                   }
            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                    <span>");

            
            #line 40 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                     Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </label>\r\n                            </" +
"div>\r\n");

            
            #line 43 "..\..\Views\ProductSpecification\_Edit.cshtml"
                            indexCheckbox = indexCheckbox + 1;
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 47 "..\..\Views\ProductSpecification\_Edit.cshtml"
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

            
            #line 54 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                       Write(productSpecification.Title);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

            
            #line 55 "..\..\Views\ProductSpecification\_Edit.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\ProductSpecification\_Edit.cshtml"
                      
                        var indexRadiobox = 0;
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

WriteAttribute("name", Tuple.Create(" name=\"", 3078), Tuple.Create("\"", 3137)
, Tuple.Create(Tuple.Create("", 3085), Tuple.Create("Specifications[", 3085), true)
            
            #line 61 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3100), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 3100), false)
, Tuple.Create(Tuple.Create("", 3110), Tuple.Create("].SpecificationOptionIdList", 3110), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 3138), Tuple.Create("\"", 3156)
            
            #line 61 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                           , Tuple.Create(Tuple.Create("", 3146), Tuple.Create<System.Object, System.Int32>(option.Id
            
            #line default
            #line hidden
, 3146), false)
);

WriteLiteral(" ");

            
            #line 61 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                        if (productSpecification.SpecificationOptionIdList.Contains(option.Id)) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" checked");

            
            #line 61 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                                                                                                                                                                                                                       }
            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                    <span>");

            
            #line 62 "..\..\Views\ProductSpecification\_Edit.cshtml"
                                     Write(option.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </label>\r\n                            </" +
"div>\r\n");

            
            #line 65 "..\..\Views\ProductSpecification\_Edit.cshtml"
                            indexRadiobox = indexRadiobox + 1;
                        }
                    
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 69 "..\..\Views\ProductSpecification\_Edit.cshtml"
                break;

            case SpecificationType.Currency:
                break;
        }

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("name", Tuple.Create(" name=\"", 3675), Tuple.Create("\"", 3711)
, Tuple.Create(Tuple.Create("", 3682), Tuple.Create("Specifications[", 3682), true)
            
            #line 74 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3697), Tuple.Create<System.Object, System.Int32>(indexItem
            
            #line default
            #line hidden
, 3697), false)
, Tuple.Create(Tuple.Create("", 3707), Tuple.Create("].Id", 3707), true)
);

WriteAttribute("value", Tuple.Create(" value=\"", 3712), Tuple.Create("\"", 3744)
            
            #line 74 "..\..\Views\ProductSpecification\_Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3720), Tuple.Create<System.Object, System.Int32>(productSpecification.Id
            
            #line default
            #line hidden
, 3720), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("        <hr");

WriteLiteral(" class=\"line-separator\"");

WriteLiteral(" />\r\n");

            
            #line 76 "..\..\Views\ProductSpecification\_Edit.cshtml"
        indexItem = indexItem + 1;
    }

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591