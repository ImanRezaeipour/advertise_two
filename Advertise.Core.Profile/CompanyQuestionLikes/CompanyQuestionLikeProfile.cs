using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyQuestionLike;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.CompanyQuestionLikes
{

    public class CompanyQuestionLikeProfile : BaseProfile
    {
        /// <summary>
        /// </summary>
        public CompanyQuestionLikeProfile()
        {
            CreateMap<CompanyQuestionLike, CompanyQuestionLikeCreateViewModel>(MemberList.None).ReverseMap();
        }
    }
}