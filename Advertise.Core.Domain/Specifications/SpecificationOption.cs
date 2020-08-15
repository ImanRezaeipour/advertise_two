using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Specifications
{
    /// <summary>
    /// 
    /// </summary>
    public class SpecificationOption : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     عنوان گزینه‌ی مورد نظر
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     توضیح بیشتر برای گزینه‌ی مورد نظر
        /// </summary>
        public virtual string Description { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Specification Specification { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? SpecificationId { get; set; }

        #endregion
    }
}