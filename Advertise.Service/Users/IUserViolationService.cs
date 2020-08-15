using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserViolation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Users
{
    public interface IUserViolationService
    {
        #region Public Methods

        Task<int> CountByRequestAsync(UserViolationSearchRequest request);


        Task CreateByViewModelAsync(UserViolationCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userReportId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid userReportId);


        Task EditByViewModelAsync(UserViolationEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userViolationId"></param>
        /// <returns></returns>
        Task<UserViolation> FindByIdAsync(Guid userViolationId);


        Task<IList<UserViolation>> GetByRequestAsync(UserViolationSearchRequest request);


        IQueryable<UserViolation> QueryByRequest(UserViolationSearchRequest request);

        #endregion Public Methods
    }
}