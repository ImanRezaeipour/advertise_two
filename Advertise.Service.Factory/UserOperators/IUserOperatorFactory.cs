using System;
using System.Threading.Tasks;
using Advertise.Core.Models.UserOperator;

namespace Advertise.Service.Factories.UserOperators
{
    public interface IUserOperatorFactory
    {
        Task<UserOperatorListViewModel> PrepareListViewModel(UserOperatorSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}