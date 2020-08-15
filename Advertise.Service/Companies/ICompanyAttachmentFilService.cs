using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyAttachmentFile;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyAttachmentFilService
    {

        Task<int> CountByRequestAsync(CompanyAttachmentFileSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentFileId"></param>
        /// <returns></returns>
        Task<CompanyAttachmentFile> FindByIdAsync(Guid companyAttachmentFileId);


        /// ///استفاده در کمپانی
        Task<IList<CompanyAttachmentFile>> GetByRequestAsync(CompanyAttachmentFileSearchRequest request);


        IQueryable<CompanyAttachmentFile> QueryByRequest(CompanyAttachmentFileSearchRequest request);
    }
}