using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyAttachmentFile;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyAttachmentFiles
{

    public class CompanyAttachmentFileProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyAttachmentFileProfile()
        {
            CreateMap<CompanyAttachmentFile, CompanyAttachmentFileViewModel>(MemberList.None).ReverseMap();
        }
    }
}