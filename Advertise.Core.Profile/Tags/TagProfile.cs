using Advertise.Core.Domains.Tags;
using Advertise.Core.Models.Tag;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Tags
{

    public class TagProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public TagProfile()
        {
            CreateMap<Tag, TagEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, TagListViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, TagCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Tag, TagViewModel>(MemberList.None).ReverseMap();
        }
    }
}