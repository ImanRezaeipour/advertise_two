using Advertise.Core.Domains.Newses;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.News;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.Html;
using Advertise.Service.Validators.News;

namespace Advertise.Service.Services.Newses
{
    /// <summary>
    ///
    /// </summary>
    public class NewsService : INewsService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<News> _newsRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public NewsService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _newsRepository = unitOfWork.Set<News>();
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(NewsSearchRequest request)
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
        [Validation(typeof(NewsCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(NewsCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var news = _mapper.Map<News>(viewModel);
            news.Body = news.Body.ToSafeHtml();
            news.CreatedOn = DateTime.Now;
            _newsRepository.Add(news);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(news);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid newsId)
        {
            var news = await _newsRepository.FirstOrDefaultAsync(model => model.Id == newsId);
            _newsRepository.Remove(news);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(news);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(NewsEditValidator),"Edit")]
        public async Task EditByViewModelAsync(NewsEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var news = await _newsRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, news);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(news);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task<News> FindByIdAsync(Guid newsId)
        {
            return await _newsRepository
                 .FirstOrDefaultAsync(model => model.Id == newsId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<News>> GetByRequestAsync(NewsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<News> QueryByRequest(NewsSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var newses = _newsRepository.AsNoTracking().AsQueryable();
            if (request.Term.HasValue())
                newses = newses.Where(model => model.Title.Contains(request.Term));
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            newses = newses.OrderBy($"{request.SortMember} {request.SortDirection}");

            return newses;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}