using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.AdsOption
{
   public class AdsOptionSearchRequest : BaseSearchRequest
    {
       public AdsType? Type { get; set; }
       public DateTime? Day { get; set; }
           public AdsPositionType? Position { get; set; }
           public Guid? CreatedById { get; set; }
    }
}
