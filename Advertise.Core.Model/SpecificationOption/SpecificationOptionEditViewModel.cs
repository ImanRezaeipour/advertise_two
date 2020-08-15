using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.SpecificationOption
{
    public class SpecificationOptionEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CategoryId { get; set; }

        public Guid Id { get; set; }
        public IEnumerable<SpecificationOptionViewModel> Options { get; set; }

        public Guid SpecificationId { get; set; }

        #endregion Public Properties
    }
}