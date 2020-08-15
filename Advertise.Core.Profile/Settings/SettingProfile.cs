using Advertise.Core.Domains.Settings;
using Advertise.Core.Models.Setting;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Settings
{
    public class SettingProfile : BaseProfile
    {
        public SettingProfile()
        {
            CreateMap<Setting, SettingViewModel>(MemberList.None).ReverseMap();

            CreateMap<Setting, SettingEditViewModel>(MemberList.None).ReverseMap();
        }
    }
}
