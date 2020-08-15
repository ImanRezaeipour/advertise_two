using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Complaint
{

    public class ComplaintSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CreatedById { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? IsActive { get; set; }

        #endregion Public Properties
    }
}