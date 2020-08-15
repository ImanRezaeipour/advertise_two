using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyReview
{
    public class CompanyReviewListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> ActiveList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public IEnumerable<CompanyReviewViewModel> CompanyReviews { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyReviewSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        public bool IsMyself { get; set; }

        #endregion Public Properties
    }
}