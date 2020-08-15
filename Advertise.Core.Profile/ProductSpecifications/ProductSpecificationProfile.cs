using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Specifications;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductSpecifications
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductSpecificationProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductSpecificationProfile()
        {
            CreateMap<Specification, ProductSpecificationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Specification, ProductSpecificationEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductSpecification, ProductSpecificationEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductSpecification, ProductSpecificationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductSpecification, ProductSpecificationDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductSpecification, ProductSpecificationViewModel>(MemberList.None).ReverseMap();

            CreateMap<CatalogSpecification, ProductSpecificationViewModel>(MemberList.None).ReverseMap();
        }
    }
}