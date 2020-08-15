using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyTag;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Extensions;

namespace Advertise.Service.Services.Companies
{

    public class CompanyTagService : ICompanyTagService
    {
        #region Private Fields

        private readonly IDbSet<CompanyTag> _companyTagRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public CompanyTagService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _companyTagRepository = unitOfWork.Set<CompanyTag>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<int> CountAllTagByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyTagSearchRequest
            {
                CompanyId = companyId,
            };
            var result = await CountByRequestAsync(request);

            return result;
        }


        public async Task<int> CountByRequestAsync(CompanyTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyTags = await QueryByRequest(request).CountAsync();

            return companyTags;
        }


        public async Task  CreateByViewModelAsync(CompanyTagCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyTag = _mapper.Map<CompanyTag>(viewModel);
            companyTag.CreatedById = _webContextManager.CurrentUserId;
            _companyTagRepository.Add(companyTag);

           await _unitOfWork.SaveAllChangesAsync();

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyTagId"></param>
        /// <returns></returns>
        public async Task  DeleteByIdAsync(Guid companyTagId)
        {
            var companyTag = await _companyTagRepository.FirstOrDefaultAsync(model => model.Id == companyTagId);
            _companyTagRepository.Remove(companyTag);

             await _unitOfWork.SaveAllChangesAsync();

        }


        public async Task  EditByViewModelAsync(CompanyTagEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyTag = await _companyTagRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, companyTag);

            await _unitOfWork.SaveAllChangesAsync();

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyTagId"></param>
        /// <returns></returns>
        public async Task<CompanyTag> FindAsync(Guid companyTagId)
        {
            var companyTag = await _companyTagRepository
                .FirstOrDefaultAsync(model => model.Id == companyTagId);

            return companyTag;
        }


        public IQueryable<CompanyTag> QueryByRequest(CompanyTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyTags = _companyTagRepository.AsNoTracking().AsQueryable();
            if (request.CompanyId.HasValue)
                companyTags = companyTags.Where(model => model.CompanyId == request.CompanyId);
            if (request.CreatedById.HasValue)
                companyTags = companyTags.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyTags = companyTags.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyTags;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<CompanyTagListViewModel> GetByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyTagSearchRequest
            {
                CompanyId = companyId,
            };
            var result = await ListByRequestAsync(request);

            return result;
        }


        public async Task<IList<CompanyTag>> GetCompanyTagsByRequestAsync(CompanyTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyTags =  await QueryByRequest(request).ToPagedListAsync(request);
            

            return companyTags;
        }


        public async Task<CompanyTagListViewModel> ListByRequestAsync(CompanyTagSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var companyTags = await GetCompanyTagsByRequestAsync(request);
            var companyTagViewModel = _mapper.Map<IList<CompanyTagViewModel>>(companyTags);
            var companyTagList = new CompanyTagListViewModel
            {
                SearchRequest = request,
                CompanyTags = companyTagViewModel
            };

            return companyTagList;
        }


        public async Task  SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}