using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Manufacturer
{
    public class ManufacturerViewModel : BaseViewModel
    {

        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
     
        public CountryType? Country { get; set; }


        /// <summary>
        ///
        /// </summary>
        

        public string Name { get; set; }
    }
}