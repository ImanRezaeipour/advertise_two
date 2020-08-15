using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyAttachments
{

    public class CompanyAttachmentProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyAttachmentProfile()
        {
            CreateMap<CompanyAttachment, CompanyAttachmentCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyAttachment, CompanyAttachmentEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyAttachment, CompanyAttachmentListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyAttachment, CompanyAttachmentDetailViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opts => opts.MapFrom(src => src.Company.Alias))
                .ForMember(dest => dest.CompanyLogo, opts => opts.MapFrom(src => src.Company.LogoFileName));

            CreateMap<CompanyAttachment, CompanyAttachmentSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<CompanyAttachment, CompanyAttachmentViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyMobileNumber, opts => opts.MapFrom(src => src.Company.MobileNumber))
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opts => opts.MapFrom(src => src.Company.Alias))
                .ForMember(dest => dest.CompanyCode, opts => opts.MapFrom(src => src.Company.Code))
                .ForMember(dest => dest.CompanyLogoFileName, opts => opts.MapFrom(src => src.Company.LogoFileName))
                .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FullName));

            CreateMap<CompanyAttachmentViewModel, CompanyAttachment>(MemberList.None);
        }
    }
}