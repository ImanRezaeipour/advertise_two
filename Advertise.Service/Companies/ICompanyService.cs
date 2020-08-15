using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyService {

        Task<int> CountAllAsync();


        Task<int> CountByRequestAsync(CompanySearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task  CreateByUserIdAsync(Guid userId);


        Task  CreateEasyByViewModelAsync(CompanyCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        Task  DeleteByAliasAsync(string companyAlias, bool isCurrentUser = false);

        Task  DeleteByUserIdAsync(Guid userId);


        Task  EditApproveByViewModelAsync(CompanyEditViewModel viewModel);


        Task  EditByViewModelAsync(CompanyEditViewModel viewModel, bool isCurrentUser = false);


        Task  EditRejectByViewModelAsync(CompanyEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<Company> FindByIdAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAlias"></param>
        /// <returns></returns>
        Task<Company> FindByAliasAsync(string companyAlias);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Company> FindByUserIdAsync(Guid userId);

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<Address> GetAddressByIdAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<AddressViewModel> GetAddressViewModelByIdAsync(Guid companyId);


        Task<object> GetAllNearAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Company> GetByUserIdAsync(Guid userId);


        Task<IList<Company>> GetByRequestAsync(CompanySearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>>GetFileAsFineUploaderModelByIdAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileCoverAsFineUploaderModelByIdAsync(Guid companyId);

        Task<string> GetMyNameByUserIdAsync(Guid userId);
        Task<bool> IsApprovedByAliasAsync(string alias);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> IsExistEmailByCompanyIdAsync(Guid companyId, string email, CancellationToken cancellationToken = default (CancellationToken));

        Task<bool> IsExistAliasByIdAsync(Guid companyId);

        Task<bool> CompareNameAndSlugAsync(string alias, string slug);


        Task  SeedAsync();

        Task<int> GetCountMyFollowAsync();
        Task<bool> IsMySelfAsync(Guid companyId);
        Task<IList<SelectListItem>> GetAllAsSelectListItemAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<int> CountByCategoryIdAsync(Guid categoryId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        Task<bool> IsExistByAliasAsync(string alias, Guid? companyId = null, bool applyCurrentUser = false);


        Task<bool> HasAliasByCurrentUserAsync();

        Task<bool> IsMineByIdAsync(Guid companyId,HttpContext http, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyState"></param>
        /// <returns></returns>
        Task<int> CountByStateAsync(StateType companyState);

        Task<bool> HasAliasAsync(Guid input, CancellationToken cancellationToken);
        Task SetStateByIdAsync(Guid companyId, StateType state);
        Task<bool> IsExistAliasCancellationTokenAsync(string alias,HttpContext http, CancellationToken cancellationToken);
    }
}