using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.Receipt;
using Advertise.Core.Models.ReceiptPayment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Receipts
{

    public class ReceiptProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public ReceiptProfile()
        {
            CreateMap<Receipt, ReceiptCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptPayment, ReceiptPaymentCallbackViewModel>(MemberList.None).ReverseMap();

            CreateMap<Receipt, ReceiptListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Receipt, ReceiptPreviewViewModel>(MemberList.None).ReverseMap();

            CreateMap<Receipt, ReceiptViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptViewModel, Receipt>(MemberList.None)
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap< ReceiptEditViewModel, Receipt>(MemberList.None);

            CreateMap<Receipt, ReceiptEditViewModel>(MemberList.None);

            CreateMap<Receipt, ReceiptDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<Receipt, ReceiptSearchRequest>(MemberList.None).ReverseMap();

            //CreateMap<Receipt, ReceiptNewViewModel>(MemberList.None)
            //    .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.OwnedBy.Meta.FirstName))
            //    .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.OwnedBy.Meta.LastName))
            //    .ForMember(dest => dest.UserNationalCode, opt => opt.MapFrom(src => src.OwnedBy.Meta.NationalCode))
            //    .ForMember(dest => dest.UserAddress, opt => opt.MapFrom(src => src.OwnedBy.Meta.Address.Extra))
            //    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.OwnedBy.Meta.Address.PostalCode))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.OwnedBy.PhoneNumber))
            //    .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.OwnedBy.Meta.HomeNumber));
        }
    }
}