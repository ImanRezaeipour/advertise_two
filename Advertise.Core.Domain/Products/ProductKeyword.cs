using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Keywords;
using System;

namespace Advertise.Core.Domains.Products
{

    public class ProductKeyword : BaseEntity
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
        public virtual Product Product { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? ProductId { get; set; }

        #endregion Public Properties
    }
}