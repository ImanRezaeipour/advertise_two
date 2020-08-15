using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Product
{

    public class ProductEditCatalogViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public int? AvailableCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CatalogListJson { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CategoryListJson { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ColorType? Color { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> ColorList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? GuaranteeId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> GuaranteeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? IsSecondHand { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SecondHandCode { get; set; }
        public string GuaranteeTitle { get; set; }

        #endregion Public Properties
    }
}