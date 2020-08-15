using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductLike
{

    public class ProductLikeCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public bool IsLike { get; set; }

        public Guid LikedById { get; set; }

        public Guid ProductId { get; set; }

        #endregion Public Properties
    }
}