using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.ProductCommentLike
{
    public class ProductCommentLikeListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public IEnumerable<ProductCommentLikeViewModel> ProductComments { get; set; }
        public ProductCommentLikeSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}