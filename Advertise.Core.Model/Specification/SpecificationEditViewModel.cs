using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Models.SpecificationOption;

namespace Advertise.Core.Models.Specification
{
    public class SpecificationEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CategoryId { get; set; }
        public string CategoryTitle { get; set; }


        public string Description { get; set; }

        public Guid Id { get; set; }

        public int Order { get; set; }


        public string Title { get; set; }

        public SpecificationType Type { get; set; }

        public IEnumerable<SelectListItem> TypeList { get; set; }

        public IEnumerable<SpecificationOptionViewModel> Options { get; set; }

        #endregion Public Properties
    }
}