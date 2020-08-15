using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyAttachment;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyAttachmentFactory
    {

        Task<CompanyAttachmentListViewModel> PrepareListViewModelAsync(CompanyAttachmentSearchRequest request, bool isCurrentUser = false, Guid? userId = null);


        /// <summary>
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        Task<CompanyAttachmentEditViewModel> PrepareEditViewModelAsync(Guid companyAttachmentId, bool applyCurrentUser = false);

        Task<CompanyAttachmentDetailViewModel> PrepareDetailViewModelAsync(Guid companyAttachmentId);
    }
}