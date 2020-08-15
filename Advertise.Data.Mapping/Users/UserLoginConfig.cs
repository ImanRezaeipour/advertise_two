using System.Data.Entity.ModelConfiguration;
using Advertise.Core.Domains.Users;
using Advertise.Data.Mappings.Common;

namespace Advertise.Data.Mappings.Users
{

    public class UserLoginConfig : BaseConfig<UserLogin>
    {
        /// <summary>
        /// </summary>
        public UserLoginConfig()
        {
            HasKey(login => new {login.LoginProvider, login.ProviderKey, login.UserId});
        }
    }
}