using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Address
{

    public class AddressEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> Cities { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid CityId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}