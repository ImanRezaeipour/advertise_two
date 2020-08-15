using Advertise.Core.Domains.Bags;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.Bag;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Bags
{

    public class BagProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public BagProfile()
        {
            CreateMap<BagViewModel, Bag>(MemberList.None);

            CreateMap<Bag, BagViewModel>(MemberList.None)
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.ProductImageFileName, opt => opt.MapFrom(src => src.Product.ImageFileName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Product.Company.Id))
                .ForMember(dest => dest.CompanyTitle, opt => opt.MapFrom(src => src.Product.Company.Title))
                .ForMember(dest => dest.CompanyAlias, opt => opt.MapFrom(src => src.Product.Company.Alias))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Product.Category.Id))
                .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Product.Category.Title))
                .ForMember(dest => dest.TotalProductPrice, opt => opt.MapFrom(src => src.Product.Price*src.ProductCount));

            CreateMap<Bag, BagUpdateMyInfoViewModel>(MemberList.None).ReverseMap();

            CreateMap<Bag, BagListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Bag, BagDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<Bag, BagMyInfoViewModel>(MemberList.None)
                .ForMember(dest=>dest.UserFirstName, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.FirstName))
                .ForMember(dest=>dest.UserLastName, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.LastName))
                .ForMember(dest=>dest.UserNationalCode, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.NationalCode))
                .ForMember(dest=>dest.UserAddress, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.Address.Extra))
                .ForMember(dest=>dest.PostalCode, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.Address.PostalCode))
                .ForMember(dest=>dest.PhoneNumber, opt=>opt.MapFrom(src=> src.CreatedBy.PhoneNumber))
                .ForMember(dest=>dest.MobileNumber, opt=>opt.MapFrom(src=> src.CreatedBy.Meta.HomeNumber));

            CreateMap<BagMyInfoViewModel, Bag>(MemberList.None);

            CreateMap<BagListViewModel,ReceiptOption >(MemberList.None).ReverseMap();
        }
    }
}