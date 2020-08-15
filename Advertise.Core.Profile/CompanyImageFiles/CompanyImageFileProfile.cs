using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyImageFile;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyImageFiles
{

    public class CompanyImageFileProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyImageFileProfile()
        {
            CreateMap<CompanyImageFile, CompanyImageFileViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyImage, CompanyImageFileViewModel>(MemberList.None).ReverseMap();
        }
    }
}