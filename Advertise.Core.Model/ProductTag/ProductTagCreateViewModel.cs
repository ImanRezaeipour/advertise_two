using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductTag
{

    public class ProductTagCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public DateTime? ExpiredOn { get; set; }

        public DateTime? StartedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid TagId { get; set; }

        #endregion Public Properties
    }
}