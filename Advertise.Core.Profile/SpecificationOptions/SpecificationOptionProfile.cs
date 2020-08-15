using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.SpecificationOption;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.SpecificationOptions
{

    public class SpecificationOptionsProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public SpecificationOptionsProfile()
        {
            CreateMap<SpecificationOption, SpecificationOptionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<SpecificationOptionViewModel, SpecificationOption>(MemberList.None);

            CreateMap<SpecificationOption, SpecificationOptionViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryTitle, opts => opts.MapFrom(src => src.Specification.Category.Title))
                .ForMember(dest => dest.SpecificationTitle, opts => opts.MapFrom(src => src.Specification.Title));

            CreateMap<SpecificationOption, SpecificationOptionDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<SpecificationOption, SpecificationOptionEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<SpecificationOption, SpecificationOptionEditViewModel>(MemberList.None)
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Specification.CategoryId));

            CreateMap<SpecificationOption, SpecificationOptionListViewModel>(MemberList.None).ReverseMap();

            CreateMap<SpecificationOption, SpecificationOptionSearchRequest>(MemberList.None).ReverseMap();
        }
    }
}