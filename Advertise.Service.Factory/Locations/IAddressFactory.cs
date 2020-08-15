using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Address;

namespace Advertise.Service.Factories.Locations
{
    public interface IAddressFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        Task<AddressEditViewModel> PrepareEditViewModelAsync(Guid addressId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<AddressListViewModel> PrepareListViewModelAsync(AddressSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}