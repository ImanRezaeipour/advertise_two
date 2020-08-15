using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyConversations
{
    public class CompanyConversationProfile : BaseProfile
    {
        public CompanyConversationProfile()
        {
            CreateMap<CompanyConversation, CompanyConversationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyConversation, CompanyConversationEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyConversation, CompanyConversationListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyConversation, CompanyConversationMyListViewModel>(MemberList.None).ReverseMap();
            CreateMap<CompanyConversationListViewModel, CompanyConversationViewModel>(MemberList.None).ReverseMap();
            CreateMap<CompanyConversationViewModel, CompanyConversationListViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyConversation, CompanyConversationViewModel>(MemberList.None).ReverseMap();
        }
    }
}
