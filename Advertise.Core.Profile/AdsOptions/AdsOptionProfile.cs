using Advertise.Core.Domains.Adses;
using Advertise.Core.Models.AdsOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.AdsOptions
{

    public class AdsOptionProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public AdsOptionProfile()
        {
            CreateMap<AdsOption, AdsOptionViewModel>(MemberList.None).ReverseMap();

            CreateMap<AdsOption, AdsOptionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<AdsOption, AdsOptionEditViewModel>(MemberList.None).ReverseMap();
            CreateMap<AdsOption, AdsOptionSearchRequest>(MemberList.None).ReverseMap();
            CreateMap<AdsOption, SelectListItem>(MemberList.None).ReverseMap();

            CreateMap<AdsOption, AdsOptionListViewModel>(MemberList.None).ReverseMap();
        }
    }
}