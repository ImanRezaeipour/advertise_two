using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyVideos
{
    public class CompanyVideoProfile : BaseProfile
    {
        public CompanyVideoProfile()
        {
            CreateMap<CompanyVideo, CompanyVideoCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyVideo, CompanyVideoEditViewModel>(MemberList.None).ReverseMap();
            
            CreateMap<CompanyVideo, CompanyVideoListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyVideo, CompanyVideoDetailViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyLogo,opts => opts.MapFrom(src => src.Company.LogoFileName))
                .ForMember(dest => dest.CompanyTitle,opts => opts.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias,opts => opts.MapFrom(src => src.Company.Alias));

            CreateMap<CompanyVideo, CompanyVideoSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<CompanyVideo, CompanyVideoViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyMobileNumber, opts => opts.MapFrom(src => src.Company.MobileNumber))
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opts => opts.MapFrom(src => src.Company.Alias))
                .ForMember(dest => dest.CompanyCode, opts => opts.MapFrom(src => src.Company.Code))
                .ForMember(dest => dest.CompanyLogoFileName, opts => opts.MapFrom(src => src.Company.LogoFileName))
                .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FullName));

            CreateMap<CompanyVideoViewModel, CompanyVideo>(MemberList.None);
        }
    }
}
