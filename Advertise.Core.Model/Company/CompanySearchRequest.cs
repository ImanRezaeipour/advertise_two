using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Company
{

    public class CompanySearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public string CategoryCode { get; set; }
        public Guid? CategoryId { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? CreatedById { get; set; }

        /// <summary>
        /// </summary>
        public StateType? State { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}