using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Plan
{

    public class PlanCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Code { get; set; }

        public ColorType? Color { get; set; }

        public IEnumerable<SelectListItem> ColorTypeList { get; set; }

        public bool? IsActive { get; set; }

        public PlanDurationType? PlanDuration { get; set; }

        public IEnumerable<SelectListItem> PlanDurationList { get; set; }

        public decimal? PreviousePrice { get; set; }

        public decimal? Price { get; set; }

        public Guid? RoleId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}