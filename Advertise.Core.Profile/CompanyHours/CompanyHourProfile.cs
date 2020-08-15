using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyHour;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyHours
{
    public class CompanyHourProfile : BaseProfile
    {
        #region Public Constructors

        public CompanyHourProfile()
        {
            CreateMap<CompanyHour, CompanyHourViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyHour, CompanyHourEditViewModel>(MemberList.None)
                ;

            CreateMap<CompanyHourEditViewModel, CompanyHour>(MemberList.None)
                .ForMember(dest => dest.DayOfWeek ,opt => opt.Ignore());

        }

        #endregion Public Constructors
    }
}