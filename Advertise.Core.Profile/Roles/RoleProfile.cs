using Advertise.Core.Domains.Roles;
using Advertise.Core.Models.Role;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Roles
{

    public class RoleProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public RoleProfile()
        {
            CreateMap<Role, RoleViewModel>(MemberList.None).ReverseMap();

            CreateMap<Role, RoleCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Role, RoleEditViewModel>(MemberList.None).ReverseMap();

            CreateMap<Role, RoleDetailViewModel>(MemberList.None).ReverseMap();

            CreateMap<Role, RoleListViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}