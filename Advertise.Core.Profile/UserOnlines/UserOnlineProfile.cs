using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserOnline;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.UserOnlines
{
    public class UserOnlineProfile : BaseProfile
    {
        #region Public Constructors

        public UserOnlineProfile()
        {
            CreateMap<UserOnline, UserOnlineViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}