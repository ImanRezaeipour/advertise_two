using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyImageFile;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;

namespace Advertise.Core.Models.CompanyImage
{

    public class CompanyImageViewModel : BaseViewModel
    {
        #region Public Properties

        public string CompanyAlias { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyLogoFileName { get; set; }
        public string CompanyMobileNumber { get; set; }
        public string CompanyTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FileName { get; set; }
        public string FullName { get; set; }
        public Guid Id { get; set; }

        public IEnumerable<CompanyImageFileViewModel> ImageFiles { get; set; }

        /// <summary>
        /// الویت عکس
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        /// <summary>
        /// نام نمایشی عکس
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}