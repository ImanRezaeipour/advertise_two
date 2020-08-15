using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Bag
{

    public class BagSearchRequest : BaseSearchRequest
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