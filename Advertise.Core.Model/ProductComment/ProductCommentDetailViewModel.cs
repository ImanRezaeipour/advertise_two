using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductComment
{

    public class ProductCommentDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     وضعیت کامنت محصول
        /// </summary>
        public StateType Status { get; set; }

        #endregion Public Properties
    }
}