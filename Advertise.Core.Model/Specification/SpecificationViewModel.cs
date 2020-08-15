using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using Advertise.Core.Models.SpecificationOption;

namespace Advertise.Core.Models.Specification
{

    public class SpecificationViewModel : BaseViewModel
    {
        #region Public Properties

        public string CategoryAlias { get; set; }

        /// <summary>
        /// </summary>
        public Guid CategoryId { get; set; }

        public string CategoryImageFileName { get; set; }

        public string CategoryMetaTitle { get; set; }

        /// <summary>
        /// </summary>
        public string CategoryTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<SelectListItem> DropDownListSpecificationOptions { get; set; }
        public IEnumerable<SpecificationOptionViewModel> Options { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        /// <summary>
        /// </summary>
        public SpecificationType Type { get; set; }

        #endregion Public Properties
    }
}