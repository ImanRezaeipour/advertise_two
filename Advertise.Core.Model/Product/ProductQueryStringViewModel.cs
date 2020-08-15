using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Product
{
    public class ProductQueryStringViewModel:BaseViewModel
    {
        public string QueryString { get; set; }
        public Dictionary<string,string> DictionaryQueryString { get; set; }
    }
}
