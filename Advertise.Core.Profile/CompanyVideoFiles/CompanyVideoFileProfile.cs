using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyVideoFile;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyVideoFiles
{
    public class CompanyVideoFileProfile: BaseProfile
    {
        public CompanyVideoFileProfile()
        {
            CreateMap<CompanyVideoFile, CompanyVideoFileViewModel>(MemberList.None).ReverseMap();
        }
    }
}
