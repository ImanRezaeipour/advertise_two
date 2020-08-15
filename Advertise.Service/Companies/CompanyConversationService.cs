using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyConversation;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Companies
{

    public class CompanyConversationService : ICompanyConversationService
    {
        #region Private Fields

        private readonly IDbSet<CompanyConversation> _conversationRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;
        private readonly IUserService _userService;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public CompanyConversationService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _userService = userService;
            _conversationRepository = unitOfWork.Set<CompanyConversation>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CompanyConversationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(CompanyConversationCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var conversation = _mapper.Map<CompanyConversation>(viewModel);
            conversation.IsRead = false;
            conversation.CreatedById = _webContextManager.CurrentUserId;
            conversation.CreatedOn = DateTime.Now;

            _conversationRepository.Add(conversation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(conversation);
        }



        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid conversationId)
        {
            var conversation = await _conversationRepository.FirstOrDefaultAsync(model => model.Id == conversationId);
            _conversationRepository.Remove(conversation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(conversation);
        }


        public async Task EditByViewModelAsync(CompanyConversationEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var conversation = await _conversationRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, conversation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(conversation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        public async Task<CompanyConversation> FindByIdAsync(Guid conversationId)
        {
            return await _conversationRepository
                   .FirstOrDefaultAsync(model => model.Id == conversationId);
        }


        public async Task<IList<CompanyConversation>> GetByRequestAsync(CompanyConversationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<CompanyConversationViewModel>> GetListByUserIdAsync(Guid userId)
        {
            var list = await _conversationRepository
                .AsNoTracking()
                .Where(model => model.CreatedById == _webContextManager.CurrentUserId && model.ReceivedById == userId ||
                                model.CreatedById == userId && model.ReceivedById == _webContextManager.CurrentUserId)
                .OrderBy(model => model.CreatedOn)
                .ProjectTo<CompanyConversationViewModel>()
                .ToListAsync();
            if (list.Count > 0)
            {
                var currentUser = (await _userService.FindByIdAsync(_webContextManager.CurrentUserId)).CreatedBy;

                var createdBy =
                 (await _conversationRepository.FirstOrDefaultAsync(model => model.CreatedById == userId)).CreatedBy;
                foreach (var iteModel in list)
                {
                    if (iteModel.CreatedBy.Id == _webContextManager.CurrentUserId)
                        iteModel.AvatarFileName = currentUser.Meta.AvatarFileName;
                    else
                        iteModel.AvatarFileName = createdBy.Meta.AvatarFileName;
                }
            }

            return list;
        }


        public async Task<List<SelectListItem>> GetUsersAsSelectListAsync()
        {
            return await _conversationRepository
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .AsNoTracking()
                .Where(model => model.ReceivedById == _webContextManager.CurrentUserId)
                .Select(model => new SelectListItem
                {
                    Text = model.CreatedBy.Meta.DisplayName ?? (model.CreatedBy.Meta.LastName ?? (model.CreatedBy.UserName ?? model.CreatedBy.Email)),
                    Value = model.CreatedById.ToString()
                })
                .Distinct()
                .ToListAsync();
        }


        public IQueryable<CompanyConversation> QueryByRequest(CompanyConversationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var conversations = _conversationRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                conversations = conversations.Where(model => model.CreatedById == request.CreatedById);
            if (request.RecivedById.HasValue)
                conversations = conversations.Where(model => model.ReceivedById == request.RecivedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            conversations = conversations.OrderBy($"{request.SortMember} {request.SortDirection}");

            return conversations;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}