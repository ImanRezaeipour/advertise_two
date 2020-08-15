using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CompanySlide
{

    public class CompanySlideSearchRequest : BaseSearchRequest
    {
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedById { get; set; }

        public Guid? CompanyId { get; set; }
    }
}