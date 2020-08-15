using System;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Manufacturer
{
    public class ManufacturerSearchRequest:BaseSearchRequest
    {

        /// <summary>
        ///
        /// </summary>
        public CountryType? Country { get; set; }

        public Guid? CreatedById { get; set; }
       
    }
}