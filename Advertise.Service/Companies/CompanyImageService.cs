using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyImage;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Exceptions;
using Advertise.Core.Objects;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Validators.Companies;

namespace Advertise.Service.Services.Companies
{
    /// <summary>
    /// </summary>
    public class CompanyImageService : ICompanyImageService
    {
        #region Private Fields

        private readonly IDbSet<CompanyImage> _companyImageRepository;
        private readonly IDbSet<Company> _companyRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        public CompanyImageService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyRepository = unitOfWork.Set<Company>();
            _companyImageRepository = unitOfWork.Set<CompanyImage>();
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyImageEditValidator))]
        public async Task EditApproveByViewModelAsync(CompanyImageEditViewModel viewModel)
        {
            var companyImage = await _companyImageRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);

            EditAsync(viewModel, companyImage);
            companyImage.ApprovedById = _webContextManager.CurrentUserId;
            companyImage.State = StateType.Approved;
            _mapper.Map(viewModel, companyImage);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(companyImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<int> CountAllByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyImageSearchRequest
            {
                CompanyId = companyId,
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CompanyImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyImageCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyImageCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyImage = _mapper.Map<CompanyImage>(viewModel);
            var companyImageFiles = _mapper.Map<List<CompanyImageFile>>(viewModel.CompanyImageFile);
            companyImage.State = StateType.Pending;
            companyImage.CompanyId = (await _companyRepository.FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId)).Id;
            companyImage.CreatedById = _webContextManager.CurrentUserId;
            companyImage.CreatedOn = DateTime.Now;
            companyImage.ImageFiles = companyImageFiles;
            _companyImageRepository.Add(companyImage);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid companyImageId, bool isCurrentUser = false)
        {

            var activityLog = await _companyImageRepository.FirstOrDefaultAsync(model => model.Id == companyImageId);
            if(isCurrentUser && activityLog.CreatedById != _webContextManager.CurrentUserId)
                return;

            _companyImageRepository.Remove(activityLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(activityLog);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="companyImage"></param>
        [Validation(typeof(CompanyImageEditValidator))]
        public void EditAsync(CompanyImageEditViewModel viewModel, CompanyImage companyImage)
        {
            _mapper.Map(viewModel, companyImage);
            var companyImageFiles = _mapper.Map<List<CompanyImageFile>>(viewModel.CompanyImageFile);

            companyImage?.ImageFiles.Clear();
            if (companyImageFiles != null)
                foreach (var file in companyImageFiles)
                    if (companyImage != null) companyImage.ImageFiles.Add(file);
        }


        [Validation(typeof(CompanyImageEditValidator),"Edit")]
        public async Task EditByViewModelAsync(CompanyImageEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyImage = await _companyImageRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if(isCurrentUser && companyImage.CreatedById != _webContextManager.CurrentUserId)
                return;

            EditAsync(viewModel, companyImage);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyImage> FindByIdAsync(Guid companyImageId, Guid? userId = null)
        {
            var companyImage = _companyImageRepository.AsQueryable();
            companyImage = companyImage.Where(category => category.Id == companyImageId);

            if (userId.HasValue)
                companyImage = companyImage.Where(model => model.CreatedById == userId);

            return await companyImage.FirstOrDefaultAsync();
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<CompanyImage>> GetApprovedsByCompanyIdAsync(Guid companyId)
        {
            var requestImage = new CompanyImageSearchRequest
            {
                CompanyId = companyId,
                State = StateType.Approved
            };
            return await GetByRequestAsync(requestImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        public CompanyImage GetById(Guid companyImageId)
        {
            return _companyImageRepository
                .AsNoTracking()
                .FirstOrDefault(model => model.Id == companyImageId);
        }


        /// ///استفاده در کمپانی
        public async Task<IList<CompanyImage>> GetByRequestAsync(CompanyImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyImageId)
        {
            return (await _companyImageRepository.AsNoTracking()
                    .Include(model => model.ImageFiles)
                    .Where(model => model.Id == companyImageId)
                    .Select(model => model.ImageFiles)
                    .SingleOrDefaultAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.FileName,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.FileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.FileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImageId"></param>
        /// <returns></returns>
        public async Task<bool> IsMineAsync(Guid companyImageId)
        {
            var company = await _companyImageRepository.FirstOrDefaultAsync(model => model.Id == companyImageId);
            return (company.CreatedById == _webContextManager.CurrentUserId || HttpContext.Current.User.IsInRole(PermissionConst.CanCompanyImageEdit));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CompanyImage> QueryByRequest(CompanyImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyImages = _companyImageRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Company)
                .Include(model => model.ImageFiles);
            if (request.Term.HasValue())
                companyImages = companyImages.Where(model => model.Title.Contains(request.Term));
            if (request.UserId.HasValue)
                companyImages = companyImages.Where(model => model.CreatedById == request.UserId);
            if (request.CompanyId.HasValue)
                companyImages = companyImages.Where(model => model.CompanyId == request.CompanyId);
            if (request.CreatedById.HasValue)
                companyImages = companyImages.Where(model => model.CreatedById == request.CreatedById);
            if (request.State.HasValue)
                companyImages = companyImages.Where(model => model.State == request.State);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyImages = companyImages.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyImages;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyImageEditValidator),"Edit")]
        public async Task EditRejectByViewModelAsync(CompanyImageEditViewModel viewModel)
        {
            var companyImage = await _companyImageRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);

            EditAsync(viewModel, companyImage);
            _mapper.Map(viewModel, companyImage);
            companyImage.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.Publish(companyImage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyImages"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<CompanyImage> companyImages)
        {
            if (companyImages == null)
                throw new ArgumentNullException(nameof(companyImages));

            foreach (var companyImage in companyImages)
                _companyImageRepository.Remove(companyImage);
        }

        public async Task SetStateByIdAsync(Guid id, StateType state)
        {
            var companyImage = await FindByIdAsync(id);
            companyImage.State = state;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyImage);
        }

        #endregion Public Methods
    }
}