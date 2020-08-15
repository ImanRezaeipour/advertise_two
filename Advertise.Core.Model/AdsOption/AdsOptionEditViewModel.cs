using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.AdsOption
{
    /// <inheritdoc />

    public class AdsOptionEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        /// <summary>
        ///     عنوان جایگاه قرارگیری بنر
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     ترتیب نمایش هر بنر
        /// </summary>
        [Required]
        public int? Order { get; set; }

        /// <summary>
        ///     قیمت هر بنر
        /// </summary>
        [Required]
        public decimal? Price { get; set; }

        [Required]
        public AdsPositionType? PositionType { get; set; }

        public IEnumerable<SelectListItem> PositionList { get; set; }

        [Required]
        public AdsType? Type { get; set; }

        public IEnumerable<SelectListItem> TypeList { get; set; }

        #endregion Public Properties
    }
}