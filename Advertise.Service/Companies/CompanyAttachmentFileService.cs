using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyAttachmentFile;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Companies
{

    public class CompanyAttachmentFilService : ICompanyAttachmentFilService
    {
        #region Private Fields

        private readonly IDbSet<CompanyAttachmentFile> _companyAttachmentFileRepository;

        #endregion Private Fields

        #region Public Constructors

        public CompanyAttachmentFilService( IUnitOfWork unitOfWork)
        {
            _companyAttachmentFileRepository = unitOfWork.Set<CompanyAttachmentFile>();
        }
        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CompanyAttachmentFileSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentFileId"></param>
        /// <returns></returns>
        public async Task<CompanyAttachmentFile> FindByIdAsync(Guid companyAttachmentFileId)
        {
            return _companyAttachmentFileRepository.FirstOrDefault(model => model.Id == companyAttachmentFileId);
        }


        /// ///استفاده در کمپانی
        public async Task<IList<CompanyAttachmentFile>> GetByRequestAsync(CompanyAttachmentFileSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<CompanyAttachmentFile> QueryByRequest(CompanyAttachmentFileSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyAttachmentFiles = _companyAttachmentFileRepository.AsNoTracking().AsQueryable();
            if (request.CompanyAttachmentId.HasValue)
                companyAttachmentFiles = companyAttachmentFiles.Where(model => model.CompanyAttachmentId == request.CompanyAttachmentId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            companyAttachmentFiles = companyAttachmentFiles.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyAttachmentFiles;
        }

        #endregion Public Methods
    }
}