﻿using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyConversation
{
    public class CompanyConversationCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }

        public Guid? ReceivedById { get; set; }

        public Guid? ReplyId { get; set; }

        #endregion Public Properties
    }
}