using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserSetting;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.UserSettings
{

    public class UserSettingProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public UserSettingProfile()
        {
            CreateMap<UserSetting, UserSettingEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserSetting, UserSettingSearchRequest>(MemberList.None).ReverseMap();

            CreateMap<UserSetting, UserSettingViewModel>(MemberList.None)
                .ForMember(dest => dest.UserLastName ,opt => opt.MapFrom(sur => sur.CreatedBy.Meta.LastName));

            CreateMap<UserSetting, UserSettingListViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}