using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyReviewService {

        Task  ApproveByViewModelAsync(CompanyReviewEditViewModel viewModel);


        Task<int> CountByRequestAsync(CompanyReviewSearchRequest request);


        Task  CreateByViewModelAsync(CompanyReviewCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid companyReviewId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        Task<CompanyReview> FindByIdAsync(Guid companyReviewId);


        /// استفاده در کمپانی
        Task<IList<CompanyReview>> GetByRequestAsync(CompanyReviewSearchRequest request);


        Task<IList<SelectListItem>> GetCompanyAsSelectListItemAsync();


        Task  RejectByViewModelAsync(CompanyReviewEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviews"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<CompanyReview> companyReviews);


        Task  SeedAsync();


        Task  EditByViewModelAsync(CompanyReviewEditViewModel viewModel);

        Task<IList<CompanyReview>> GetByCompanyIdAsync(Guid companyId, StateType? state = null);


       IQueryable<CompanyReview> QueryByRequest(CompanyReviewSearchRequest request);
    }
}