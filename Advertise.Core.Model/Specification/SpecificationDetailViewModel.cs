using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Specification
{

    public class SpecificationDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public virtual Guid CategoryId { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public SpecificationType Type { get; set; }

        #endregion Public Properties
    }
}