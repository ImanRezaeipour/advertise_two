using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductReview;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductReviews
{

    public class ProductReviewProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductReviewProfile()
        {
            CreateMap<ProductReview, ProductReviewCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductReview, ProductReviewDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap< ProductReviewEditViewModel, ProductReview>(MemberList.None);

            CreateMap<ProductReview, ProductReviewEditViewModel>(MemberList.None);

            CreateMap<ProductReview, ProductReviewListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductReview, ProductReviewViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductReview, ProductReviewSearchRequest>(MemberList.None).ReverseMap();
        }
    }
}