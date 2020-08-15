using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Common;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Locations
{
    public interface ICityService
    {
        #region Public Methods


        Task<int> CountByRequestAsync(CitySearchRequest request);


        Task  CreateByViewModelAsync(CityCreateViewModel viewModel);

        /// <summary>
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid cityId);

        Task<City> FindByIdAsync(Guid id);

        Task<City> FindDefaultAsync();


        Task<IList<City>> GetByRequestAsync(CitySearchRequest request);

        Task<IList<SelectListItem>> GetCityAsSelectListItemAsync(Guid cityId);



        Task <object> GetStatesAsync();


        Task  SeedAsync();


        Task  EditByViewModelAsync(CityEditViewModel viewModel);

        #endregion Public Methods


        IQueryable<City> QueryByRequest(CitySearchRequest request);

        Task<Guid?> GetIdByNameAsync(string cityName);
        Task<CityViewModel> GetLocationAsync(Guid cityId);
        Task<string> GetNameByIdAsync(Guid cityId);
    }
}