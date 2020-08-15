using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductImage;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ProductImages
{
    public class ProductImageProfile : BaseProfile
    {
        #region Public Constructors

        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageViewModel>(MemberList.None)
                .ForMember(dest => dest.ProductTitle, opts => opts.MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.ProductImageFileName, opts => opts.MapFrom(src => src.Product.ImageFileName))
                .ForMember(dest => dest.ProductCode, opts => opts.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.CompanyCode, opts => opts.MapFrom(src => src.Product.Company.Code))
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.Product.Company.Title));

            CreateMap<ProductImage, ProductImageCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductImage, ProductImageEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductImage, ProductImageDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProductImage, ProductImageViewModel>(MemberList.None).ReverseMap();

            CreateMap<CatalogImage, ProductImageViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}