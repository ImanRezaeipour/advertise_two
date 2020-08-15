using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Objects;
using Advertise.Core.Types;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyImageService {
        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<int> CountAllByCompanyIdAsync(Guid companyId);


        Task<int> CountByRequestAsync(CompanyImageSearchRequest request);


        Task  CreateByViewModelAsync(CompanyImageCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid companyImageId, bool isCurrentUser = false);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="companyImageId"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
        Task<CompanyImage> FindByIdAsync(Guid companyImageId, Guid? userId = null);

        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IList<CompanyImage>> GetApprovedsByCompanyIdAsync(Guid companyId);


        /// ///استفاده در کمپانی
        Task<IList<CompanyImage>> GetByRequestAsync(CompanyImageSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyImageId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImages"></param>
        /// <returns></returns>
        Task  RemoveRangeAsync(IList<CompanyImage> companyImages);


        Task  EditApproveByViewModelAsync(CompanyImageEditViewModel viewModel);


        Task  EditByViewModelAsync(CompanyImageEditViewModel viewModel, bool isCurrentUser = false);


        Task  EditRejectByViewModelAsync(CompanyImageEditViewModel viewModel);

        CompanyImage GetById(Guid companyImageId);
        Task<bool> IsMineAsync(Guid companyImageId);
        Task SetStateByIdAsync(Guid id, StateType state);
    }
}