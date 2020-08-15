using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Statistic;

namespace Advertise.Service.Factories.Statistics
{
    public interface IStatisticFactory
    {
        Task<StatisticListViewModel> PrepareListViewModelAsync(StatisticSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}