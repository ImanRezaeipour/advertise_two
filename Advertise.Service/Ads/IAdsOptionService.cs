using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Adses;
using Advertise.Core.Models.AdsOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Service.Services.Ads
{
    public interface IAdsOptionService
    {

        Task<int> CountByRequestAsync(AdsOptionSearchRequest request);


        Task CreateByViewModelAsync(AdsOptionCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="adsOptionId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid adsOptionId);


        Task EditByViewModelAsync(AdsOptionEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="adsOptionId"></param>
        /// <returns></returns>
        Task<AdsOption> FindByIdAsync(Guid adsOptionId);


        Task<IList<AdsOption>> GetByRequestAsync(AdsOptionSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="optionId"></param>
        /// <param name="durationType"></param>
        /// <returns></returns>
        Task<decimal> GetPriceByIdAsync(Guid optionId, DurationType durationType);


        IQueryable<AdsOption> QueryByRequest(AdsOptionSearchRequest request);

        Task<IList<SelectListItem>> GetAsSelectListAsync(AdsType type, AdsPositionType? position = null);
        Task<int> GetCapacityByIdAsync(Guid optionId);
    }
}