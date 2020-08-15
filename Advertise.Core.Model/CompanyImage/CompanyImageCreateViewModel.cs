using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyImageFile;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyImage
{

    public class CompanyImageCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public IEnumerable<CompanyImageFileViewModel> CompanyImageFile { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}