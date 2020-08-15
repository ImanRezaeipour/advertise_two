using Advertise.Core.Domains.Keywords;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Keyword;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Keywords
{

    public class KeywordService : IKeywordService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IDbSet<Keyword> _keywordRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        ///  <param name="eventPublisher"></param>
        /// <param name="webContextManager"></param>
        public KeywordService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _keywordRepository = unitOfWork.Set<Keyword>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task CreateByViewModelAsync(KeywordCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var keyword = _mapper.Map<Keyword>(viewModel);
            keyword.CreatedById = _webContextManager.CurrentUserId;
            _keywordRepository.Add(keyword);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(keyword);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid keywordId)
        {
            var keyword = await FindByIdAsync(keywordId);
            _keywordRepository.Remove(keyword);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(keyword);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keywordId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <returns></returns>
        public async Task<Keyword> FindByIdAsync(Guid keywordId, bool? applyCurrentUser = false)
        {
            var query = _keywordRepository.AsQueryable();
            if (applyCurrentUser == true)
                query = query.Where(model => model.CreatedById == _webContextManager.CurrentUserId);
            return  await query.FirstOrDefaultAsync(model => model.Id == keywordId);
            
        }


        public async Task<List<Keyword>> GetAllActiveAsync()
        {
            var request = new KeywordSearchRequest
            {
                IsActive = true
            };
          return await QueryByRequest(request).ToListAsync();
            }


        public async Task<List<SelectListItem>> GetAllActiveAsSelectListAsync()
        {
            var request = new KeywordSearchRequest
            {
                IsActive = true
            };
           return  await QueryByRequest(request).Select(model => new SelectListItem
            {
                Text = model.Title,
                Value = model.Id.ToString()
            }).ToListAsync();

        }


        public IQueryable<Keyword> QueryByRequest(KeywordSearchRequest request)
        {
            var keywords = _keywordRepository.AsNoTracking().AsQueryable();

            if (request.CreatedOn != null)
                keywords = keywords.Where(model => model.CreatedOn == request.CreatedOn);
            if (request.IsActive != null)
                keywords = keywords.Where(model => model.IsActive == request.IsActive);

            if (request.SortMember == null)
                request.SortMember = SortMember.CreatedOn;
            if (request.SortDirection == null)
                request.SortDirection = SortDirection.Asc;

            keywords = keywords.OrderBy($"{request.SortMember} {request.SortDirection}");

            return keywords;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keywordId"></param>
        /// <returns></returns>
        public async Task<bool> IsExistByIdAsync(Guid keywordId)
        {
           return await _keywordRepository.AsNoTracking().AnyAsync(model => model.Id == keywordId);

        }

        #endregion Public Methods
    }
}