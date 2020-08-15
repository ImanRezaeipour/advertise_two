using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.UserSetting;
using Advertise.Core.Types;
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
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Validators.Users;

namespace Advertise.Service.Services.Users
{

    public class UserSettingService : IUserSettingService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserSetting> _userSettingRepository;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public UserSettingService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _userSettingRepository = unitOfWork.Set<UserSetting>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(UserSettingSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task CreateByUserIdAsync(Guid userId)
        {
            var userSetting = new UserSetting
            {
                CreatedById = userId,
                Language = LanguageType.Persian,
                Theme = ThemeType.White
            };
            _userSettingRepository.Add(userSetting);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);
            _eventPublisher.EntityInserted(userSetting);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task CreateByViewModelAsync(UserSettingCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var userSetting = _mapper.Map<UserSetting>(viewModel);
            userSetting.CreatedById = _webContextManager.CurrentUserId;
            _userSettingRepository.Add(userSetting);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);
            _eventPublisher.EntityInserted(userSetting);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userSettingId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid userSettingId)
        {
            var userSetting = await _userSettingRepository.FirstOrDefaultAsync(model => model.Id == userSettingId);
            _userSettingRepository.Remove(userSetting);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);
            _eventPublisher.EntityDeleted(userSetting);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(UserSettingEditValidator), "Edit")]
        public async Task EditByViewModelAsync(UserSettingEditViewModel viewModel, bool applyCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userSetting = await _userSettingRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if(applyCurrentUser && userSetting.CreatedById == _webContextManager.CurrentUserId)
                return;

            _mapper.Map(viewModel, userSetting);

            await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);
            _eventPublisher.EntityUpdated(userSetting);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userSettingId"></param>
        /// <returns></returns>
        public async Task<UserSetting> FindByIdAsync(Guid userSettingId)
        {
            return await _userSettingRepository
                 .FirstOrDefaultAsync(model => model.Id == userSettingId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserSetting> FindByUserIdAsync(Guid userId)
        {
            return await _userSettingRepository
                .FirstOrDefaultAsync(model => model.CreatedById == userId);
        }


        public async Task<IList<UserSetting>> GetByRequestAsync(UserSettingSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public async Task<string> GetMyLanguageAsync()
        {
            var setting = await FindByUserIdAsync(_webContextManager.CurrentUserId);

            if (setting == null)
                return string.Empty;

            switch (setting.Language)
            {
                case LanguageType.English:
                    return "en-US";

                case LanguageType.Persian:
                    return "fa-IR";

                default:
                    return "en-US";
            }
        }


        public IQueryable<UserSetting> QueryByRequest(UserSettingSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userSettings = _userSettingRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                userSettings = userSettings.Where(userSetting => userSetting.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            userSettings = userSettings.OrderBy($"{request.SortMember} {request.SortDirection}");

            return userSettings;
        }


        public async Task<ServiceResult> SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}