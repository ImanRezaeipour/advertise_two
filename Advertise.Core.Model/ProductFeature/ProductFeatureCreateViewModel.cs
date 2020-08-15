using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductFeature
{
    public class ProductFeatureCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}