using Advertise.Core.Domains.Adses;
using Advertise.Core.Models.AdsReserve;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.AdsReserves
{

    public class AdsReserveProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public AdsReserveProfile()
        {
            CreateMap<AdsReserve, AdsReserveCreateViewModel>(MemberList.None).ReverseMap();

        }
    }
}