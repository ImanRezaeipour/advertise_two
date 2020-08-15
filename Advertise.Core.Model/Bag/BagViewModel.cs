using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Bag
{

    public class BagViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CategoryTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CompanyAlias { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CompanyTitle { get; set; }

        /// <summary>
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductImageFileName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProductTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal TotalProductPrice { get; set; }

        #endregion Public Properties
    }
}