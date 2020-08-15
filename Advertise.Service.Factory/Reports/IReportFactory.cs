using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Report;

namespace Advertise.Service.Factories.Reports
{
    public interface IReportFactory
    {
        Task<ReportListViewModel> PrepareListViewModelAsync(ReportSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        Task<ReportEditViewModel> PrepareEditViewModelAsync(Guid id, ReportEditViewModel viewModelPrepare = null);

        Task<ReportParameterViewModel> PrepareReportParameter(Guid id);
    }
}