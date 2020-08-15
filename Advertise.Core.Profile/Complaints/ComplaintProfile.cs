using Advertise.Core.Domains.Complaints;
using Advertise.Core.Models.Complaint;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Complaints
{
   public class ComplaintProfile : BaseProfile
    {
        public ComplaintProfile()
        {
            CreateMap<Complaint, ComplaintCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Complaint, ComplaintViewModel>(MemberList.None)
                .ForMember(dest => dest.UserAvatar, opts => opts.MapFrom(src => src.CreatedBy.Meta.AvatarFileName))
                .ForMember(dest => dest.UserFullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FullName))
                .ForMember(dest => dest.UserUserName, opts => opts.MapFrom(src => src.CreatedBy.UserName));

            CreateMap<ComplaintViewModel, Complaint>(MemberList.None);

            CreateMap<Complaint, ComplaintDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<Complaint, ComplaintListViewModel>(MemberList.None).ReverseMap();
        }
    }
}
