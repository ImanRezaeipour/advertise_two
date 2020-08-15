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

namespace Advertise.Web.Views.Shared
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
    
    #line 2 "..\..\Views\Shared\NotyBuilder.cshtml"
    using Advertise.Web.Framework.Noty;
    
    #line default
    #line hidden
    using Advertise.Web.Framework.ViewEngines.Razor;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public class NotyBuilder : System.Web.WebPages.HelperPage
    {

#line 3 "..\..\Views\Shared\NotyBuilder.cshtml"
public static System.Web.WebPages.HelperResult ShowNotyMessages(NotyAlert notyInput)
{
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 4 "..\..\Views\Shared\NotyBuilder.cshtml"
 
    if (notyInput == null)
    {
        return;
    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "    <script>\r\n        $(function () {\r\n");


#line 11 "..\..\Views\Shared\NotyBuilder.cshtml"
            

#line default
#line hidden

#line 11 "..\..\Views\Shared\NotyBuilder.cshtml"
             foreach (var message in notyInput.NotyMessages)
            {
                if (message.Type == NotyAlertType.Alert)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n                        messageInfo(\'");


#line 16 "..\..\Views\Shared\NotyBuilder.cshtml"
       WriteTo(__razor_helper_writer, message.Message);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\', true);\r\n                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 18 "..\..\Views\Shared\NotyBuilder.cshtml"
                }
                if (message.Type == NotyAlertType.Error)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n                        messageError(\'");


#line 22 "..\..\Views\Shared\NotyBuilder.cshtml"
        WriteTo(__razor_helper_writer, message.Message);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\');\r\n                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 24 "..\..\Views\Shared\NotyBuilder.cshtml"
                }
                if (message.Type == NotyAlertType.Information)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n                        messageInfo(\'");


#line 28 "..\..\Views\Shared\NotyBuilder.cshtml"
       WriteTo(__razor_helper_writer, message.Message);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\');\r\n                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 30 "..\..\Views\Shared\NotyBuilder.cshtml"
                }
                if (message.Type == NotyAlertType.Success)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n                        messageSuccess(\'");


#line 34 "..\..\Views\Shared\NotyBuilder.cshtml"
          WriteTo(__razor_helper_writer, message.Message);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\');\r\n                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 36 "..\..\Views\Shared\NotyBuilder.cshtml"
                }
                if (message.Type == NotyAlertType.Warning)
                {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n                        messageWarning(\'");


#line 40 "..\..\Views\Shared\NotyBuilder.cshtml"
          WriteTo(__razor_helper_writer, message.Message);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\');\r\n                    ");

WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 42 "..\..\Views\Shared\NotyBuilder.cshtml"
                }
            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        });\r\n    </script>\r\n");


#line 46 "..\..\Views\Shared\NotyBuilder.cshtml"


#line default
#line hidden
});

#line 46 "..\..\Views\Shared\NotyBuilder.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
