using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Logs;
using Advertise.Core.Models.AuditLog;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Logs
{

    public interface IAuditLogService {
        /// <summary>
        ///ایجاد دسته
        /// </summary>
        /// <param name="viewModel"></param>
        Task  CreateByViewModelAsync(AuditLogCreateViewModel viewModel);

        /// <summary>
        /// </summary>
        /// <param name="auditLogId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid auditLogId);


        Task<AuditLog> FindByIdAsync(Guid auditLogId);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuditLogListViewModel> ListByRequestAsync(AuditLogSearchRequest request);


        Task  SeedAsync();


        Task  EditByViewModelAsync(AuditLogEditViewModel viewModel);

        Task<int> CountByRequestAsync(AuditLogSearchRequest request);


        Task<IList<AuditLog>> GetByRequestAsync(AuditLogSearchRequest request);


        IQueryable<AuditLog> QueryByRequest(AuditLogSearchRequest request);
    }
}