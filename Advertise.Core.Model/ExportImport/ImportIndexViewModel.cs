using System;
using System.Collections.Generic;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.ExportImport
{
    public class ImportIndexViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public Guid CategoryId { get; set; }

        #endregion Public Properties
    }
}