using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Users;
using Advertise.Data.Mappings.Common;

namespace Advertise.Data.Mappings.Users
{
    /// <summary>
    ///     نشان دهنده مپینگ مربوط به کلاس کاربر
    /// </summary>
    public class UserMetaConfig : BaseConfig<UserMeta>
    {
        /// <summary>
        ///     سازنده پیش فرض
        /// </summary>
        public UserMetaConfig()
        {
        }
    }
}