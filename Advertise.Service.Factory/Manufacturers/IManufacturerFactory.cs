using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Manufacturer;

namespace Advertise.Service.Factories.Manufacturers
{
    public interface IManufacturerFactory
    {
        Task<ManufacturerEditViewModel> PrepareEditViewModelAsync(Guid id , ManufacturerEditViewModel viewModelPrepare = null);

        Task<ManufacturerCreateViewModel> PrepareCreateViewModelAsync(
            ManufacturerCreateViewModel viewModelPrepare = null);

        Task<ManufacturerListViewModel> PrepareListViewModelAsync(ManufacturerSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}