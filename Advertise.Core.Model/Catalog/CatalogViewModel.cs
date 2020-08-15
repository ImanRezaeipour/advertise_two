using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Catalog
{
    public class CatalogViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ManufacturerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        public string ImageFileName { get; set; }

        #endregion Public Properties
    }
}