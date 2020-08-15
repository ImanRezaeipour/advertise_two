using System;

namespace Advertise.Core.Models.ProductSpecification
{
    public class ProductSpecificationDetailViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Guid SpecificationId { get; set; }
        public string Value { get; set; }

        #endregion Public Properties
    }
}