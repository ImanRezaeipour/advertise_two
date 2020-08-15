using System;
using System.Threading.Tasks;
using Advertise.Core.Models.SpecificationOption;

namespace Advertise.Service.Factories.Specifications
{
    public interface ISpecificationOptionFactory
    {
        Task<SpecificationOptionCreateViewModel> PrepareCreateViewModelAsync();
        Task<SpecificationOptionDetailViewModel> PrepareDetailViewModelAsync(Guid specificationOptionId);
        Task<SpecificationOptionEditViewModel> PrepareEditViewModelAsync(Guid specificationOptionId);
        Task<SpecificationOptionListViewModel> PrepareListViewModelAsync(SpecificationOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}