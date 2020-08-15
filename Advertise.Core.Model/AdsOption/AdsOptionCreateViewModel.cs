using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.AdsOption
{
    /// <inheritdoc />

    public class AdsOptionCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     عنوان جایگاه قرارگیری بنر
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     ترتیب نمایش هر بنر
        /// </summary>
        [Required]
        [RegularExpression("^[۰-۹0-9_]*$")]
        public int? Order { get; set; }

        /// <summary>
        ///     قیمت هر بنر
        /// </summary>
        [Required]
        [RegularExpression("^[۰-۹0-9_]*$")]
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