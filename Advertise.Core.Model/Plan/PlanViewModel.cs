using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Plan
{

    public class PlanViewModel : BaseViewModel
    {
        #region Public Properties

        [Required]
        public string Code { get; set; }

        public DateTime? CreatedOn { get; set; }

        [Required]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public string DurationDay { get; set; }

        public Guid Id { get; set; }

        [Required]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public decimal? Price { get; set; }

        public Guid? RoleId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        [Required]
        public string Title { get; set; }

        #endregion Public Properties
    }
}