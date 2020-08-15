using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyConversation
{
    /// <inheritdoc />

    public class CompanyConversationMyListViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyConversationViewModel> CompanyConversationList { get; set; }
        public IEnumerable<SelectListItem> CreatedIdConversationList { get; set; }
        public Guid OwnedById { get; set; }

        #endregion Public Properties
    }
}