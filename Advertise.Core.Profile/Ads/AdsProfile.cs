using Advertise.Core.Models.Ads;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Ads
{
   public class AdsProfile : BaseProfile
    {
        public AdsProfile()
        {
            CreateMap<Domains.Adses.Ads, AdsCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<AdsEditViewModel, Domains.Adses.Ads>(MemberList.None)
                .ForMember(dest => dest.AdsOptionId, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.EntityId, opt => opt.Ignore())
                .ForMember(dest => dest.FinalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.TargetId, opt => opt.Ignore());

            CreateMap<Domains.Adses.Ads, AdsEditViewModel>(MemberList.None)
                .ForMember(dest => dest.AdsOptionName,opt =>opt.MapFrom(src => src.AdsOption.Title))
                .ForMember(dest => dest.Duration,opt =>opt.MapFrom(src => src.DurationType.Value));
        }
    }
}
