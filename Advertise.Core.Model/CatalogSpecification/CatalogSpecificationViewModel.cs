using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Core.Types;

namespace Advertise.Core.Models.CatalogSpecification
{
    public class CatalogSpecificationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        /// </summary>
        public Guid? SpecificationId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? SpecificationOptionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Value { get; set; }

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

        #endregion Public Properties
    }
}