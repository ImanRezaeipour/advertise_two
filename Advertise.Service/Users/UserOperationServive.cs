using Advertise.Core.Domains.Users;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.UserOperator;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Users
{
    public class UserOperationServive : IUserOperationServive
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserOperator> _userOperators;

        #endregion Private Fields

        #region Public Constructors

        public UserOperationServive(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _userOperators = unitOfWork.Set<UserOperator>();
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequest(UserOperatorSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByrequest(request).CountAsync();
        }

        public async Task CreateByModelAsync(UserOperator userOperator)
        {
            if (userOperator == null)
                throw new Exception();

            userOperator.CreatedById = _webContextManager.CurrentUserId;
            _userOperators.Add(userOperator);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<UserOperator> FindAsync(Guid userOperatorId)
        {
            return await _userOperators.FirstOrDefaultAsync(model => model.Id == userOperatorId);
        }

        public async Task<UserOperator> FindByUserIdAsync(Guid userId)
        {
            return await _userOperators.FirstOrDefaultAsync(model => model.CreatedById == userId);
        }

        public async Task<IList<UserOperator>> GetByRequestAsync(UserOperatorSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByrequest(request).ToPagedListAsync(request);
        }

        public IQueryable<UserOperator> QueryByrequest(UserOperatorSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            var userOperators = _userOperators.AsNoTracking().AsQueryable();
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;

            userOperators = userOperators.OrderBy($"{request.SortMember} {request.SortDirection}");
            return userOperators;
        }

        #endregion Public Methods
    }
}