using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductSpecification
{
    public class ProductSpecificationViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Guid SpecificationId { get; set; }
        public string SpecificationOptionTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? SpecificationOrder { get; set; }

        public string SpecificationTitle { get; set; }
        public IEnumerable<string> SpecificationValues { get; set; }
        public string Value { get; set; }

        #endregion Public Properties
    }
}