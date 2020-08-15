using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.SpecificationOption
{

    public class SpecificationOptionSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public Guid? SpecificationId { get; set; }

        #endregion Public Properties
    }
}