using System;
using System.Collections.Generic;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyVideoFile;
using Advertise.Core.Types;

namespace Advertise.Core.Models.CompanyVideo
{
    public class CompanyVideoViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// عنوان  ویدئو
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// الویت ویدئو
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// وضعیت تائید یا عدم تائید 
        /// </summary>
        public StateType State { get; set; }
        /// <summary>
        /// عنوان کمپانی
        /// </summary>
        public string CompanyTitle { get; set; }
        public string CompanyMobileNumber { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyAlias { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string FullName { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string FileName { get; set; }
        public IList<CompanyVideoFileViewModel> VideoFiles { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
