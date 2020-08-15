using Advertise.Core.Models.Common;
using Advertise.Core.Models.User;
using System;

namespace Advertise.Core.Models.CompanyConversation
{
    /// <inheritdoc />

    public class CompanyConversationViewModel : BaseViewModel
    {
        #region Public Properties

        public string AvatarFileName { get; set; }
        public string Body { get; set; }
        public UserViewModel CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CurrentUserId { get; set; }
        public Guid Id { get; set; }
        public bool? Read { get; set; }
        public UserViewModel ReceivedBy { get; set; }

        #endregion Public Properties
    }
}