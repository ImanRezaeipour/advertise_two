using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Specification;

namespace Advertise.Service.Factories.Specifications
{
    public interface ISpecificationFactory
    {
        Task<SpecificationDetailViewModel> PrepareDetailViewModelAsync(Guid specificationId);
        Task<SpecificationEditViewModel> PrepareEditViewModelAsync(Guid specificationId, SpecificationEditViewModel viewModelPrepare = null);
        Task<SpecificationListViewModel> PrepareListViewModelAsync(SpecificationSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));


        Task<SpecificationCreateViewModel> PrepareCreateViewModelAsync(SpecificationCreateViewModel viewModelPrepare = null);
    }
}