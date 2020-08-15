using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyVideo;
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
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Configuration;
using Advertise.Core.Models.CompanyVideoFile;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Validators.Companies;
using FineUploaderObject = Advertise.Core.Objects.FineUploaderObject;

namespace Advertise.Service.Services.Companies
{
    /// <summary>
    ///
    /// </summary>
    public class CompanyVideoService : ICompanyVideoService
    {

        #region Private Fields

        private readonly IDbSet<Company> _company;
        private readonly IDbSet<CompanyVideo> _companyVideoRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;
        private readonly IConfigurationManager _configurationManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public CompanyVideoService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher, IConfigurationManager configurationManager)
        {
            _unitOfWork = unitOfWork;
            _companyVideoRepository = unitOfWork.Set<CompanyVideo>();
            _company = unitOfWork.Set<Company>();
            _mapper = mapper;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _configurationManager = configurationManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<int> CountAllVideoByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyVideoSearchRequest
            {
                CompanyId = companyId
            };
            return  await CountByRequestAsync(request);
            }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CompanyVideoSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

           return  await QueryByRequest(request).CountAsync();

        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyVideoCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyVideoCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyVideo = _mapper.Map<CompanyVideo>(viewModel);
            var companyVideoFiles = _mapper.Map<List<CompanyVideoFile>>(viewModel.CompanyVideoFile);
            companyVideo.State = StateType.Pending;
            companyVideo.CompanyId = (await _company.FirstOrDefaultAsync(model => model.CreatedById == _webContextManager.CurrentUserId)).Id;
            companyVideo.VideoFiles = companyVideoFiles;
            companyVideo.CreatedById = _webContextManager.CurrentUserId;
            companyVideo.CreatedOn = DateTime.Now;
            if (companyVideoFiles != null)
            {
                foreach (var item in companyVideoFiles)
                {
                    item.ThumbName = Path.GetFileNameWithoutExtension(item.FileName) + "_thumb.jpg";
                    if (_configurationManager.VideoWaterMark.ToBoolean())
                        item.WatermarkName = Path.GetFileNameWithoutExtension(item.FileName) + "_watermarked.mp4";
                }
                _companyVideoRepository.Add(companyVideo);

                await _unitOfWork.SaveAllChangesAsync();
            }
            _eventPublisher.EntityInserted(companyVideo);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVideoId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid companyVideoId, bool isCurrentUser = false)
        {
            var companyVideo = await FindByIdAsync(companyVideoId);
            if (isCurrentUser && companyVideo.CreatedById == _webContextManager.CurrentUserId)
                return;

            _companyVideoRepository.Remove(companyVideo);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyVideoEditValidator),"Edit")]
        public async Task EditApproveByViewModelAsync(CompanyVideoEditViewModel viewModel)
        {
            var companyVideo = await _companyVideoRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditAsync(viewModel, companyVideo);
            companyVideo.ApprovedById = _webContextManager.CurrentUserId;
            companyVideo.State = StateType.Approved;
            _mapper.Map(viewModel, companyVideo);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyVideo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="companyVideo"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyVideoEditValidator))]
        public async Task EditAsync(CompanyVideoEditViewModel viewModel, CompanyVideo companyVideo)
        {
            _mapper.Map(viewModel, companyVideo);

            var companyVideoFiles = _mapper.Map<List<CompanyVideoFile>>(viewModel.CompanyVideoFile);
            if (companyVideoFiles != null)
            {
                companyVideo.VideoFiles.Clear();
                companyVideo.VideoFiles.AddRange(companyVideoFiles.ToArray());
            }
            if (companyVideoFiles != null)
                foreach (var item in companyVideoFiles)
                {
                    item.ThumbName = Path.GetFileNameWithoutExtension(item.FileName) + "_thumb.jpg";
                    if (_configurationManager.VideoWaterMark.ToBoolean())
                        item.WatermarkName = Path.GetFileNameWithoutExtension(item.FileName) + "_watermarked.mp4";
                }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyVideoEditValidator), "Edit")]
        public async Task EditByViewModelAsync(CompanyVideoEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyVideo = await _companyVideoRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if(isCurrentUser && companyVideo.CreatedById == _webContextManager.CurrentUserId)
                return;

            await EditAsync(viewModel, companyVideo);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyVideo);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyVideoEditValidator), "Edit")]
        public async Task EditRejectByViewModelAsync(CompanyVideoEditViewModel viewModel)
        {
            var companyVideo = await _companyVideoRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            await EditAsync(viewModel, companyVideo);

            companyVideo.State = StateType.Rejected;
            _mapper.Map(viewModel, companyVideo);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyVideo);
        }

      
        public async Task<CompanyVideo> FindByIdAsync(Guid? companyVideoId = null ,Guid? userId= null)
        {
            var query = _companyVideoRepository.AsQueryable();
            if (companyVideoId.HasValue)
                query = query.Where(model => model.Id == companyVideoId);
            if (userId.HasValue)
                query = query.Where(model => model.CreatedById == userId);

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<CompanyVideo>> GetApprovedByCompanyIdAsync(Guid companyId)
        {
            var requestVideo = new CompanyVideoSearchRequest
            {
                CompanyId = companyId,
                State = StateType.Approved
            };
            var companyVideos = await GetByRequestAsync(requestVideo);

            return companyVideos;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<CompanyVideo>> GetByRequestAsync(CompanyVideoSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return  await QueryByRequest(request).ToPagedListAsync();

         }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVideoId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid companyVideoId)
        {
            return (await _companyVideoRepository.AsNoTracking()
                    .Include(model => model.VideoFiles)
                    .Where(model => model.Id == companyVideoId)
                    .Select(model => model.VideoFiles)
                    .FirstOrDefaultAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.FileName,
                    thumbnailUrl = FileConst.VideosWebPath.PlusWord(model.FileName),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.VideosWebPath.PlusWord(model.FileName))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CompanyVideo> QueryByRequest(CompanyVideoSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            var companyVideos = _companyVideoRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Company);
            if (request.Term.HasValue())
                companyVideos = companyVideos.Where(model => model.Title.Contains(request.Term));
            if (request.UserId.HasValue)
                companyVideos = companyVideos.Where(model => model.CreatedById == request.UserId);
            if (request.CompanyId.HasValue)
                companyVideos = companyVideos.Where(model => model.CompanyId == request.CompanyId);
            if (request.Id.HasValue)
                companyVideos = companyVideos.Where(model => model.Id == request.Id);
            if (request.State.HasValue)
                companyVideos = companyVideos.Where(model => model.State == request.State);
            if (request.CreatedById.HasValue)
                companyVideos = companyVideos.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyVideos = companyVideos.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyVideos;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVideos"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<CompanyVideo> companyVideos)
        {
            if (companyVideos == null)
                throw new ArgumentNullException(nameof(companyVideos));

            foreach (var companyVideo in companyVideos)
                _companyVideoRepository.Remove(companyVideo);
        }

        public async Task SetStateByIdAsync(Guid companyVideoId, StateType state)
        {
            var companyVideo = await FindByIdAsync(companyVideoId);
            companyVideo.State = state;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyVideo);
        }

        #endregion Public Methods

    }
}