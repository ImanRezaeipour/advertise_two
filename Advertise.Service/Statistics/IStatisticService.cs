using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Statistics;
using Advertise.Core.Models.Statistic;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Statistics
{
    public interface IStatisticService {
        Task<int> CountAllAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="statisticId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid statisticId);

        Task<Statistic> FindByIdAsync(Guid statisticId);


        Task  SeedAsync();


        Task  EditByViewModelAsync(StatisticEditViewModel viewModel);


        Task<IList<Statistic>> GetByRequestAsync(StatisticSearchRequest request);

        Task<int> CountByRequestAsync(StatisticSearchRequest request);


        IQueryable<Statistic> QueryByRequest(StatisticSearchRequest request);


        void CreateByViewModel(StatisticCreateViewModel viewModel);
    }
}