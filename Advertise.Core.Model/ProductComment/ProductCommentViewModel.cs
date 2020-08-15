﻿using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductComment
{

    public class ProductCommentViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid Id { get; set; }
        public bool InitLike { get; set; }
        public int LikeCount { get; set; }
        public string ProductCode { get; set; }
        public string ProductImageFileName { get; set; }
        public string ProductTitle { get; set; }

        public string UserAvatar { get; set; }

        public string UserDisplayName { get; set; }
        public string UserFullName { get; set; }
        public string UserUserName { get; set; }

        #endregion Public Properties
    }
}