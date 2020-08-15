using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.City
{
    public class CitySearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsState { get; set; }
        public Guid? ParentId { get; set; }
        public string Title { get; set; }
        public Guid? UserId { get; set; }

        #endregion Public Properties
    }
}