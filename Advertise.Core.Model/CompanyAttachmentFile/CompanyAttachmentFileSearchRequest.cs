using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyAttachmentFile
{

    public class CompanyAttachmentFileSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyAttachmentId { get; set; }
        public Guid? Id { get; set; }
        public Guid? CreatedById { get; set; }
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}