using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyConversation
{

    public class CompanyConversationEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public Guid? ReceivedById { get; set; }

        public Guid? ReplyId { get; set; }

        #endregion Public Properties
    }
}