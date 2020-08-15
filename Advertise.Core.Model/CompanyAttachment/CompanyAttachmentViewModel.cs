using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyAttachmentFile;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyAttachment
{

    public class CompanyAttachmentViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CompanyAttachmentFileViewModel> AttachmentFiles { get; set; }

        public string CompanyAlias { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string CompanyMobileNumber { get; set; }

        public string CompanyTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// الویت عکس
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        ///// <summary>
        ///// مسیر فایل
        ///// </summary>
        //public string FileName { get; set; }
        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}