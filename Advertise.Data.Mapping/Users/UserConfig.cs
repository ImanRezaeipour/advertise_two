using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Users;
using Advertise.Data.Mappings.Common;

namespace Advertise.Data.Mappings.Users
{

    public class UserConfig : BaseConfig<User>
    {
        /// <summary>
        /// </summary>
        public UserConfig()
        {
            HasMany(user => user.Roles).WithRequired().HasForeignKey(role => role.UserId);
            HasMany(user => user.Claims).WithRequired().HasForeignKey(claim => claim.UserId);
            HasMany(user => user.Logins).WithRequired().HasForeignKey(login => login.UserId);
            HasRequired(user => user.CreatedBy).WithMany().HasForeignKey(user => user.CreatedById);
            HasOptional(a => a.Meta)
                .WithMany()
                .HasForeignKey(a => a.MetaId);
            Property(user => user.DirectPermissions).HasColumnType("xml");
            Ignore(user => user.XmlDirectPermissions);
        }
    }
}