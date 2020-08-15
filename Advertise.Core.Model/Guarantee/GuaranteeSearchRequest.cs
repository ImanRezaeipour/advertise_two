using System;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Guarantee
{
    public class GuaranteeSearchRequest : BaseSearchRequest
    {

        /// <summary>
        ///
        /// </summary>

        public Guid? CreatedById { get; set; }
       
    }
}