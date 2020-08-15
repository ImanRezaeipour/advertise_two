using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Locations
{
    /// <summary>
    ///     نشان دهنده آدرس
    /// </summary>
    public class City : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     استان
        /// </summary>
        public virtual bool? IsState { get; set; }

        /// <summary>
        ///     شهرستان
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsActive { get; set; }

        /// <summary>
        /// طول جغرافیایی
        /// </summary>
        public virtual string Latitude { get; set; }

        /// <summary>
        /// عرض جغرافیای
        /// </summary>
        public virtual string Longitude { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual City Parent { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<City> Childrens { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        #endregion
    }
}