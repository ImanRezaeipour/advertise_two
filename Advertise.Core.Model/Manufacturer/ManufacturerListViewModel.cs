using System.Collections.Generic;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Email;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Manufacturer
{
    public class ManufacturerListViewModel : BaseViewModel
    {

        public IEnumerable<ManufacturerViewModel> Manufacturers {get;set;}
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public ManufacturerSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }
    }
}