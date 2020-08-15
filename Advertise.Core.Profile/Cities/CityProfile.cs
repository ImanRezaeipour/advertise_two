using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.City;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Cities
{
    public class CityProfile : BaseProfile
    {
        public CityProfile()
        {
            CreateMap<City, CityViewModel>(MemberList.None);

            CreateMap<CityViewModel, City>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
