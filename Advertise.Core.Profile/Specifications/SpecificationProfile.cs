using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.Specification;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Specifications
{

    public class SpecificationProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public SpecificationProfile()
        {
            CreateMap<Specification, SpecificationViewModel>(MemberList.None).ReverseMap();

            CreateMap<Specification, SpecificationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Specification, SpecificationEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<Specification, SpecificationListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Specification, SpecificationSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<Specification, SpecificationDetailViewModel>(MemberList.None).ReverseMap();
        }
    }
}