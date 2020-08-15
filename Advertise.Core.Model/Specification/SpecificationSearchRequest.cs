using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Specification
{

    public class SpecificationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        /// آیا شامل خصیصه های دسته های والد نیز باشد
        /// </summary>
        public bool? WithParentCategory { get; set; }

        #endregion Public Properties
    }
}