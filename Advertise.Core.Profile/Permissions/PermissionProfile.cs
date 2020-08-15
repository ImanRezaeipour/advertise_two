using Advertise.Core.Domains.Permissions;
using Advertise.Core.Models.Permission;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.Permissions
{
    public class PermissionProfile : BaseProfile
    {
        #region Public Constructors

        public PermissionProfile()
        {
            CreateMap<Permission, PermissionViewModel>(MemberList.None).ReverseMap();

            CreateMap<Permission, PermissionCreateViewModel>(MemberList.None).ReverseMap();

            CreateMap<Permission, PermissionEditViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}