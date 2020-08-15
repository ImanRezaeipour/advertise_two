using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.Product;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        Task<CompanyDetailViewModel> PrepareDetailViewModelAsync(string companyAlias, string slug);

        /// <summary>
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        Task<CompanyDetailInfoViewModel> PrepareDetailInfoViewModelAsync(string companyAlias);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<CompanyImageListViewModel> PrepareImageListViewModelAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<ProductListViewModel> PrepareProductListViewModelAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<CompanyReviewListViewModel> PrepareReviewListViewModelAsync(Guid companyId);


        Task<CompanyListViewModel> PrepareListViewModelAsync(CompanySearchRequest request, bool isCurrentUser = false, Guid? userId = null);


        Task<ProfileMenuViewModel> PrepareProfileMenuViewModelAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        Task<CompanyEditViewModel> PrepareEditViewModelAsync(string companyAlias = null, bool applyCurrentUser = false, CompanyEditViewModel viewModelApply = null);
    }
}