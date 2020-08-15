using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.SeoUrl;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Seo
{
    public interface ISeoUrlService
    {
        Task CreateByViewModelAsync(SeoUrlCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid id);
        Task EditByViewModelAsync(SeoUrlEditViewModel viewModel);
        IQueryable<SeoUrl> QueryByRequest(SeoUrlSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SeoUrl> FindByIdAsync(Guid id);


        Task<int> CountByRequestAsync(SeoUrlSearchRequest request);


        Task<IList<SeoUrl>> GetByRequestAsync(SeoUrlSearchRequest request);

        Dictionary<string, string> GetAll();
    }
}