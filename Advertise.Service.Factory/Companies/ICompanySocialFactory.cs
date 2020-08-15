using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanySocial;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanySocialFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="companySocialId"></param>
        /// <param name="isCurrentUser"></param>
        /// <returns></returns>
        Task<CompanySocialEditViewModel> PrepareEditViewModelAsync(Guid? companySocialId = null, bool isCurrentUser = false, CompanySocialEditViewModel viewModelPrepare = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanySocialListViewModel> PrepareListViewModelAsync(CompanySocialSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}