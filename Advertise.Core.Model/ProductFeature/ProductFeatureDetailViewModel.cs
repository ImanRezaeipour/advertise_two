using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductFeature
{
    public class ProductFeatureDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid ProductId { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}