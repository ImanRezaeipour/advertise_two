using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Specifications
{

    public class Specification : BaseEntity
    {
        #region Properties

        /// <summary>
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// </summary>
        public virtual SpecificationType? Type { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// </summary>
        public virtual int? Order { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CategoryId { get; set; }
        public virtual bool? IsSearchable { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<SpecificationOption> Options { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<ProductSpecification> Products { get; set; }

        #endregion
    }
}