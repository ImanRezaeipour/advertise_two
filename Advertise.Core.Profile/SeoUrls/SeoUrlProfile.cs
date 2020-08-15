using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.SeoUrl;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.SeoUrls
{

    public class SeoUrlProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        public SeoUrlProfile()
        {
            CreateMap<SeoUrl, SeoUrlCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<SeoUrl, SeoUrlEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<SeoUrl, SeoUrlViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}