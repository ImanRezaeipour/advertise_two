using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.Bag
{

    public class BagListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<BagViewModel> Bags { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public BagSearchRequest SearchRequest { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal TotalPrice { get; set; }

        public decimal TotalProductListPrice
        {
            get
            {
                decimal total = 0;
                foreach (var bag in Bags)
                {
                    total += bag.TotalProductPrice;
                }
                return total;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string UserDisplayName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}