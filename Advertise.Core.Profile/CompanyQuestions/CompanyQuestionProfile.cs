using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyQuestion;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyQuestions
{

    public class CompanyQuestionProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyQuestionProfile()
        {
            CreateMap<CompanyQuestion, CompanyQuestionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyQuestionEditViewModel, CompanyQuestion>(MemberList.None)
                .ForMember(src => src.CompanyId, opt => opt.Ignore());
            
            CreateMap<CompanyQuestion, CompanyQuestionEditViewModel>(MemberList.None)
                .ForMember(dest => dest.CreatorFullName, opts => opts.MapFrom(src => src.CreatedBy.Meta.FirstName + " " + src.CreatedBy.Meta.LastName))
                .ForMember(dest => dest.EditorFullName, opts => opts.MapFrom(src => src.ModifiedBy.Meta.FirstName + " " + src.ModifiedBy.Meta.LastName))
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore());

            CreateMap<CompanyQuestion, CompanyQuestionDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<CompanyQuestion, CompanyQuestionViewModel>(MemberList.None)
                .ForMember(dest => dest.UserFullName,
                    opts => opts.MapFrom(src => src.CreatedBy.Meta.FirstName + " " + src.CreatedBy.Meta.LastName))
                .ForMember(dest => dest.UserAvatar, opts => opts.MapFrom(src => src.CreatedBy.Meta.AvatarFileName))
                .ForMember(dest => dest.CompanyAlias, opts => opts.MapFrom(src => src.CreatedBy.Company.Alias))
                .ForMember(dest => dest.CompanyTitle, opts => opts.MapFrom(src => src.CreatedBy.Company.Title));

            CreateMap<CompanyQuestion, CompanyQuestionListViewModel>(MemberList.None).ReverseMap();
        }
    }
}