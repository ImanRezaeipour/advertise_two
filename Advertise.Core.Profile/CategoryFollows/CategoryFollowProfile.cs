using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.CategoryFollow;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CategoryFollows
{

    public class CategoryFollowProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CategoryFollowProfile()
        {
            CreateMap<CategoryFollow, CategoryFollowCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryFollow, CategoryFollowEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryFollow, CategoryFollowViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(src => src.Category.Title))
                .ForMember(dest => dest.CategoryAlias, opts => opts.MapFrom(src => src.Category.Alias))
                .ForMember(dest => dest.CategoryMetaTitle, opts => opts.MapFrom(src => src.Category.MetaTitle))
                .ForMember(dest => dest.CategoryImageFileName, opts => opts.MapFrom(src => src.Category.ImageFileName))
                .ForMember(dest => dest.ParentCategoryMetaTitle, opts => opts.MapFrom(src => src.Category.Parent.MetaTitle))
                .ForMember(dest => dest.ParentCategoryTitle, opts => opts.MapFrom(src => src.Category.Parent.Title))
                .ForMember(dest => dest.ParentCategoryAlias, opts => opts.MapFrom(src => src.Category.Parent.Alias));
        }
    }
}