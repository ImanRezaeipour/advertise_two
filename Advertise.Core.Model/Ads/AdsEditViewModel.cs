using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Ads
{
    /// <inheritdoc />

    public class AdsEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }


        public string Duration { get; set; }
        public string AdsOptionName { get; set; }

        public decimal? FinalPrice { get; set; }
        public int? Order { get; set; }
        public string ImageFileName { get; set; }

        [Required]
        public string Title { get; set; }

        #endregion Public Properties
    }
}