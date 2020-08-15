using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Tag
{
    public class TagSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        public bool? IsActive { get; set; }
        public Guid? ProductId { get; set; }

        #endregion Public Properties
    }
}