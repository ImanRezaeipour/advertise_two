using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyQuestion;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyQuestionFactory
    {
        Task<CompanyQuestionDetailViewModel> PrepareDetailViewModelAsync(Guid companyQuestionId);
        Task<CompanyQuestionEditViewModel> PrepareEditViewModelAsync(Guid companyQuestionId);
        Task<CompanyQuestionListViewModel> PrepareListViewModelAsync(CompanyQuestionSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}