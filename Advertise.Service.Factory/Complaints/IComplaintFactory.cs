using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Complaint;

namespace Advertise.Service.Factories.Complaints
{
    public interface IComplaintFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ComplaintListViewModel> PrepareListViewModelAsync(ComplaintSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<ComplaintDetailViewModel> PrepareDetailViewModelAsync(Guid companyId);
    }
}