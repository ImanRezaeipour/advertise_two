using Advertise.Core.Domains.Tags;
using Advertise.Core.Models.CompanyTag;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyTags
{

    public class CompanyTagProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyTagProfile()
        {
            CreateMap<Tag, CompanyTagEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, CompanyTagListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, CompanyTagCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, CompanyTagViewModel>(MemberList.None).ReverseMap();
        }
    }
}