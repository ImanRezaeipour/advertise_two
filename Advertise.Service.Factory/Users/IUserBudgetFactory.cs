using System;
using System.Threading.Tasks;
using Advertise.Core.Models.UserBudget;

namespace Advertise.Service.Factories.Users
{
    public interface IUserBudgetFactory
    {
        Task<UserBudgetListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}