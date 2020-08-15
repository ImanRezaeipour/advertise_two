using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Product
{

    public class ProductBulkEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string CatalogListJson { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryListJson { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> ColorList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> GuaranteeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<ProductBulkViewModel> ProductBulks { get; set; }

        #endregion Public Properties
    }
}