using System;
using System.Threading.Tasks;
using Advertise.Core.Models.AdsReserve;

namespace Advertise.Service.Services.Ads
{
    public interface IAdsReserveService
    {

        Task CreateByViewModelAsync(AdsReserveCreateViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionId"></param>
        /// <returns></returns>
        Task<DateTime?> GetReserveDayByOptionIdAsync(Guid optionId);
    }
}