using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyOfficial;
using Advertise.Data.DbContexts;
using AutoMapper;
using MvcSiteMapProvider.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Objects;
using Advertise.Service.Managers.File;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Companies
{
    public class CompanyOfficialService : ICompanyOfficialService
    {

        #region Private Fields

        private readonly IDbSet<CompanyOfficial> _companyOfficialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public CompanyOfficialService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager contextManager)
        {
            _mapper = mapper;
            _webContextManager = contextManager;
            _companyOfficialRepository = unitOfWork.Set<CompanyOfficial>();
            _unitOfWork = unitOfWork;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task ApproveByViewModelAsync(CompanyOfficialEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyOfficial = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, companyOfficial);
            companyOfficial.IsApprove = true;
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<int> CountByRequestAsync(CompanyOfficialSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var list = await GetByRequestAsync(request);
            return list.Count;
        }

        public async Task CreateByViewModelAsync(CompanyOfficialCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyOfficial = _mapper.Map<CompanyOfficial>(viewModel);
            companyOfficial.CompanyId = _webContextManager.CurrentCompanyId;
                _companyOfficialRepository.Add(companyOfficial);
            await _unitOfWork.SaveAllChangesAsync();
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="companyOfficialId"></param>
       /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileBusinessLicenseAsFineUploaderModelByIdAsync(Guid companyOfficialId)
        {
            return (await _companyOfficialRepository.AsNoTracking()
                    .Where(model => model.Id == companyOfficialId)
                    .Select(model => new
                    {
                        model.Id,
                        model.BusinessLicenseFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.BusinessLicenseFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.BusinessLicenseFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.BusinessLicenseFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyOfficialId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileNationalCardAsFineUploaderModelByIdAsync(Guid companyOfficialId)
        {
            return (await _companyOfficialRepository.AsNoTracking()
                    .Where(model => model.Id == companyOfficialId)
                    .Select(model => new
                    {
                        model.Id,
                        model.NationalCardFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.NationalCardFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.NationalCardFileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.NationalCardFileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyOfficialId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileOfficialNewspaperAddressAsFineUploaderModelByIdAsync(Guid companyOfficialId)
        {
            return (await _companyOfficialRepository.AsNoTracking()
                    .Where(model => model.Id == companyOfficialId)
                    .Select(model => new
                    {
                        model.Id,
                        model.OfficialNewspaperAddress
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.OfficialNewspaperAddress,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.OfficialNewspaperAddress),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.OfficialNewspaperAddress))).Length.ToString()
                }).ToList();
        }

        public async Task EditByViewModelAsync(CompanyOfficialEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyOfficial = await FindByIdAsync(viewModel.Id);
            companyOfficial.IsApprove = null;
            _mapper.Map(viewModel, companyOfficial);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<CompanyOfficial> FindByIdAsync(Guid companyOfficialId)
        {
            return await _companyOfficialRepository.SingleOrDefaultAsync(model => model.Id == companyOfficialId);
        }

        public async Task<IList<CompanyOfficial>> GetByRequestAsync(CompanyOfficialSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequestAsync(request).ToPagedListAsync(request);
        }

        public IQueryable<CompanyOfficial> QueryByRequestAsync(CompanyOfficialSearchRequest request)
        {
            var query = _companyOfficialRepository.AsNoTracking().AsQueryable();

            if (request.Term.HasValue())
                query = query.Where(model => model.Company.Title.Contains(request.Term));

            if (request.CompanyId.HasValue)
                query = query.Where(model => model.CompanyId == request.CompanyId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;

            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            query = query.OrderBy($"{request.SortMember} {request.SortDirection}");
            return query;
        }
        public async Task RejectByViewModelAsync(CompanyOfficialEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyOfficial = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, companyOfficial);
            companyOfficial.IsApprove = false;
            await _unitOfWork.SaveAllChangesAsync();
        }

        #endregion Public Methods

    }
}