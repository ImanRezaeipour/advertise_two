using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.UserBudget
{
    public class UserBudgetListViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public UserBudgetSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<UserBudgetViewModel> UserBudgets { get; set; }

        #endregion Public Properties
    }
}