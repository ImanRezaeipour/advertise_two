using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CatalogKeyword
{
    public class CatalogKeywordViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? KeywordId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}