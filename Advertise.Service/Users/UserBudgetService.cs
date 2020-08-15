using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.UserBudget;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.WebContext;
using AutoMapper;

namespace Advertise.Service.Services.Users
{

    public class UserBudgetService : IUserBudgetService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserBudget> _userBudgetRepository;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public UserBudgetService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _userBudgetRepository = unitOfWork.Set<UserBudget>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(UserBudgetSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userBudgets = await  QueryByRequest(request).CountAsync();

            return userBudgets;
        }


        public async Task CreateByViewModelAsync(UserBudgetCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userBudget = _mapper.Map<UserBudget>(viewModel);
            _userBudgetRepository.Add(userBudget);

           await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userBudgetId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid userBudgetId)
        {
            var userBudget = await _userBudgetRepository.FirstOrDefaultAsync(model => model.Id == userBudgetId);
            _userBudgetRepository.Remove(userBudget);

            await _unitOfWork.SaveAllChangesAsync();
        }


        public async Task EditByViewModelAsync(UserBudgetEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userBudget = await _userBudgetRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, userBudget);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userBudgetId"></param>
        /// <returns></returns>
        public async Task<UserBudget> FindAsync(Guid userBudgetId)
        {
            var userBudget = await _userBudgetRepository
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == userBudgetId);

            return userBudget;
        }


        public IQueryable<UserBudget> QueryByRequest(UserBudgetSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userBudgets = _userBudgetRepository.AsNoTracking().AsQueryable();
            userBudgets = userBudgets.OrderBy($"{request.SortMember} {request.SortDirection}");

            return userBudgets;
        }


        public async Task<IList<UserBudget>> GetByRequestAsync(UserBudgetSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userBudgets =  await QueryByRequest(request).ToPagedListAsync(request);
           
            return userBudgets;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}