using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.SpecificationOption;

namespace Advertise.Core.Models.Specification
{

    public class SpecificationCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public Guid CategoryId { get; set; }

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

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> TypeList { get; set; }

        public IEnumerable<SpecificationOptionViewModel> Options { get; set; }

        #endregion Public Properties
    }
}