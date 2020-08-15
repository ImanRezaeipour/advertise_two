using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Email
{

    public class EmailSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}