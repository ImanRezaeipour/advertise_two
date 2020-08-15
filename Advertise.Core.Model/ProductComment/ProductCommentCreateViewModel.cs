using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.ProductComment
{

    public class ProductCommentCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 3)]

        public string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid ProductId { get; set; }

        #endregion Public Properties
    }
}