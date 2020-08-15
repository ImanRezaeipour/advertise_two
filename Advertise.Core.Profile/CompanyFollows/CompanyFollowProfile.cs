using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyFollow;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyFollows
{

    public class CompanyFollowProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyFollowProfile()
        {
            CreateMap<CompanyFollow, CompanyFollowCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyFollow, CompanyFollowEditViewModel>(MemberList.None)
                .ReverseMap()
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore())
                .ForMember(dest => dest.FollowedById, opt => opt.Ignore());

            CreateMap< CompanyFollowEditViewModel, CompanyFollow>(MemberList.None).ReverseMap();

            CreateMap<CompanyFollow, CompanyFollowListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyFollowViewModel, CompanyFollow>(MemberList.None).ReverseMap()
                .ForMember(dest => dest.AvatarFileName, opt => opt.MapFrom(surc => surc.FollowedBy.Meta.AvatarFileName))
                .ForMember(dest => dest.FollowedById, opt => opt.MapFrom(surc => surc.FollowedById))
               // .ForMember(dest => dest.FullName, opt => opt.MapFrom(surc => surc.FollowedBy.Meta.FullName != " " ? surc.FollowedBy.Meta.FullName :( surc.FollowedBy.Meta.DisplayName != " " ? surc.FollowedBy.Meta.DisplayName :( surc.FollowedBy.UserName != " " ? surc.FollowedBy.UserName : surc.FollowedBy.Email))))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(surc => surc.FollowedBy.Meta.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(surc => surc.FollowedBy.Meta.PhoneNumber))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(surc => surc.FollowedBy.UserName));
        }
    }
}