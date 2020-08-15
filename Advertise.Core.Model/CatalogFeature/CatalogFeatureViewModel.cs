using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CatalogFeature
{
    public class CatalogFeatureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}