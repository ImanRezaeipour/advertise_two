using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserOnline;

namespace Advertise.Service.Services.Users
{
    public interface IUserOnlineService
    {
        Task<int> CountByRequestAsync(UserOnlineSearchRequest request);
        void CreateByViewModel(UserOnlineViewModel viewModel);
        void DeleteBySessionId(string sessionId);
        IQueryable<UserOnline> QueryByRequest(UserOnlineSearchRequest request);


        Task<int> CountAllAsync();
    }
}