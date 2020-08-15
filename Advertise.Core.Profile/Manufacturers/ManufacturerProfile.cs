using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Manufacturers;
using Advertise.Core.Models.Manufacturer;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Manufacturers
{
    class ManufacturerProfile :BaseProfile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerEditViewModel>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<Manufacturer, ManufacturerCreateViewModel>(MemberList.None).ReverseMap();
            CreateMap<Manufacturer, ManufacturerListViewModel>(MemberList.None).ReverseMap();
            CreateMap<Manufacturer, ManufacturerViewModel>(MemberList.None).ReverseMap();
        }
    }
}
