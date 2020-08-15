using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.CompanyCatalog
{
    public class CompanyCatalogViewModel : BaseViewModel
    {
        /// <summary>
        ///     
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public decimal? PreviousPrice { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public decimal? DiscountPercent { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public SellType? Sell { get; set; }
    }
}