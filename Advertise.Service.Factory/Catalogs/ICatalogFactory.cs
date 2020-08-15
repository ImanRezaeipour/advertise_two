using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Catalog;

namespace Advertise.Service.Factories.Catalogs
{
    public interface ICatalogFactory
    {

        Task<CatalogListViewModel> PrepareListViewModelAsync(CatalogSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        Task<CatalogEditViewModel> PrepareEditViewModelAsync(Guid catalogId);


        Task<CatalogCreateViewModel> PrepareCreateViewModelAsync(CatalogCreateViewModel viewModelPrepare = null);
    }
}