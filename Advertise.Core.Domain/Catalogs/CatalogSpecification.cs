using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Specifications;

namespace Advertise.Core.Domains.Catalogs
{
    /// <summary>
    ///     نشان دهنده مقادیر فیلدها
    /// </summary>
    public class CatalogSpecification : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual string Value { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Catalog Catalog { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CatalogId { get; set; }

        /// <summary>
        /// </summary>
        public virtual Specification Specification { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? SpecificationId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual SpecificationOption SpecificationOption { get; set; }

        /// <summary>
        ///
        /// </summary>
        public  virtual Guid? SpecificationOptionId { get; set; }

        #endregion
    }
}