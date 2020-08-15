using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyConversation
{
    public class CompanyConversationListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyConversationViewModel> CompanyConversationList { get; set; }
        public IEnumerable<CompanyConversationViewModel> Conversations { get; set; }
        public IEnumerable<SelectListItem> CreatedIdConversationList { get; set; }
        public Guid OwnedById { get; set; }
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public CompanyConversationSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }

        public IEnumerable<SelectListItem> SortMemberList { get; set; }

        #endregion Public Properties
    }
}