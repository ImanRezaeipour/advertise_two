using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Newses;
using Advertise.Core.Models.News;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Newses
{
    public interface INewsService {


        Task  CreateByViewModelAsync(NewsCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid newsId);


        Task<News> FindByIdAsync(Guid newsId);



        Task  SeedAsync();


        Task  EditByViewModelAsync(NewsEditViewModel viewModel);


        Task<IList<News>> GetByRequestAsync(NewsSearchRequest request);

        Task<int> CountByRequestAsync(NewsSearchRequest request);


        IQueryable<News> QueryByRequest(NewsSearchRequest request);
    }
}