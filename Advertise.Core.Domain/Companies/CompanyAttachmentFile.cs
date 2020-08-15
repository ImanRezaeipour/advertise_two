using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Companies
{
   public class CompanyAttachmentFile : BaseAttachment
    {
        public virtual int? Order { get; set; }
        public virtual CompanyAttachment CompanyAttachment { get; set; }
        public virtual Guid? CompanyAttachmentId { get; set; }
    }
}
