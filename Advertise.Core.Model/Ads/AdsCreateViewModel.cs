using Advertise.Core.Models.AdsOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Ads
{
    /// <inheritdoc />

    public class AdsCreateViewModel : BaseViewModel
    {
        #region Public Properties

        [Required]
        public Guid? AdsOptionId { get; set; }

        public IEnumerable<SelectListItem> AdsOptionPositionList { get; set; }
        public IEnumerable<AdsOptionViewModel> AdsOptions { get; set; }
        public IEnumerable<SelectListItem> AdsOptionTypeList { get; set; }
        public string CategeoryListJson { get; set; }
        public Guid? CategoryId { get; set; }
        public IEnumerable<SelectListItem> DurationList { get; set; }

        [Required]
        public DurationType? DurationType { get; set; }

        public Guid? EntityId { get; set; }
        public IEnumerable<SelectListItem> EntityList { get; set; }
        public string EntityName { get; set; }
        public decimal? FinalPrice { get; set; }
        public string ImageFileName { get; set; }

        [Required]
        public string Title { get; set; }

        #endregion Public Properties
    }
}