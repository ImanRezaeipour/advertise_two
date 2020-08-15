using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyReviews
{

    public class CompanyReviewProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyReviewProfile()
        {
            CreateMap<CompanyReview, CompanyReviewCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyReview, CompanyReviewDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyReview, CompanyReviewListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyReview, CompanyReviewViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyReview, CompanyReviewSearchRequest>(MemberList.None).ReverseMap();

            CreateMap< CompanyReviewEditViewModel, CompanyReview>(MemberList.None)
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore());

            CreateMap<CompanyReview, CompanyReviewEditViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyTitle, opt => opt.MapFrom(src => src.Company.Title));
        }
    }
}