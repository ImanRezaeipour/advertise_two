using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanySocial;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanySocials
{

    public class CompanySocialProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanySocialProfile()
        {
            CreateMap<CompanySocial, CompanySocialCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap< CompanySocialEditViewModel, CompanySocial>(MemberList.None)
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore());

            CreateMap<CompanySocial, CompanySocialEditViewModel>(MemberList.None);
              
            CreateMap<CompanySocial, CompanySocialListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanySocial, CompanySocialSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<CompanySocial, CompanySocialViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Company.Title));
        }
    }
}