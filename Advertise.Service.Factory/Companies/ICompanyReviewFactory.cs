using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyReview;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyReviewFactory
    {
        Task<CompanyReviewListViewModel> PrepareListViewModelAsync(CompanyReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
        Task<CompanyReviewDetailViewModel> PrepareDetailViewModelAsync(Guid companyReviewId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        Task<CompanyReviewEditViewModel> PrepareEditViewModelAsync(Guid companyReviewId);


        Task<CompanyReviewCreateViewModel> PrepareCreateViewModelAsync(CompanyReviewCreateViewModel viewModelPrepare = null);
    }
}