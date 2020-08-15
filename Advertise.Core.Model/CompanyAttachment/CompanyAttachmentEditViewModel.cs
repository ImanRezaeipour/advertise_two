using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyAttachmentFile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyAttachment
{

    public class CompanyAttachmentEditViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyAttachmentFileViewModel> CompanyAttachmentFile { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}