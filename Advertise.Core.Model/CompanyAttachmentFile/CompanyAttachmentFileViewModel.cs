using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyAttachmentFile
{

    public class CompanyAttachmentFileViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// مسیر فایل
        /// </summary>
        public string FileName { get; set; }

        public Guid Id { get; set; }
        
        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// </summary>
        public string FileIcon
        {
            get
            {
                switch (FileExtension)
                {
                    case "pdf":
                        return "Admin.FileConst_PdfIcon";
                    case "rar":
                        return "Admin.FileConst_RarIcon";
                    case "zip":
                        return "Admin.FileConst_ZipIcon";
                    default:
                        return "Admin.FileConst_FileIcon";
                }
            }
            set { }
        }

        #endregion Public Properties
    }
}