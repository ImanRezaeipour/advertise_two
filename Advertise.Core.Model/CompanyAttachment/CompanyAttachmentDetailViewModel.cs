using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using Advertise.Core.Models.CompanyAttachmentFile;

namespace Advertise.Core.Models.CompanyAttachment
{
    public class CompanyAttachmentDetailViewModel : BaseViewModel
    {
        #region Public Properties
        
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string RejectDescription { get; set; }

        public StateType State { get; set; }

        public string Title { get; set; }

        public bool IsMyself { get; set; }

        public IEnumerable<CompanyAttachmentFileViewModel> Files { get; set; }

        public string CompanyLogo { get; set; }

        public string CompanyAlias { get; set; }

        public string CompanyTitle { get; set; }

        #endregion Public Properties
    }
}