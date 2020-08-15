using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CategoryFollow;

namespace Advertise.Service.Factories.Categories
{
    public interface ICategoryFollowFactory
    {
        Task<CategoryFollowListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, Guid? userId = null);
    }
}