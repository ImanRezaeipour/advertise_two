using Advertise.Core.Domains.Roles;
using Advertise.Core.Models.RolePermission;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.RolePermissions
{
    public class RolePermissionProfile : BaseProfile
    {
        #region Public Constructors

        public RolePermissionProfile()
        {
            CreateMap<RolePermission, RolePermissionViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}