using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanySlide;
using Advertise.Data.DbContexts;
using Advertise.Service.Managers.Events;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Helpers;
using Advertise.Core.Objects;
using Advertise.Service.Managers.File;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Companies
{
    public class CompanySlideService : ICompanySlideService
    {
        #region Private Fields

        private readonly IDbSet<CompanySlide> _companySlideRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public CompanySlideService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _companySlideRepository = unitOfWork.Set<CompanySlide>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequestAsync(CompanySlideSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateByViewModelAsync(CompanySlideCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companySlide = _mapper.Map<CompanySlide>(viewModel);
            companySlide.CompanyId = _webContextManager.CurrentCompanyId;
            
            _companySlideRepository.Add(companySlide);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companySlide);
        }

        public async Task DeleteByIdAsync(Guid companySlideId)
        {
            var companySlide = await FindByIdAsync(companySlideId);
            _companySlideRepository.Remove(companySlide);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(companySlide);
        }

        public async Task EditByViewModelAsync(CompanySlideEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var originalCompanySlide = await FindByIdAsync(viewModel.Id.Value);
            _mapper.Map(viewModel, originalCompanySlide);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(originalCompanySlide);
        }

        public async Task<CompanySlide> FindByIdAsync(Guid companySlideId)
        {
            return await _companySlideRepository.SingleOrDefaultAsync(slide => slide.Id == companySlideId);
        }

        public async Task<IList<CompanySlide>> GetByRequestAsync(CompanySlideSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public IQueryable<CompanySlide> QueryByRequest(CompanySlideSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companySlides = _companySlideRepository.AsNoTracking().AsQueryable();

            if (request.CreatedOn.HasValue)
                companySlides = companySlides.Where(slide => slide.CreatedOn == request.CreatedOn);
            if (request.CompanyId.HasValue)
                companySlides = companySlides.Where(slide => slide.CompanyId == request.CompanyId);

            companySlides = companySlides.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Asc}");

            return companySlides;
        }

        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid companySlideId)
        {
            return (await _companySlideRepository.AsNoTracking()
                    .Where(model => model.Id == companySlideId)
                    .Select(model => new
                    {
                        model.Id,
                        model.ImageFileName
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.ImageFileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.ImageFileName) ?? FileConst.NoLogo,
                    size = FileHelper.FileSize(FileConst.ImagesWebPath.PlusWord(model.ImageFileName))
                }).ToList();
        }

        #endregion Public Methods
    }
}