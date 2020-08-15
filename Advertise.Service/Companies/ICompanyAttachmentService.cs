using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyAttachmentService {

        Task<int> CountByRequestAsync(CompanyAttachmentSearchRequest request);


        Task CreateByViewModelAsync(CompanyAttachmentCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid companyAttachmentId, bool isCurrentUser = false);


        Task EditApproveByViewModelAsync(CompanyAttachmentEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="companyAttachment"></param>
        /// <returns></returns>
        Task EditAsync(CompanyAttachmentEditViewModel viewModel, CompanyAttachment companyAttachment);


        Task EditByViewModelAsync(CompanyAttachmentEditViewModel viewModel, bool isCurrentUser = false);


        Task EditRejectByViewModelAsync(CompanyAttachmentEditViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyAttachment> FindByIdAsync(Guid companyAttachmentId, Guid? userId=null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IList<CompanyAttachment>> GetApprovedByCompanyIdAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        CompanyAttachment GetById(Guid companyAttachmentId);


        /// ///استفاده در کمپانی
        Task<IList<CompanyAttachment>> GetByRequestAsync(CompanyAttachmentSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyAttachmentId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        Task<bool> IsMineAsync(Guid companyAttachmentId);


        IQueryable<CompanyAttachment> QueryByRequest(CompanyAttachmentSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachments"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<CompanyAttachment> companyAttachments);

        Task SetStateByIdAsync(Guid id, StateType state);
    }
}