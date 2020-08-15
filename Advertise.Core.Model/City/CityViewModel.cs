using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.City
{
    public class CityViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        ///     استان
        /// </summary>
        public bool? IsState { get; set; }

        /// <summary>
        /// طول جغرافیایی
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// عرض جغرافیای
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        ///     شهرستان
        /// </summary>
        public string Name { get; set; }

        public Guid ParentId { get; set; }

        #endregion Public Properties
    }
}