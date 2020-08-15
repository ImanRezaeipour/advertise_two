using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Manufacturers;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Manufacturer;

namespace Advertise.Service.Services.Manufacturers
{
    public interface IManufacturerService
    {

        Task<IList<SelectListItem>> GetAllAsSelectListAsync();

        Task<Manufacturer> FindByIdAsync(Guid id);
        Task EditByViewMoodelAsync(ManufacturerEditViewModel viewModel);
        Task CreateByViewModelAsync(ManufacturerCreateViewModel viewModel);
        IQueryable<Manufacturer> QueryByRequest(ManufacturerSearchRequest request);
        Task<int> CountByRequestAsync(ManufacturerSearchRequest request);
        Task<IList<Manufacturer>> GetByRequestAsync(ManufacturerSearchRequest request);
        Task DeleteByIdAsync(Guid id);
    }
}