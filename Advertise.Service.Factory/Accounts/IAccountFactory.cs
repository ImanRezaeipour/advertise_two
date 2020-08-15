using System.Threading.Tasks;
using Advertise.Core.Models.UserOperator;

namespace Advertise.Service.Factories.Accounts
{
    public interface IAccountFactory
    {
        Task<UserOperatorCreateViewModel> PrepareUserOperatorCreateViewModel(UserOperatorCreateViewModel viewModelPrepare = null);
    }
}