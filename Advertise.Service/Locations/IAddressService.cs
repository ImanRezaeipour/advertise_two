using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Locations
{
    public interface IAddressService
    {

        Task  CreateByViewModelAsync(AddressCreateViewModel viewModel);

        /// <summary>
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid addressId);


        Task  EditByViewModelAsync(AddressEditViewModel viewModel);


        Task  SeedAsync();

        Task<int> CountByRequestAsync(AddressSearchRequest request);
        Task<IList<Address>> GetByRequestAsync(AddressSearchRequest request);
        Task<Address> FindDefaultAsync();
        Task<Address> FindByIdAsync(Guid addressId);


        Task<IList<SelectListItem>> GetProvinceAsSelectListItemAsync();


        IQueryable<Address> QueryByRequest(AddressSearchRequest request);

        /// <summary>
        /// item1 = lat
        /// item2 = long
        /// item3 = cityname
        /// </summary>
        /// <returns></returns>
        Task<Tuple<string, string,string>> GetDefaultLocationAsync();
    }
}