using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyOfficial;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyOfficials
{
    public class CompanyOfficialProfile : BaseProfile
    {
        #region Public Constructors

        public CompanyOfficialProfile()
        {
            CreateMap<CompanyOfficial, CompanyOfficialViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyTitle, opt => opt.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opt => opt.MapFrom(src => src.Company.Alias));

            CreateMap<CompanyOfficialViewModel, CompanyOfficial>(MemberList.None);

            CreateMap<CompanyOfficial, CompanyOfficialCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<CompanyOfficial, CompanyOfficialListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyOfficial, CompanyOfficialEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}