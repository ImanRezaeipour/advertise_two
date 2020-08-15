using Advertise.Core.Models.City;
using Advertise.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Address
{
    public class AddressCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public CityViewModel City { get; set; }

        public string Extra { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string PostalCode { get; set; }

        public string Street { get; set; }

        #endregion Public Properties
    }
}