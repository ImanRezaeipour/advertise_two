using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Guarantee;

namespace Advertise.Service.Factories.Guarantee
{
    public interface IGuaranteeFactory
    {
        Task<GuaranteeEditViewModel> PrepareEditViewModelAsync(Guid id , GuaranteeEditViewModel viewModelPrepare = null);

     Task<GuaranteeListViewModel> PrepareListViewModelAsync(GuaranteeSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}