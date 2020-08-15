using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserViolation;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.UserViolations
{
    public class UserViolationProfile : BaseProfile
    {
        #region Public Constructors

        public UserViolationProfile()
        {
            CreateMap<UserViolation, UserViolationViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserViolation, UserViolationCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserViolation, UserViolationEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserViolation, UserViolationListViewModel>(MemberList.None).ReverseMap();

            CreateMap<UserViolation, UserViolationDetailViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}