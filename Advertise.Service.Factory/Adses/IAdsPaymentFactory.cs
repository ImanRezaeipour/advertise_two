using System;
using System.Threading.Tasks;
using Advertise.Core.Models.AdsPayment;

namespace Advertise.Service.Factories.AdsPayment
{
    public interface IAdsPaymentFactory
    {
        Task<AdsPaymentListViewModel> PrepareListViewModel(AdsPaymentSearchRequest request,
            bool isCurrentUser = false, Guid? userId = null);
    }
}