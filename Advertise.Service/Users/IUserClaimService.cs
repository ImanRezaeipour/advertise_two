using System.Security.Claims;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;

namespace Advertise.Service.Services.Users
{

    public interface IUserClaimService
    {
        Task AddClaimAsync(User user, Claim claim);
        Task<System.Collections.Generic.IList<Claim>> GetClaimsAsync(User user);
        Task RemoveClaimAsync(User user, Claim claim);
    }
}