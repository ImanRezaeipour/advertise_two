using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Tag
{

    public class TagCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public ColorType Color { get; set; }

        public IEnumerable<SelectListItem> ColorTypeList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CostValue { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string DurationDay { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LogoFileName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}