using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ReceiptOption
{
    public class ReceiptOptionListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }

        /// <summary>
        /// </summary>
        public IEnumerable<ReceiptOptionViewModel> ReceiptOptions { get; set; }

        public ReceiptOptionSearchRequest SearchRequest { get; set; }

        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}