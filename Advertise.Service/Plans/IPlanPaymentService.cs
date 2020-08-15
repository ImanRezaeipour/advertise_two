using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.PlanPayment;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Plans
{
    public interface IPlanPaymentService
    {
        Task<PaymentResult> CreateWithZarinpalByViewModelAsync(PlanPyamentCreateViewModel viewModel);
        Task<PaymentResult> CreateByViewModelAsync(PlanPyamentCreateViewModel viewModel);
        Task<PaymentResult> CallbackByViewModelAsync(PlanPaymentCallbackViewModel viewModel);
        Task<PlanPayment> FindByAuthorityCodeAsync(string authorityCode);


        Task<PaymentResult> CallbackWithZarinpalByViewModelAsync(PlanPaymentCallbackViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<PlanPayment> QueryByRequest(PlanPaymentSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> CountByRequestAsync(PlanPaymentSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IList<PlanPayment>> GetByRequestAsync(PlanPaymentSearchRequest request);
    }
}