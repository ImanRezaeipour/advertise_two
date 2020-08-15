using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.Category;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Categories
{

    public class CategoryProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CategoryProfile()
        {
            CreateMap<Category, CategoryCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Category, CategoryListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Category, CategoryViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryOption, opt => opt.MapFrom(src => src.CategoryOption));

            CreateMap<CategoryViewModel, Category>(MemberList.None);

            CreateMap<Category, CategoryEditViewModel>(MemberList.None)
                .ForMember(dest => dest.ParentId, opt => opt.Ignore());

            CreateMap<CategoryEditViewModel, Category>(MemberList.None);

            CreateMap<Category, CategoryDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryViewModel, CategoryCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryViewModel, CategoryEditViewModel>(MemberList.None).ReverseMap();
        }
    }
}