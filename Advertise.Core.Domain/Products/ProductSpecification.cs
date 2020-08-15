using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    /// <summary>
    ///     نشان دهنده مقادیر فیلدها
    /// </summary>
    public class ProductSpecification : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual string Value { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ProductId { get; set; }

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