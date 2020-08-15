using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyHour;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyHourFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="companyHourId"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        Task<CompanyHourEditViewModel> PrepareEditViewModelAsync(Guid? companyHourId = null, bool isCurrentUser = false, CompanyHourEditViewModel viewModelPrepare = null);

        Task<CompanyHourListViewModel> PrepareListViewModRelAsync(CompanyHourSearchRequest request,
            bool isCurrentUser = false, Guid? userId = null);
    }
}