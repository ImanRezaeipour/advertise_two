using Advertise.Core.Models.Ads;
using Advertise.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Ads
{
    public interface IAdsService
    {

        Task<PaymentResult> CreateByViewModelAsync(AdsCreateViewModel viewModel, bool? isFreeOfCharge = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="adsId"></param>
        /// <returns></returns>
        Task ApproveByIdAsync(Guid adsId);


        Task<int> CountByRequestAsync(AdsSearchRequest request);

        Task<Core.Domains.Adses.Ads> FindByIdAsync(Guid bannerId);


        Task<IList<Core.Domains.Adses.Ads>> GetByRequestAsync(AdsSearchRequest request);


        IQueryable<Core.Domains.Adses.Ads> QueryByRequest(AdsSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="adsId"></param>
        /// <returns></returns>
        Task RejectByIdAsync(Guid adsId);

        Task EditByViewModelAsync(AdsEditViewModel viewModel);
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid categoryId);
    }
}