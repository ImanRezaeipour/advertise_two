using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductComment
{

    public class ProductCommentSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CommentedById { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}