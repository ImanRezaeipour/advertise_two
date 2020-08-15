using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Reports;
using Advertise.Core.Models.Report;
using Advertise.Service.Managers.Kendo.DynamicLinq;
using Stimulsoft.Report;

namespace Advertise.Service.Services.Reports
{
    public interface IReportService
    {
        Task<StiReport> GetReportAsStiReportAsync(Guid reportId, ReportParameterViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Task<Report> FindByIdAsync(Guid reportId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<Report> QueryByRequest(ReportSearchRequest request);


        Task CreateByViewModelAsync(ReportCreateViewModel viewModel);


        Task EditByViewModelAsync(ReportEditViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid reportId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DataSourceResult> ListByRequestAsync(DataSourceRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IList<Report>> GetByRequestAsync(ReportSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> CountByRequestAsync(ReportSearchRequest request);

        Task<IList<ReportViewModel>> GeAllAsync();
    }
}