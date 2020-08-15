using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CatalogImage
{
    public class CatalogImageViewModel : BaseViewModel
    {
        #region Public Properties

        public string FileName { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        /// </summary>
        public bool? IsWatermark { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? Order { get; set; }

        #endregion Public Properties
    }
}