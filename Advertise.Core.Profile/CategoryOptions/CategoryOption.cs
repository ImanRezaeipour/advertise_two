using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CategoryOptions
{

    public class CategoryOptionProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CategoryOptionProfile()
        {
            CreateMap<CategoryOption, CategoryOptionViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryOption, CategoryOptionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryOption, CategoryOptionEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryOption, CategoryOptionListViewModel>(MemberList.None).ReverseMap();
        }
    }
}