using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserOperator;

namespace Advertise.Service.Services.Users
{
    public interface IUserOperationServive
    {
        Task CreateByModelAsync(UserOperator userOperator);
        IQueryable<UserOperator> QueryByrequest(UserOperatorSearchRequest request);
        Task<IList<UserOperator>> GetByRequestAsync(UserOperatorSearchRequest request);
        Task<int> CountByRequest(UserOperatorSearchRequest request);
        Task<UserOperator> FindAsync(Guid userOperatorId);
        Task<UserOperator> FindByUserIdAsync(Guid userId);
    }
}