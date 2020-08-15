using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Address
{
    public class AddressListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<AddressViewModel> Addresses { get; set; }

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public AddressSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}