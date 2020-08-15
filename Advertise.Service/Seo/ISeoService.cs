using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Seo;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Seo
{
    public interface ISeoService
    {
        Task CreateByViewModelAsync(SeoCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid seoId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<bool> IsExistCategoryByIdAsync(string categoryId);
    }
}