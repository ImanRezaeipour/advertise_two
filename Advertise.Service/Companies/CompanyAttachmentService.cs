using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
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

    public class CompanyAttachmentService : ICompanyAttachmentService
    {

        #region Private Fields

        private readonly IDbSet<CompanyAttachment> _companyAttachmentRepository;
        private readonly IDbSet<Company> _companyRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors


        public CompanyAttachmentService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyRepository = unitOfWork.Set<Company>();
            _companyAttachmentRepository = unitOfWork.Set<CompanyAttachment>();
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods


        [Validation(typeof(CompanyAttachmentEditValidator),"Edit")]
        public async Task EditApproveByViewModelAsync(CompanyAttachmentEditViewModel viewModel)
        {
            var companyAttachment =
                await _companyAttachmentRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);

            await EditAsync(viewModel, companyAttachment);
            _mapper.Map(viewModel, companyAttachment);
            companyAttachment.ApprovedById = _webContextManager.CurrentUserId;
            companyAttachment.State = StateType.Approved;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyAttachment);
        }

        public async Task<int> CountByRequestAsync(CompanyAttachmentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        [Validation(typeof(CompanyAttachmentCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyAttachmentCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyAttachment = _mapper.Map<CompanyAttachment>(viewModel);
            var companyAttachmentFiles = _mapper.Map<List<CompanyAttachmentFile>>(viewModel.CompanyAttachmentFile);
            companyAttachmentFiles.ForEach(file =>
            {
                file.FileSize = new FileInfo( HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(file.FileName))).Length.ToString();
                file.FileExtension = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(file.FileName))).Extension.ToString().Replace(".","");
            });
            companyAttachment.State = StateType.Pending;
            companyAttachment.CompanyId = (await _companyRepository.FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId)).Id;
            companyAttachment.CreatedById = _webContextManager.CurrentUserId;
            companyAttachment.AttachmentFiles = companyAttachmentFiles;
            companyAttachment.CreatedOn = DateTime.Now;
            _companyAttachmentRepository.Add(companyAttachment);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyAttachment);
        }


        public async Task DeleteByIdAsync(Guid companyAttachmentId, bool isCurrentUser = false)
        {
            var companyAttachment = await _companyAttachmentRepository.FirstOrDefaultAsync(model => model.Id == companyAttachmentId);
            if (isCurrentUser && companyAttachment.CreatedById != _webContextManager.CurrentUserId)
                return;

            _companyAttachmentRepository.Remove(companyAttachment);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(companyAttachment);
        }

        [Validation(typeof(CompanyAttachmentEditValidator), "Edit")]
        public async Task EditAsync(CompanyAttachmentEditViewModel viewModel, CompanyAttachment companyAttachment)
        {
            var companyAttachmentMap = _mapper.Map(viewModel, companyAttachment);
            var companyAttachmentFiles = _mapper.Map<List<CompanyAttachmentFile>>(viewModel.CompanyAttachmentFile);
            if (companyAttachment != null)
            {
                companyAttachment.AttachmentFiles.Clear();
                if (companyAttachmentFiles != null)
                    foreach (var file in companyAttachmentFiles)
                        companyAttachment.AttachmentFiles.Add(file);
            }
        }


        [Validation(typeof(CompanyAttachmentEditValidator), "Edit")]
        public async Task EditByViewModelAsync(CompanyAttachmentEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyAttachment = await FindByIdAsync(viewModel.Id);
            if(isCurrentUser && companyAttachment.CreatedById != _webContextManager.CurrentUserId)
                return;

            await EditAsync(viewModel, companyAttachment);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyAttachment);
        }


        public async Task<CompanyAttachment> FindByIdAsync(Guid companyAttachmentId, Guid? userId = null)
        {
            var query = _companyAttachmentRepository.AsQueryable();
            query = query.Where(category => category.Id == companyAttachmentId);

            if (userId.HasValue)
                query = query.Where(category => category.CreatedById == userId);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<IList<CompanyAttachment>> GetApprovedByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyAttachmentSearchRequest
            {
                CompanyId = companyId,
                State = StateType.Approved
            };

            return await GetByRequestAsync(request);
        }

        public CompanyAttachment GetById(Guid companyAttachmentId)
        {
            return _companyAttachmentRepository
                .AsNoTracking()
                .FirstOrDefault(model => model.Id == companyAttachmentId);
        }


        public async Task<IList<CompanyAttachment>> GetByRequestAsync(CompanyAttachmentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyAttachmentId)
        {
            return (await _companyAttachmentRepository.AsNoTracking()
                    .Include(model => model.AttachmentFiles)
                    .Where(model => model.Id == companyAttachmentId)
                    .Select(model => model.AttachmentFiles)
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

        public async Task<bool> IsMineAsync(Guid companyAttachmentId)
        {
            var product = await _companyAttachmentRepository
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == companyAttachmentId);

            return product.CreatedById == _webContextManager.CurrentUserId;
        }

        public IQueryable<CompanyAttachment> QueryByRequest(CompanyAttachmentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyAttachments = _companyAttachmentRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Company)
                .Include(model => model.AttachmentFiles);

            if (request.Term.HasValue())
                companyAttachments = companyAttachments.Where(model => model.Title.Contains(request.Term));
            if (request.UserId.HasValue)
                companyAttachments = companyAttachments.Where(model => model.CreatedById == request.UserId);
            if (request.Id.HasValue)
                companyAttachments = companyAttachments.Where(model => model.Id == request.Id);
            if (request.CompanyId.HasValue)
                companyAttachments = companyAttachments.Where(model => model.CompanyId == request.CompanyId);
            if (request.CreatedById.HasValue)
                companyAttachments = companyAttachments.Where(model => model.CreatedById == request.CreatedById);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            companyAttachments = companyAttachments.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyAttachments;
        }


        [Validation(typeof(CompanyAttachmentEditValidator))]
       public async Task EditRejectByViewModelAsync(CompanyAttachmentEditViewModel viewModel)
        {
            var companyAttachment = await _companyAttachmentRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditAsync(viewModel, companyAttachment);

            _mapper.Map(viewModel, companyAttachment);
            companyAttachment.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyAttachment);
        }

        public async Task RemoveRangeAsync(IList<CompanyAttachment> companyAttachments)
        {
            if (companyAttachments == null)
                throw new ArgumentNullException(nameof(companyAttachments));

            foreach (var companyAttachment in companyAttachments)
                _companyAttachmentRepository.Remove(companyAttachment);

        }

        public async Task SetStateByIdAsync(Guid id, StateType state)
        {
            var companyAttachment = await FindByIdAsync(id);
            companyAttachment.State = state;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyAttachment);
        }

        #endregion Public Methods

    }
}