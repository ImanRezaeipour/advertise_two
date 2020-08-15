using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.CompanyQuestionLike;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyQuestionLikeService {


        Task<CompanyQuestionLike> FindAsync(Guid companyId, Guid userId);


        Task<IList<User>> GetUsersByCompanyIdAsync(Guid questionId);

        /// <summary>
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task<bool> IsLikeByCurrentUserAsync(Guid questionId);

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        Task<bool> IsLikeByUserIdAsync(Guid questionId, Guid userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyQuestionLikeListViewModel> ListByRequestAsync(CompanyQuestionLikeSearchRequest request);

        Task RemoveRangeAsync(IList<CompanyQuestionLike> companyQuestionLikes);


        Task  SeedAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        Task  SetIsLikeByCurrentUserAsync(Guid questionId, bool isLike);

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task  ToggleLikeByCurrentUserAsync(Guid questionId);

        Task<int> CountByRequestAsync(CompanyQuestionLikeSearchRequest request);


        Task<IList<CompanyQuestionLike>> GetByRequestAsync(CompanyQuestionLikeSearchRequest request);


       IQueryable<CompanyQuestionLike> QueryByRequest(CompanyQuestionLikeSearchRequest request);
    }
}