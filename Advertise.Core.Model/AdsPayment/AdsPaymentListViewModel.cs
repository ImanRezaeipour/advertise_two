using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.AdsPayment
{
    public class AdsPaymentListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<AdsPaymentViewModel> Adses { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public AdsPaymentSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}