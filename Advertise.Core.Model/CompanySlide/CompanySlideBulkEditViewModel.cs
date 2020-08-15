using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanySlide
{
    public class CompanySlideBulkEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<CompanySlideViewModel> SlideList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> ProductList { get; set; }

        #endregion Public Properties
    }
}