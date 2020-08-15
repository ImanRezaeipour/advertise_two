using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.CategoryReview;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CategoryReviews
{

    public class CategoryReviewProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CategoryReviewProfile()
        {
            CreateMap<CategoryReview, CategoryReviewCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryReview, CategoryReviewEditViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore());

            CreateMap<CategoryReviewEditViewModel, CategoryReview>(MemberList.None);

            CreateMap<CategoryReview, CategoryReviewDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryReview, CategoryReviewListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CategoryReview, CategoryReviewViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(src => src.Category.Title));

            CreateMap<CategoryReview, CategoryReviewSearchRequest >(MemberList.None).ReverseMap();
        }
    }
}