using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductLike
{

    public class ProductLikeEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsFollow { get; set; }

        #endregion Public Properties
    }
}