using Advertise.Core.Domains.Users;
using Advertise.Core.Models.Account;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.User;
using Advertise.Core.Models.UserOperator;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Users
{

    public class UserProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, ProfileViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, UserCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<UserMeta, UserCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<User, UserOperatorCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, UserEditViewModel>(MemberList.None);

            CreateMap<UserMeta, ProfileHeaderViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserMeta, DashboardHeaderViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserMeta, UserEditMeViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserEditViewModel, UserEditMeViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, UserEditMeViewModel>(MemberList.None)
                .ForMember(dest => dest.AvatarFileName, opt => opt.MapFrom(src => src.Meta.AvatarFileName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Meta.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Meta.LastName))
                .ForMember(dest => dest.HomeNumber, opt => opt.MapFrom(src => src.Meta.HomeNumber))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.Meta.NationalCode))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Meta.Address))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Meta.Gender));

            CreateMap<UserEditMeViewModel, UserMeta>(MemberList.None);


            CreateMap<UserEditMeViewModel, UserEditViewModel>(MemberList.None);

            CreateMap<UserEditViewModel, User>(MemberList.None)
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore());

            CreateMap<UserEditMeViewModel, User>(MemberList.None)
                .ForMember(dest => dest.Email, opt => opt.Ignore());

            CreateMap<User, UserDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserMeta, UserDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, UserSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<User, UserListViewModel>(MemberList.None).ReverseMap();

            CreateMap<User, RegisterViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserMeta, ProfileHeaderViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserMeta, UserHeaderViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}