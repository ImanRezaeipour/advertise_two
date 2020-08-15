using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Manufacturer
{
    public class ManufacturerCreateViewModel : BaseViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public  CountryType? Country { get; set; }


        public IEnumerable<SelectListItem> CountryList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public  string Name { get; set; }
    }
}