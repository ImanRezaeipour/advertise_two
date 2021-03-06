using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductKeyword
{
    public class ProductKeywordEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? KeywordId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ProductId { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}