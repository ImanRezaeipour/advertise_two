using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductComment
{
    public class ProductCommentListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ProductCommentViewModel> ProductComments { get; set; }
        public ProductCommentSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> StateTypeList { get; set; }

        #endregion Public Properties
    }
}