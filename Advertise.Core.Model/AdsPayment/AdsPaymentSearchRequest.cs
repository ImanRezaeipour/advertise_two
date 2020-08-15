using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.AdsPayment
{
   public class AdsPaymentSearchRequest:BaseSearchRequest
    {
        public Guid? CreatedById { get; set; }
        public bool? IsApprove { get; set; }
    }
}
