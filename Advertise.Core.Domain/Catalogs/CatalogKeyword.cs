using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Keywords;

namespace Advertise.Core.Domains.Catalogs
{

    public class CatalogKeyword : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Keyword Keyword { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? KeywordId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Catalog Catalog { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? CatalogId { get; set; }

        #endregion Public Properties
    }
}