using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyImages
{

    public class CompanyImageProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyImageProfile()
        {
            CreateMap<CompanyImage, CompanyImageCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyMobileNumber, opts => opts.MapFrom(src => src.Company.MobileNumber))
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opts => opts.MapFrom(src => src.Company.Alias))
                .ForMember(dest => dest.CompanyCode, opts => opts.MapFrom(src => src.Company.Code))
                .ForMember(dest => dest.CompanyLogoFileName, opts => opts.MapFrom(src => src.Company.LogoFileName))
                .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FullName));

            CreateMap<CompanyImageViewModel, CompanyImage>(MemberList.None);
        }
    }
}