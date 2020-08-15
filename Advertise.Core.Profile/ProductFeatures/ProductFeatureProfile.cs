using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductFeature;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductFeatures
{
    public class ProductFeatureProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ProductFeatureProfile()
        {
            CreateMap< ProductFeatureEditViewModel, ProductFeature>(MemberList.None).ReverseMap();

            CreateMap<ProductFeature, ProductFeatureEditViewModel>(MemberList.None)
                .ForMember(dest => dest.ProductId, opt => opt.Ignore());

            CreateMap<ProductFeature, ProductFeatureCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductFeature, ProductFeatureViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductFeature, ProductFeatureDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CatalogFeature, ProductFeatureViewModel>(MemberList.None).ReverseMap();
        }
    }
}