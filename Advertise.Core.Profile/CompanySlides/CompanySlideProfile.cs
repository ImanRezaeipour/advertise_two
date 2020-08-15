using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanySlide;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanySlides
{

    public class CompanySlideProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanySlideProfile()
        {
            CreateMap<CompanySlide, CompanySlideViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanySlide, CompanySlideCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanySlide, CompanySlideEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanySlide, CompanySlideListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanySlide, CompanySlideBulkEditViewModel>(MemberList.None).ReverseMap();
        }
    }
}