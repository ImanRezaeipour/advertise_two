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

namespace Advertise.Web.Views.Shared
{
    using System;
    using System.Collections.Generic;
    
    #line 2 "..\..\Views\Shared\DatePickerInitial.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
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
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public class DatePickerInitial : System.Web.WebPages.HelperPage
    {

#line 3 "..\..\Views\Shared\DatePickerInitial.cshtml"
public static System.Web.WebPages.HelperResult Initial() {
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 3 "..\..\Views\Shared\DatePickerInitial.cshtml"
                    
    Func<DateTime, string> toPersianDate = date =>
    {
        var dateTime = new DateTime(date.Year, date.Month, date.Day, new GregorianCalendar());
        var persianCalendar = new PersianCalendar();
        return string.Format("{0}/{1}/{2}",
            persianCalendar.GetYear(dateTime),
            persianCalendar.GetMonth(dateTime).ToString("00"),
            persianCalendar.GetDayOfMonth(dateTime).ToString("00"));
    };
    
    var today = toPersianDate(DateTime.Now);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "<script>\n    $(function() {\n        $(document).on(\'focus\', \'input.datepicker\', f" +
"unction() {\n            $(this).datepicker({\n                \"setDate\": ");


#line 19 "..\..\Views\Shared\DatePickerInitial.cshtml"
WriteTo(__razor_helper_writer, today);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, ",\n                changeMonth: true,\n                changeYear: true,\n          " +
"      yearRange: \'c-100:c+0\'\n            });\n        });\n    });\n</script>\n");


#line 27 "..\..\Views\Shared\DatePickerInitial.cshtml"


#line default
#line hidden
});

#line 27 "..\..\Views\Shared\DatePickerInitial.cshtml"
}
#line default
#line hidden

    }
}
#pragma warning restore 1591
