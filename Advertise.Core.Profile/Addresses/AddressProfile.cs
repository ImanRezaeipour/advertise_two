using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.Address;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Addresses
{
    public class AddressProfile : BaseProfile
    {
        #region Public Constructors

        public AddressProfile()
        {
            CreateMap<Address, AddressCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Address, AddressEditViewModel>(MemberList.None)
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<AddressEditViewModel, Address>(MemberList.None);

            CreateMap<Address, AddressViewModel>(MemberList.None);

            CreateMap<AddressViewModel, Address>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CityId, opt => opt.Ignore());
        }

        #endregion Public Constructors
    }
}