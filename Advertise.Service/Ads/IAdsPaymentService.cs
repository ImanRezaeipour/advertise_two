using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Adses;
using Advertise.Core.Models.Ads;
using Advertise.Core.Models.AdsPayment;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Ads
{
    public interface IAdsPaymentService
    {

        Task<PaymentResult> CallbackWithZarinpalByViewModelAsync(AdsPaymentCallbackViewModel viewModel);


        Task<PaymentResult> CreateWithZarinpalByViewModelAsync(AdsPaymentCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authorityCode"></param>
        /// <returns></returns>
        Task<AdsPayment> FindByAuthorityCodeAsync(string authorityCode);

        Task<int> CountByRequestAsync(AdsPaymentSearchRequest request);


        Task<IList<AdsPayment>> GetByRequestAsync(AdsPaymentSearchRequest request);


        IQueryable<AdsPayment> QueryByRequest(AdsPaymentSearchRequest request);
    }
}