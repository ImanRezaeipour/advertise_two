using System.Collections.Generic;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.Product;

namespace Advertise.Core.Models.Home
{
    /// <summary>
    /// 
    /// </summary>
    public class LandingPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ProductViewModel> LastProductItemList { get; set; }

        public IEnumerable<ProductViewModel> LastMobileProductItemList { get; set; }

        public IEnumerable<CompanyViewModel> LastMobileCompanyItemList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ProductViewModel> MostLikedItemList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ProductViewModel> MostVisitedItemList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ProductViewModel> MyLastVisitItemList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CompanyViewModel> LastCompanyItemList { get; set; }

        #endregion Public Properties
    }
}