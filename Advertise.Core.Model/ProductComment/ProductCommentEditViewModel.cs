using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.ProductComment
{

    public class ProductCommentEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>

        public string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid ProductId { get; set; }

        #endregion Public Properties
    }
}