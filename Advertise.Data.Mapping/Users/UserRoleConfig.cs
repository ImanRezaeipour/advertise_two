using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Users;
using Advertise.Data.Mappings.Common;

namespace Advertise.Data.Mappings.Users
{

    public class UserRoleConfig : BaseConfig<UserRole>
    {
        /// <summary>
        /// </summary>
        public UserRoleConfig()
        {
            HasKey(role => new {role.UserId, role.RoleId});
        }
    }
}