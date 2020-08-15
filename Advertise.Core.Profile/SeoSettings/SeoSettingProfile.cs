using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.SeoSetting;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.SeoSettings
{
    /// <summary>
    /// 
    /// </summary>
    public class SeoSettingProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        public SeoSettingProfile()
        {
            CreateMap<SeoSetting, SeoSettingViewModel>(MemberList.None).ReverseMap();

            CreateMap<SeoSetting, SeoSettingEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}