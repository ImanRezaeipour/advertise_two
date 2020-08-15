using System;
using System.Collections.Generic;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyVideoFile;

namespace Advertise.Core.Models.CompanyVideo
{
    public class CompanyVideoDetailViewModel : BaseViewModel
    {
        public  string Title { get; set; }
        public  string CompanyTitle { get; set; }
        public  string CompanyLogo { get; set; }
        public  string CompanyAlias { get; set; }
        public  int? Order { get; set; }
        public IEnumerable<CompanyVideoFileViewModel> VideoFiles { get; set; }
        public IEnumerable<CompanyVideoViewModel> Galleries { get; set; }
        public bool IsMySelf { get; set; }

    }
}
