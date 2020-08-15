using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyVideoFile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyVideo
{
    public class CompanyVideoEditViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyVideoFileViewModel> CompanyVideoFile { get; set; }
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}