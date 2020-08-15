using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyImageFile
{

    public class CompanyImageFileViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// مسیر فایل
        /// </summary>
        public string FileName { get; set; }

        public Guid Id { get; set; }

        #endregion Public Properties
    }
}