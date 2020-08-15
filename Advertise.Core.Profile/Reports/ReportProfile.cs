using Advertise.Core.Domains.Reports;
using Advertise.Core.Models.Report;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Reports
{

    public class ReportProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public ReportProfile()
        {
            CreateMap<Report, ReportCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Report, ReportEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<Report, ReportViewModel>(MemberList.None);
            CreateMap< ReportViewModel, Report>(MemberList.None);
        }

        #endregion Public Constructors
    }
}