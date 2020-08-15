using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductCommentLike
{

    public class ProductCommentLikeViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        public string BrandName { get; set; }

        public string CreatorFullName { get; set; }

        public string EditorFullName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        /// <summary>
        ///     وضعیت کامنت محصول
        /// </summary>
        public StateType Status { get; set; }

        #endregion Public Properties
    }
}