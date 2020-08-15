using System.Web;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.Home;
using Advertise.Core.Profiles.Common;
using AutoMapper;
//using DNTPersianUtils.Core;

namespace Advertise.Core.Profiles.Companies
{

    public class CompanyProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyProfile()
        {
            CreateMap<Company, CompanyCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Company, CompanyListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Company, CompanyRegisterViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyEditViewModel, Company>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Company, CompanyEditViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(src => src.Category.Title))
                .ForMember(dest => dest.CategoryAlias, opts => opts.MapFrom(src => src.Category.Alias));

            CreateMap< CompanyDetailViewModel, Company>(MemberList.None);
            CreateMap<Company, CompanyDetailViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryOptionProducts,opts => opts.MapFrom(src => src.Category.CategoryOption.Products))
                .ForMember(dest => dest.CategoryOptionCompanies,opts => opts.MapFrom(src => src.Category.CategoryOption.Products));

            CreateMap<Company, CompanyDetailInfoViewModel>(MemberList.None).ReverseMap();

            CreateMap<Company, CompanyInfoViewModel>(MemberList.None).ReverseMap();

            CreateMap<Company, CompanyAboutViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyViewModel, Company>(MemberList.None);

            CreateMap<Company, CompanyViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(src => src.Category.Title))
                .ForMember(dest => dest.CategoryAlias, opts => opts.MapFrom(src => src.Category.Alias))
                .ForMember(dest => dest.CategoryMetaTitle, opts => opts.MapFrom(src => src.Category.MetaTitle))
                .ForMember(dest => dest.UserAvatar, opts => opts.MapFrom(src => src.CreatedBy.Meta.AvatarFileName))
                .ForMember(dest => dest.UserDisplayName, opts => opts.MapFrom(src => src.CreatedBy.Meta.DisplayName))
                .ForMember(dest => dest.UserFullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FullName))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.CategoryOption, opts => opts.MapFrom(src => src.Category.CategoryOption));

            CreateMap<Address, CompanyEditViewModel>(MemberList.None).
                ForMember(dest => dest.Address, opts => opts.Ignore());

            CreateMap<Company, ProfileMenuViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryOption, opt => opt.MapFrom(src => src.Category.CategoryOption));

            CreateMap<Company, ProfileMenuViewModel>(MemberList.None);

            CreateMap<Company, SelectListItem>(MemberList.None)
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.Id));
        }
    }
}