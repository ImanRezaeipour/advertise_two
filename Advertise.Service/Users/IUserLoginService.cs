using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Microsoft.AspNet.Identity;

namespace Advertise.Service.Services.Users
{

    public interface IUserLoginService
    {
        Task AddLoginAsync(User user, UserLoginInfo login);
        Task<User> FindAsync(UserLoginInfo login);
        Task<System.Collections.Generic.IList<UserLoginInfo>> GetLoginsAsync(User user);
        Task RemoveLoginAsync(User user, UserLoginInfo login);
    }
}