using System;
using System.Threading.Tasks;
using Advertise.Core.Models.City;

namespace Advertise.Service.Factories.Locations
{
    public interface ICityFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<CityEditViewModel> PrepareEditViewModelAsync(Guid cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CityListViewModel> PrepareListViewModelAsync(CitySearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}