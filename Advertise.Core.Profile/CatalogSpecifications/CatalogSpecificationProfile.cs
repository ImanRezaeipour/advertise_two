using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CatalogSpecifications
{
    public class CatalogSpecificationProfile : BaseProfile
    {
        #region Public Constructors

        public CatalogSpecificationProfile()
        {
            CreateMap<CatalogSpecification, CatalogSpecificationViewModel>(MemberList.None)
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Specification.Type))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Specification.Options))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Specification.Title))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Specification.Order));

            CreateMap<CatalogSpecificationViewModel, CatalogSpecification>(MemberList.None);

            CreateMap<Specification, CatalogSpecificationViewModel>(MemberList.None)
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

            CreateMap<CatalogSpecificationViewModel, Specification>(MemberList.None);
        }

        #endregion Public Constructors
    }
}