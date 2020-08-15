using System.Linq;
using Advertise.Core.Models.AdsPayment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.AdsPayment
{

    public class AdsPaymentProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public AdsPaymentProfile()
        {
            CreateMap<Domains.Adses.AdsPayment, AdsPaymentCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<Domains.Adses.AdsPayment, AdsPaymentListViewModel>(MemberList.None).ReverseMap();
            CreateMap<Domains.Adses.AdsPayment, AdsPaymentViewModel>(MemberList.None)
                .ForMember(dest => dest.AdsImage, opt => opt.MapFrom(src => src.Ads.ImageFileName))
                .ForMember(dest => dest.AdsDuration,opt => opt.MapFrom(src => src.Ads.DurationType.Value))
                .ForMember(dest => dest.AdsType,opt => opt.MapFrom(src => src.Ads.AdsOption.Type))
                .ForMember(dest => dest.AdsPositionType,opt => opt.MapFrom(src => src.Ads.AdsOption.PositionType))
                .ForMember(dest => dest.StartDay, opt => opt.MapFrom(src => src.Ads.Reserves.FirstOrDefault(item => item.AdsId == src.AdsId).Day));
        }
    }
}