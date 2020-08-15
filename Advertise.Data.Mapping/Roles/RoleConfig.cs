using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Roles;
using Advertise.Data.Mappings.Common;

namespace Advertise.Data.Mappings.Roles
{

    public class RoleConfig : BaseConfig<Role>
    {
        /// <summary>
        /// </summary>
        public RoleConfig()
        {
            Property(role => role.Permissions).HasColumnType("xml");
            Ignore(r => r.XmlPermissions);
        }
    }
}