using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.Seo;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Seos
{
    public class SeoProfile : BaseProfile
    {
        public SeoProfile()
        {
            CreateMap<Seo, SeoCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Seo, SeoViewModel>(MemberList.None).ReverseMap();
        }
    }
}
