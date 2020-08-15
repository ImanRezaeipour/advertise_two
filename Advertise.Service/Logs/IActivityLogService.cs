using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Logs;
using Advertise.Core.Models.ActivityLog;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Logs
{

    public interface IActivityLogService {

        Task  CreateByViewModelAsync(ActivityLogCreateViewModel viewModel);

        /// <summary>
        /// </summary>
        /// <param name="activityLogId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid activityLogId);


        Task<ActivityLog> FindByIdAsync(Guid activityLogId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ActivityLogListViewModel> ListByRequestAsync(ActivityLogSearchRequest request, bool isCurrentUser = false, Guid? userId = null);


        Task  SeedAsync();


        Task  EditByViewModelAsync(ActivityLogEditViewModel viewModel);


        Task<IList<ActivityLog>> GetByRequestAsync(ActivityLogSearchRequest request);

        Task<int> CountByRequestAsync(ActivityLogSearchRequest request);


        IQueryable<ActivityLog> QueryByRequest(ActivityLogSearchRequest request);
    }
}