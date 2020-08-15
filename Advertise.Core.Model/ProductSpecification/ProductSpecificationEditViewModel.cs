using Advertise.Core.Models.Common;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductSpecification
{
    public class ProductSpecificationEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SpecificationOptionViewModel> Options { get; set; }

        /// <summary>
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Guid?> SpecificationOptionIdList { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public SpecificationType Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Value { get; set; }

        #endregion Public Properties
    }
}