using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanySlide
{
    public class CompanySlideCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Description { get; set; }
        public Guid? ProductId { get; set; }
        public IEnumerable<SelectListItem> EntityList { get; set; }
        public string ImageFileName { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}